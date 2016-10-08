using UnityEngine;
using System.Collections;


public class MicrophoneInput : MonoBehaviour
{
    private string myMicrophone; //the microphone we will be using.
    private const int FREQ_RATE = 5000; //sampling rate... up as needed.
    private const double SAMPLE_DURATION = 0.04; //duration of each sample.
    // Use this for initialization
    void Start()
    {
        myMicrophone = null;
        Debug.Log("MicrophoneInput has been Started");
        foreach (string device in UnityEngine.Microphone.devices)
        {
            //stores the first microphone found as myMicrophone (may be problematic)
            if (myMicrophone == null)
                myMicrophone = device;
            Debug.Log("Name: " + device);
        }
    }

    void Update()
    {
     
    }

}
