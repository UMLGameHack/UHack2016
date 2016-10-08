using UnityEngine;
using System.Collections;

/*
 * Handles all of the microphone input behavior.
 * Note, must attach an audio source to whatever object is being used in Unity
 * 
 */
public class MicrophoneInput : MonoBehaviour
{
    private string myMicrophone; //the microphone we will be using.
    private int freq_rate; //sampling rate... set to microphone max frequency
    private const int SAMPLE_DURATION = 1000; //duration of each sample. I hope this is ms.

    private AudioSource aud;   //audio source There are going to be two simultaneous audio source
    private AudioClip oldClip; //clip that has just been recorded to be analyzed.
    private float recordTimeStart; //time that the clip started recording.
    private int elapsedTime; //time since the last started recording in ms
    
    //DEBUG THINGS
    private int updateCount; //just a debug statement to keep track of the number of Update() run
    private float[] frequencySamples;
    private float[] outputData;
    private long debug_total;
    private long debug_output_total;
    private bool processed;
    // Use this for initialization
    void Start()
    {
        processed = false;
        updateCount = 0;
        debug_total = 0;
        debug_output_total = 0;
        myMicrophone = null;
        aud = GetComponent<AudioSource>();
        
        Debug.Log("MicrophoneInput has been Started");
        print("Microphone devices list: " + Microphone.devices.Length);
        foreach (string device in UnityEngine.Microphone.devices)
        {
            print("Device: " + device);
            int minFreq;
            int maxFreq;
            Microphone.GetDeviceCaps(myMicrophone, out minFreq, out maxFreq);
            Debug.Log("Min Frequency = " + minFreq + "\nMax Frequency = " + maxFreq + "\n");
            
            //stores the last microphone listed
            myMicrophone = device;
            Microphone.GetDeviceCaps(device, out minFreq, out maxFreq);
            freq_rate = maxFreq; //set it to the max baby.
            frequencySamples = new float[8192]; //just the largest possible number

    
        }
            //Print what name the device is
            Debug.Log("Microphone Name: " + myMicrophone);
            //find out the sampling limits of the microphone
            
            InvokeRepeating("Check", 0, 2* SAMPLE_DURATION/1000.0f); //double sample rate for now
        
        outputData = new float[SAMPLE_DURATION * freq_rate];
    }

    private void Check()
    {
        print("Entered Check.");
        recordTimeStart = Time.time;
        StartCoroutine(WaitForSample());
    }
    
    private IEnumerator WaitForSample()
    {
        while( ( Time.time - recordTimeStart ) <= SAMPLE_DURATION/1000.0f)
        {
           
            print("WaitForSample called but not returned yet.");
            if (Microphone.IsRecording(myMicrophone))
            {
                print("Microphone is recording.");
                processed = false;
            }
            //else if (processed)
                aud.clip = Microphone.Start(myMicrophone, false, SAMPLE_DURATION, freq_rate);
            if (aud.clip == null)
                print("Clip is null RIGHT after microphone start");
            yield return new WaitForSeconds(Time.time - recordTimeStart);
        }
        //Hopefully enough seconds have passed. Stop the Mic.
        Microphone.End(myMicrophone);
        if (aud.clip == null)
            print("Clip is null RIGHT after microphone End");
        //debug shenanigans

        aud.pitch = 1.5f;
        aud.Play();

        aud.GetSpectrumData(frequencySamples, 0, FFTWindow.Hamming);
        print("About to start to get OutputData.");
        //Mad debug
        if (aud.clip == null)
            print("Clip is null bro");
        if (outputData == null)
            print("Output Data is null son");
        if (aud.clip.GetData(outputData, 0)) //hail GetData 
            print("After OutputData.");
        else
            print("No success on OutputData");
    
        print("Done with output data."); //This part never gets called
        print("Middle outPutData: " + outputData[30] + "\nOutLen = " + outputData.Length); //prints nothing 
        for(int i = 0; i < frequencySamples.Length; i++)
        {
            debug_total += Mathf.Abs((int)frequencySamples[i]);
        }
        for (int i = 0; i < outputData.Length; i++)
        {
            debug_output_total += Mathf.Abs((int)outputData[i]);
        }
        print("Total frequency sample size: " + frequencySamples.Length);
        print("Sum of abs of all samples" + debug_total);
        print("Sum of all the outputData" + debug_output_total);
        debug_total = 0;
        processed = true;
        yield return new WaitForSeconds(0);
    }
    void Update()
    {
        
        
    }

}
