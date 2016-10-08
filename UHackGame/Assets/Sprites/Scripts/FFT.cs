using UnityEngine;
using System.Collections;


/*
 * All of this code was started by unityanswers user zombience
 * #NotPlagarismBecauseICited
 * 
 */
public class FFT : MonoBehaviour
{

    #region vars
    public string CurrentAudioInput;

    private AudioObj[] audioObj = new AudioObj[2];

    //Consts
    private const int BANDS = 4; //number of groups to bin the frequencies into
    private const float PLAYBACK = 0.95f; //speed of playback
    private const float SAMPLE_DURATION = 1.0f / 15.0f; //length of a sample in seconds
    
    //public float[] curve = new float[BANDS]; //scale output of band analysis
    public float[] output = new float[BANDS];

    public string[] inputDevices;
    private int[] crossovers = new int[BANDS];
    private float[] freqData = new float[8192]; //8192 is the largest possible band
    private float[] band;

    private int index = 0;

    public static FFT Instance;
    private bool doSound = true;
    private int deviceNum;


    private struct AudioObj
    {
        public GameObject player;
        public AudioClip clip;
        public void SetClip(AudioClip c)
        {
            clip = c;

            player.GetComponent<AudioSource>().clip = c;

            /*
    slowing the playback down a small amount allows enough space between
    recording and output so that analysis does not overtake the recording.
    this helps with stutter and distortion, but doesn't solve it completely
    */
            player.GetComponent<AudioSource>().pitch = PLAYBACK; //changes playback freq
        }
    }
    #endregion

    #region Unity Methods
    void Start()
    {
        Instance = this;

        crossovers[0] = 30; //guesstimating sample lengths for frequency bands
        crossovers[1] = 50; //AM I dont like magic numbers, TODO change these
        crossovers[2] = 600;
        crossovers[3] = freqData.Length;

        band = new float[BANDS];
        output = new float[BANDS];

        for (int i = 0; i < audioObj.Length; i++)
        {
            audioObj[i].player = (GameObject)Instantiate(gameObject);
            audioObj[i].player.transform.parent = transform;
            audioObj[i].player.transform.position = Vector3.zero;
            audioObj[i].clip = new AudioClip();
        }

        inputDevices = new string[Microphone.devices.Length];
        deviceNum = Microphone.devices.Length - 1; //uses the last microphone listed

        for (int i = 0; i < Microphone.devices.Length; i++)
            inputDevices[i] = Microphone.devices[i].ToString();

        CurrentAudioInput = Microphone.devices[deviceNum].ToString();
        //TODO, get the max sample rate possible and use that 

        //calls the "check method to be repeated 
        InvokeRepeating("Check", 0, SAMPLE_DURATION);
        StartCoroutine(StartRecord());

    }

    void Update()
    {
        KeyInput();
    }
    #endregion

    #region Actions

    private void Check()
    {
        if (!doSound)
            return;
        //output params to freqData
        audioObj[index].player.GetComponent<AudioSource>().GetSpectrumData(freqData, 0, FFTWindow.Hamming);

        bool cutoff = false;
        int k = 0;
        float[] lengths = new float[BANDS];
        for (int i = 0; i < BANDS; i++)
        {
            float min = (i > 0 ? crossovers[i - 1] : 0);
            lengths[i] = crossovers[i] - min;
            band[i] = 0f;
        }

        for (int i = 0; i < freqData.Length; i++)
        {

            if (k > BANDS - 1)
                break;

            band[k] += freqData[i];
            if (i > crossovers[k])
            {
                output[k] = Mathf.Abs(band[k] / lengths[k]);
                k++;
            }
            if (i > crossovers[BANDS - 1] - 10)
                cutoff = true;
        }

        //output should have fft powers in the four bins
        Debug.Log("Bin1: " + output[0] + "Bin2: " + output[1] + "Bin3: " + output[2]);
        Debug.Log("Bin4: " + output[4]);
        print("Cuoff: " + cutoff);
    }

    private IEnumerator StartRecord()
    {
        //TODO, get rid of these magic numbers. Use max sampling rate
        audioObj[index].clip = Microphone.Start(Microphone.devices[deviceNum], true, 5, 24000);
        /*
    the longer the mic recording time, the less often there are "hiccups" in game performance
    but also due to being pitched down, the playback gradually falls farther behind the recording
    */

        print("recording to audioObj " + index);
        StartCoroutine(StartPlay(audioObj[index].clip));
        yield return new WaitForSeconds(5);
        StartCoroutine(StartRecord()); //swaps audio buffers, begins recording and playback of new buffer
                                       /* it is necessary to swap buffers, otherwise the audioclip quickly becomes too large and begins to slow down the system */

    }

    private IEnumerator StartPlay(AudioClip buffer)
    {
        audioObj[index].SetClip(buffer);
        yield return new WaitForSeconds(.01f);
        audioObj[index].player.SetActive(true);
        audioObj[index].player.GetComponent<AudioSource>().Play();

        audioObj[Mathf.Abs((index % 2) - 1)].player.GetComponent<AudioSource>().Stop();

        index++;
        if (index > 1)
            index = 0;


    }

    private void KeyInput()
    {
        //Toggle the FFT with A key
        if (Input.GetKeyDown(KeyCode.A))
        {
            doSound = !doSound;
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            deviceNum++;
            if (deviceNum > Microphone.devices.Length - 1)
                deviceNum = 0;
            CurrentAudioInput = Microphone.devices[deviceNum].ToString();
        }
    }
    #endregion


}
