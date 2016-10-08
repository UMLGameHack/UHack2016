using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeroSpawner : MonoBehaviour {
	public GameObject h1;
	public GameObject h2;
	public GameObject h3;
	public GameObject h4;
	public GameObject h5;
	public GameObject h6;
	public GameObject h7;
	public GameObject h8;
	public GameObject h9;
	public GameObject h10;
	public GameObject h11;
	public GameObject h12;

	public Image img;
	public Text txt;
	public AudioSource musicbox;

	public int allies;

	private int i =0 ;

	public float interval = 1f;
	private float timer;
	private bool flipflop = true;
	GameObject temp;
	FakeGuitarInterface fg;
	List <GuitarNotes> melody;

	// Use this for initialization
	void Start () {
		allies = 0;
		timer = interval;
		img.enabled = false;
		txt.enabled = false;
		if (PlayerPrefs.GetString ("input") == "keyboard") {
			fg = new FakeGuitarInterface ();
		} else if (PlayerPrefs.GetString ("input") == "guitar") {
			//fg = new GuitarInterface ();
		}else {
			fg = new FakeGuitarInterface ();
		}
		melody = fg.GetRandomMelody (Random.Range(5,8));

	
	}
	
	// Update is called once per frame
	void Update () {
		if ((timer < 0)&(melody.Count - i != 0)) {
			int Pick = Random.Range (1, 12);
			switch (Pick) {
			case 1:
				{temp = h1;break;}
			case 2:
				{temp = h2;break;}
			case 3:
				{temp = h3;break;}
			case 4:
				{temp = h4;break;}
			case 5:
				{temp = h5;break;}
			case 6:
				{temp = h6;break;}
			case 7:
				{temp = h7;break;}
			case 8:
				{temp = h8;break;}
			case 9:
				{temp = h9;break;}
			case 10:
				{temp = h10;break;}
			case 11:
				{temp = h11;break;}
			case 12:
				{temp = h12;break;}
			}


			temp.GetComponent<BobBehavior> ().directionbool=flipflop;
			temp.GetComponent<goRight> ().bg = img;
			temp.GetComponent<goRight> ().word = txt;
			temp.GetComponent<goRight> ().musicbox = musicbox;
			temp.GetComponent<goRight> ().key = fg.NoteToString(melody[i]);
			flipflop = !flipflop;
			Instantiate (temp, transform.position, Quaternion.identity);
			timer = interval;
			i += 1;
			allies += 1;
		}

		if ((allies == 0)&(i!=0)) {
			i = 0;
			timer = interval;
			melody = fg.GetRandomMelody (Random.Range(7,15));
		}

		timer -= Time.deltaTime;



	
	}
}
