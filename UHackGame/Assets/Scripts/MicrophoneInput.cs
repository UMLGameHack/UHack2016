using UnityEngine;
using System.Collections;

public class MicrophoneInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    foreach( string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
	}
}
