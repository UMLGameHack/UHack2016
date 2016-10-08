using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialP3Controller : MonoBehaviour {
	public Text Line;
	public Text Line1;
	public Text Line2;

	public float textspeed = .1f; // words per second
	private float currenttime;
	public AudioSource MusicBox;
	private int pos = 1;

	private int step = 1;

	public string textline = "Good Job!";
	public string textline1 = "You didn't screw that up!";
	public string textline2 = "Now... Lets start the real battle";
	// Use this for initialization
	void Start () {
	
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
					currenttime = 1;
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
					currenttime = 2;
					Line1.text = textline1;
					pos = 1;
				}
				break;


			}

		case 3:
			{
				if ((currenttime < 0) & (pos <= textline2.Length - 1)) {
					currenttime = textspeed;
					if (textline2.Substring (pos, 1) == " ") {
						pos += 1;
					}
					pos += 1;
					Line2.text = textline2.Substring (0, pos);
					MusicBox.Play ();
				}

				currenttime -= Time.deltaTime;

				if (pos > textline2.Length - 1) {
					step += 1;
					currenttime = 2;
					Line2.text = textline2;
					pos = 1;
				}
				break;


			}

		case 4:{
				if (currenttime < 0) {
					UnityEngine.SceneManagement.SceneManager.LoadScene ("Level1");
				}
				currenttime -= Time.deltaTime;

			break;
			
			}




		}
	}
}
