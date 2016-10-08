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
    private const int SAMPLE_DURATION = 40; //duration of each sample. I hope this is ms.

    private AudioSource aud;   //audio source for use.
                               //lets make this a circular buffer of clips in the future? 
                               //idk if that would help anything if its not processing fast enough

    private AudioClip oldClip; //clip that has just been recorded to be analyzed.
    private float recordTimeStart; //time that the clip started recording.
    private int elapsedTime; //time since the last started recording in ms
    
    //DEBUG THINGS
    private int updateCount; //just a debug statement to keep track of the number of Update() run
    private float[] samples;
    
    // Use this for initialization
    void Start()
    {
        updateCount = 0;
        myMicrophone = null;
        aud = GetComponent<AudioSource>();
        Debug.Log("MicrophoneInput has been Started");
        foreach (string device in UnityEngine.Microphone.devices)
        {
            int minFreq;
            int maxFreq;
            
            //stores the first microphone found as myMicrophone (may be problematic)
            if (myMicrophone == null)
            {
                myMicrophone = device;
                Microphone.GetDeviceCaps(device, out minFreq, out maxFreq);
                freq_rate = maxFreq; //set it to the max baby.
                samples = new float[freq_rate * SAMPLE_DURATION];

            }
            
            //Print what name the device is
            Debug.Log("Name: " + device); 
            //find out the sampling limits of the microphone
            Microphone.GetDeviceCaps(device, out minFreq, out maxFreq);
            Debug.Log("Min Frequency = " + minFreq + "\nMax Frequency = " + maxFreq + "\n");
        }
    }

    void Update()
    {
        //set elapsed time in ms
        elapsedTime = (int)(Time.time - recordTimeStart) * 1000;

        //infrequent debug
        updateCount++;
        if(updateCount >=60)
        {
            //look at how many samples are taken
            if (aud != null)
                Debug.Log("Number of samples in MyClip: " + aud.clip.samples);

            //look at whats in the samples
            aud.clip.GetData(samples, 10);
            Debug.Log("Random audio data: " + samples[10]); //0 every time

            //Just play it back

            if (aud.clip.loadState == AudioDataLoadState.Loaded)
            {
                Debug.Log("Playing back audio data"); //plays back only the first time
                aud.Play();
            }
            updateCount = 0;

            //aud.clip = null; //try refreshing the clip BAD

        }

        //If we're recording....
        if (Microphone.IsRecording(myMicrophone) )
        {
            //Do nothing, just let it record.
            //JK this is where we're going to do processing later.
            
        } 
        
        //If we're not recording, or if the recording times out
        if (!Microphone.IsRecording(myMicrophone) || elapsedTime > SAMPLE_DURATION) {

            //end the current clip.
            if (aud.clip != null)
            {
                Microphone.End(myMicrophone);
            }


            //we're not recording, and the old clip has been processed it is time to start recording

            Debug.Log("Starting Recording");
            recordTimeStart = Time.time;
            aud.clip = Microphone.Start(myMicrophone, false, SAMPLE_DURATION, freq_rate);

            //test if record failure
            if (aud.clip == null)
                Debug.Log("Microphone recording failed :(");
            
            
        }
    }

}
