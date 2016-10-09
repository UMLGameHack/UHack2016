using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class goRight : MonoBehaviour {

	public Image bg;
	public Text word;
	public string key;
	public AudioSource musicbox;

	public Sprite green;
	public Sprite orange;
	public Sprite yellow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x+7*Time.deltaTime,transform.position.y,transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "boss") {
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
			GameObject.Find("HeroSpawner").GetComponent<HeroSpawner>().allies -= 1;
			Destroy (gameObject.GetComponent<goRight> ());
			Destroy (gameObject.GetComponent<BobBehavior> ());
			Destroy (gameObject.GetComponent<BoxCollider2D> ());
			Destroy (gameObject, 3);
		}
		if (other.tag == "showblock") {
			word.text = key;
			word.enabled = true;
			bg.enabled = true;
			int rnd_num = Random.Range (1, 3);
			if (rnd_num == 1) {
				bg.sprite = green;
			}
			else if (rnd_num == 2) {
				bg.sprite = orange;
			}
			else if (rnd_num == 3) {
				bg.sprite = yellow;
			}

			musicbox.Play();

		}

	}
}
