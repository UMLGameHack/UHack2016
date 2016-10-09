using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class TutorialP2Controller : MonoBehaviour {
	public Text Line;
	public Text Line1;

	public string textline = "Characters will indicate what note \nwill boost them above their head in battle";
	public string textline1 = "give it a try";
	public float textspeed = .1f; // words per second

	public AudioSource MusicBox;
	public AudioSource MusicBox1;
	public AudioSource MusicBox2;
	public Renderer h1;
	public Renderer h2;
	public Renderer h3;
	public Image h1_note;
	public Image h2_note;
	public Image h3_note;

	private GuitarInterface fg;
	private int step = 1;
	private int pos = 1;
	private float currenttime;

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
					currenttime = 3f;
				}

				currenttime -= Time.deltaTime;

				break;
			}

		case 5:{
				if (currenttime < 0) {
					UnityEngine.SceneManagement.SceneManager.LoadScene ("NewGame");
				}
				currenttime -= Time.deltaTime;
				break;}

		default:
			{
				break;
			}
		}
	
	}
}
