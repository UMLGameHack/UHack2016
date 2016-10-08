using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class TutorialP2Controller : MonoBehaviour {
	public Text Line;
	public Text Line1;

	public string textline = "Characters will indicate what note \nwill boost them above their head in battle";
	public string textline1 = "give it a try";
	private int pos = 1;
	public float textspeed = .1f; // words per second
	private float currenttime;
	public AudioSource MusicBox;
	public AudioSource MusicBox1;
	public AudioSource MusicBox2;
	private int step = 1;
	public Renderer h1;
	public Renderer h2;
	public Renderer h3;
	public Image h1_note;
	public Image h2_note;
	public Image h3_note;
	// Use this for initialization
	GuitarInterface fg;
	void Start () {
		h1.enabled = false;
		h2.enabled = false;
		h3.enabled = false;
		h1_note.enabled = false;
		h1_note.GetComponentInChildren<Text> ().enabled = false;
		h2_note.enabled = false;
		h2_note.GetComponentInChildren<Text> ().enabled = false;
		h3_note.enabled = false;
		h3_note.GetComponentInChildren<Text> ().enabled = false;
		if (PlayerPrefs.GetString ("input") == "keyboard") {
			fg = new FakeGuitarInterface ();
		} else if (PlayerPrefs.GetString ("input") == "guitar") {
			fg = new FakeGuitarInterface ();
		} else {
			fg = new FakeGuitarInterface ();
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		switch (step) {

		case 1:
			{
				if ((currenttime < 0) & (pos <= textline.Length - 1)) {
					currenttime = textspeed;
					if (textline.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line.text = textline.Substring (0, pos);
					MusicBox.Play ();
				}

				currenttime -= Time.deltaTime;

				if (pos > textline.Length - 1) {
					step += 1;
					currenttime = textspeed;
					Line.text = textline;
					pos = 1;
				}
				break;


			}

		case 2:
			{
				if ((currenttime < 0) & (pos <= textline1.Length - 1)) {
					currenttime = textspeed;
					if (textline1.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line1.text = textline1.Substring (0, pos);
					MusicBox.Play ();
				}

				currenttime -= Time.deltaTime;

				if (pos > textline1.Length - 1) {
					step += 1;
					currenttime = .5f;
					Line.text = textline;
					pos = 1;
				}
				break;


			}

		case 3:{
				if (currenttime < 0) {
					h1.enabled = true;
					MusicBox2.Play ();
					step += 1;
					currenttime = .5f;
				}

				currenttime -= Time.deltaTime;

				break;
			}

		case 4:{
				if (currenttime < 0) {
					h2.enabled = true;
					MusicBox1.Play ();
					step += 1;
					currenttime = .5f;
				}

				currenttime -= Time.deltaTime;

				break;
			}

		case 5:{
				if (currenttime < 0) {
					h3.enabled = true;
					MusicBox2.Play ();
					step += 1;
					currenttime = 1f;
				}

				currenttime -= Time.deltaTime;

				break;
			}
		case 6:{
				if (currenttime < 0) {
					h1_note.enabled = true;
					h1_note.GetComponentInChildren<Text> ().enabled = true;
					MusicBox1.Play ();
					step += 1;
					currenttime = .5f;
				}

				currenttime -= Time.deltaTime;

				break;
			}
		case 7:{
				if (currenttime < 0) {
					h2_note.enabled = true;
					h2_note.GetComponentInChildren<Text> ().enabled = true;
					MusicBox2.Play ();
					step += 1;
					currenttime = .5f;
				}

				currenttime -= Time.deltaTime;

				break;
			}
		case 8:{
				if (currenttime < 0) {
					h3_note.enabled = true;
					h3_note.GetComponentInChildren<Text> ().enabled = true;
					MusicBox1.Play ();
					step += 1;
					currenttime = .5f;
				}

				currenttime -= Time.deltaTime;

				break;
			}
		case 9:{
				// read input here and validate
				//Debug.Log(fg.NoteToString(fg.GetInput ().Notes[0]));
				if (fg.GetInput ().Notes.Count != 0){
					if (fg.NoteToString (fg.GetInput ().Notes [0]) == "C") {
						step += 1;
					}
				}

				break;
			}
		
		case 10:
			{if (fg.GetInput ().Notes.Count != 0){
					if (fg.NoteToString (fg.GetInput ().Notes [0]) == "D") {
						step += 1;
					}
				}

				break;}
		
		case 11:
			{if (fg.GetInput ().Notes.Count != 0){
					if (fg.NoteToString (fg.GetInput ().Notes [0]) == "D") {
						step += 1;
					}
				}

				break;}
		case 12:
			{UnityEngine.SceneManagement.SceneManager.LoadScene ("TutorialP3");break;}



		default:
			{
				break;
			}
		}
	
	}
}
