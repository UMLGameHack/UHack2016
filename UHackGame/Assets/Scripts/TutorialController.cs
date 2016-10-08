using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialController : MonoBehaviour {

	public Text Line;
	public Text Line1;
	public Text Line2;
	public Text Line3;
	public Text Line4;
	public Text Line5;
	public Text Line6;

	public Renderer you;
	public Renderer h1;
	public Renderer h2;
	public Renderer h3;



	private int step = 1;

	public string textline = "Welcome,";
	public string textline1 = "Lets make some introductions";
	public string textline2 = "This is you";
	public string textline3 = "You suck";
	public string textline4 = "(sorry)";
	public string textline5 = "As a bard you need some of these guys to fight for you";
	public string textline6 = "You help them by playing them some sweet and righteous tunes";

	private int textline_len;
	private int pos = 1;
	public float textspeed = .025f; // words per second
	private float currenttime;
	public int linenumbers = 1;
	public AudioSource MusicBox;
	public AudioSource MusicBox1;
	public AudioSource MusicBox2;

	// Use this for initialization
	void Start () {
		textline_len = textline.Length;
		currenttime = textspeed;
		Line.text = textline.Substring(0,pos);
		MusicBox.Play ();

		you.enabled = false;
		h1.enabled = false;
		h2.enabled = false;
		h3.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		switch (step) {

		case 1: {
				if ((currenttime < 0)&(pos <= textline.Length-1)) {
					currenttime = textspeed;
					if (textline.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line.text = textline.Substring(0,pos);
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

		case 2: {
				if ((currenttime < 0)&(pos <= textline1.Length-1)) {
					currenttime = textspeed;
					if (textline1.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line1.text = textline1.Substring(0,pos);
					MusicBox.Play ();
				}

				currenttime -= Time.deltaTime;

				if (pos > textline1.Length - 1) {
					step += 1;
					currenttime = textspeed;
					Line.text = textline;
					pos = 1;
				}

				break;

			}

		case 3: {
				if ((currenttime < 0)&(pos <= textline2.Length-1)) {
					currenttime = textspeed;
					if (textline2.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line2.text = textline2.Substring(0,pos);
					MusicBox.Play ();
				}

				if ((currenttime < 0) & (you.enabled == false)) {
					you.enabled = true;
					MusicBox1.Play ();
				}

				currenttime -= Time.deltaTime;

				if ((pos > textline2.Length - 1)&(you.enabled)) {
					step += 1;
					currenttime = textspeed;
					Line.text = textline;
					pos = 1;
				}

				break;

			}

		case 4: {
				if ((currenttime < 0)&(pos <= textline3.Length-1)) {
					currenttime = textspeed;
					if (textline3.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line3.text = textline3.Substring(0,pos);
					MusicBox.Play ();
				}

				currenttime -= Time.deltaTime;

				if (pos > textline3.Length - 1) {
					step += 1;
					currenttime = textspeed;
					Line.text = textline;
					pos = 1;
				}

				break;

			}
		
		case 5: {
				if ((currenttime < 0)&(pos <= textline4.Length-1)) {
					currenttime = textspeed;
					if (textline4.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line4.text = textline4.Substring(0,pos);
					MusicBox.Play ();
				}

				currenttime -= Time.deltaTime;

				if (pos > textline4.Length - 1) {
					step += 1;
					currenttime = textspeed;
					Line.text = textline;
					pos = 1;
				}

				break;

			}

		case 6: {
				if ((currenttime < 0)&(pos <= textline5.Length-1)) {
					currenttime = textspeed;
					if (textline5.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line5.text = textline5.Substring(0,pos);
					MusicBox.Play ();
				}

				currenttime -= Time.deltaTime;

				if (pos > textline5.Length - 1) {
					step += 1;
					currenttime = .5f;
					Line.text = textline;
					pos = 1;
				}

				break;

			}
		case 7:{
				if (currenttime < 0) {
					h1.enabled = true;
					MusicBox2.Play ();
					step += 1;
					currenttime = .5f;
				}

				currenttime -= Time.deltaTime;

				break;
			}
		case 8:{
				if (currenttime < 0) {
					h2.enabled = true;
					MusicBox1.Play ();
					step += 1;
					currenttime = .5f;
				}

				currenttime -= Time.deltaTime;

				break;
				
			}
		case 9:{
				if (currenttime < 0) {
					h3.enabled = true;
					MusicBox2.Play ();
					step += 1;
					currenttime = textspeed;
				}

				currenttime -= Time.deltaTime;

				break;
			}

		case 10: {
				if ((currenttime < 0)&(pos <= textline6.Length-1)) {
					currenttime = textspeed;
					if (textline6.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line6.text = textline6.Substring(0,pos);
					MusicBox.Play ();
				}

				currenttime -= Time.deltaTime;

				if (pos > textline6.Length - 1) {
					step += 1;
					currenttime = 3;
					Line.text = textline;
					pos = 1;
				}

				break;

			}
		case 11:{
				if (currenttime < 0) {
					UnityEngine.SceneManagement.SceneManager.LoadScene ("Level1");
				}
				currenttime -= Time.deltaTime;

				break;
			}




		default: {
				//step = 1;
				break;
			}
		}


	}
}
