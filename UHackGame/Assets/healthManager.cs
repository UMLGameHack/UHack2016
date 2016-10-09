using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthManager : MonoBehaviour {

	public float health = 17f;

	public Sprite redEnd;
	public Sprite redBar;

	public Image hb1;
	public Image hb2;
	public Image hb3;
	public Image hb4;
	public Image hb5;
	public Image hb6;
	public Image hb7;
	public Image hb8;
	public Image hb9;
	public Image hb10;
	public Image hb11;
	public Image hb12;
	public Image hb13;
	public Image hb14;
	public Image hb15;
	public Image hb16;
	public Image hb17;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 16) {
			hb1.sprite = redEnd;
		}

		if (health <= 15) {
			hb2.sprite = redBar;
		}

		if (health <= 14) {
			hb3.sprite = redBar;
		}

		if (health <= 13) {
			hb4.sprite = redBar;
		}

		if (health <= 12) {
			hb5.sprite = redBar;
		}

		if (health <= 11) {
			hb6.sprite = redBar;
		}

		if (health <= 10) {
			hb7.sprite = redBar;
		}

		if (health <= 9) {
			hb8.sprite = redBar;
		}

		if (health <= 8) {
			hb9.sprite = redBar;
		}

		if (health <= 7) {
			hb10.sprite = redBar;
		}

		if (health <= 6) {
			hb11.sprite = redBar;
		}

		if (health <= 5) {
			hb12.sprite = redBar;
		}

		if (health <= 4) {
			hb13.sprite = redBar;
		}

		if (health <= 3) {
			hb14.sprite = redBar;
		}

		if (health <= 2) {
			hb15.sprite = redBar;
		}

		if (health <= 1) {
			hb16.sprite = redBar;
		}
		
	
	}
}
