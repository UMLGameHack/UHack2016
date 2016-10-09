using UnityEngine;
using System.Collections;

public class NewGameManager : MonoBehaviour {

	public GameObject h1_mana;
	public GameObject h2_mana;
	public GameObject h3_mana;
	public GameObject h4_mana;

	private float h1_mana_num = 4;
	private float h2_mana_num = 2;
	private float h3_mana_num = 1;
	private float h4_mana_num = 3;

	private float h1_mana_num_max = 4;
	private float h2_mana_num_max = 2;
	private float h3_mana_num_max = 1;
	private float h4_mana_num_max = 3;

	public GameObject h1_health;
	public GameObject h2_health;
	public GameObject h3_health;
	public GameObject h4_health;

	private float h1_health_num = 1;
	private float h2_health_num = 3;
	private float h3_health_num = 4;
	private float h4_health_num = 2;

	private float h1_health_num_max = 1;
	private float h2_health_num_max = 3;
	private float h3_health_num_max = 4;
	private float h4_health_num_max = 2;

	private float selector_delay = .5f;


	private float npc_attack_timer = .5f;
	private float boss_attack_timer = 1f;

	public Sprite DangerMarker;
	public Sprite okMana;
	public Sprite okHp;

	public healthManager bosshp;

	public GameObject selector;
	private int selected = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (selected) {
		case 1:
			{
				selector.transform.position = h1_health.transform.position;
				break;

			}
		case 2:
			{
				selector.transform.position = h2_health.transform.position;
				break;
			}
		case 3:
			{
				selector.transform.position = h3_health.transform.position;
				break;
			}
		case 4:
			{
				selector.transform.position = h4_health.transform.position;
				break;
			}
		case 5:
			{
				selector.transform.position = h1_mana.transform.position;
				break;
			}
		case 6:
			{
				selector.transform.position = h2_mana.transform.position;
				break;
			}
		case 7:
			{
				selector.transform.position = h3_mana.transform.position;
				break;
			}
		case 8:
			{
				selector.transform.position = h4_mana.transform.position;
				break;
			}

		}
		if (selector_delay <= 0) {

			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				selected += 1;
				if (selected > 8) {
					selected = 1;
				}
				selector_delay = .25f;
			}

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				selected -= 1;
				if (selected < 1) {
					selected = 8;
				}
				//selector_delay = .25f;
			}

		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			switch (selected) {
			case 1:
				{
					h1_health_num += 1.5f;
					if (h1_health_num > h1_health_num_max) {
						h1_health_num = h1_health_num_max;
					}
					break;
				}
			case 2:
				{
					h2_health_num += 1.5f;
					if (h2_health_num > h2_health_num_max) {
						h2_health_num = h2_health_num_max;
					}
					break;
				}
			case 3:
				{
					h3_health_num += 1.5f;
					if (h3_health_num > h3_health_num_max) {
						h3_health_num = h3_health_num_max;
					}
					break;
				}
			case 4:
				{
					h4_health_num += 1.5f;
					if (h4_health_num > h4_health_num_max) {
						h4_health_num = h4_health_num_max;
					}
					break;
				}
			case 5:
				{
					h1_mana_num += 1.5f;
					if (h1_mana_num > h1_mana_num_max) {
						h1_mana_num = h1_mana_num_max;
					}
					break;
				}
			case 6:
				{
					h2_mana_num += 1.5f;
					if (h2_mana_num > h2_mana_num_max) {
						h2_mana_num = h2_mana_num_max;
					}
					break;
				}
			case 7:
				{
					h3_mana_num += 1.5f;
					if (h3_mana_num > h3_mana_num_max) {
						h3_mana_num = h3_mana_num_max;
					}
					break;
				}
			case 8:
				{
					h4_mana_num += 1.5f;
					if (h4_mana_num > h4_mana_num_max) {
						h4_mana_num = h4_mana_num_max;
					}
					break;
				}


			}
			
		}

		boss_attack_timer -= Time.deltaTime;
		npc_attack_timer -= Time.deltaTime;

		if (npc_attack_timer < 0) {


			if (h1_mana_num > 0) {
				bosshp.health -= h1_mana_num_max / 40;
			}

			if (h2_mana_num > 0) {
				bosshp.health -= h2_mana_num_max / 40;
			}

			if (h3_mana_num > 0) {
				bosshp.health -= h3_mana_num_max / 40;
			}

			if (h4_mana_num > 0) {
				bosshp.health -= h4_mana_num_max / 40;
			}

			npc_attack_timer = 1f;
		}


		if (boss_attack_timer < 0) {
			// boss attacks
			if (Random.Range (1, 6) == 3) {
				h1_health_num -= 1f;
			}
			if (Random.Range (1, 6) == 3) {
				h2_health_num -= 1f;
			}
			if (Random.Range (1, 6) == 3) {
				h3_health_num -= 1f;
			}
			if (Random.Range (1, 6) == 3) {
				h4_health_num -= 1f;
			}

			if (h1_health_num < h1_health_num_max/2) {
				h1_health.GetComponent<SpriteRenderer> ().sprite = DangerMarker;
			}
			if (h2_health_num < h2_health_num_max/2) {
				h2_health.GetComponent<SpriteRenderer> ().sprite = DangerMarker;
			}
			if (h3_health_num < h3_health_num_max/2) {
				h3_health.GetComponent<SpriteRenderer> ().sprite = DangerMarker;
			}
			if (h4_health_num < h4_health_num_max/2) {
				h4_health.GetComponent<SpriteRenderer> ().sprite = DangerMarker;
			}

			if (h1_health_num > h1_health_num_max/2) {
				h1_health.GetComponent<SpriteRenderer> ().sprite = okHp;
			}
			if (h2_health_num > h2_health_num_max/2) {
				h2_health.GetComponent<SpriteRenderer> ().sprite = okHp;
			}
			if (h3_health_num > h3_health_num_max/2) {
				h3_health.GetComponent<SpriteRenderer> ().sprite = okHp;
			}
			if (h4_health_num > h4_health_num_max/2) {
				h4_health.GetComponent<SpriteRenderer> ().sprite = okHp;
			}
				
			if (Random.Range (1, 6) == 3) {
				h1_mana_num -= 1f;
			}
			if (Random.Range (1, 6) == 3) {
				h2_mana_num -= 1f;
			}
			if (Random.Range (1, 6) == 3) {
				h3_mana_num -= 1f;
			}
			if (Random.Range (1, 6) == 3) {
				h4_mana_num -= 1f;
			}

			if (h1_mana_num < h1_mana_num_max/2) {
				h1_mana.GetComponent<SpriteRenderer> ().sprite = DangerMarker;
			}
			if (h2_mana_num < h2_mana_num_max/2) {
				h2_mana.GetComponent<SpriteRenderer> ().sprite = DangerMarker;
			}
			if (h3_mana_num < h3_mana_num_max/2) {
				h3_mana.GetComponent<SpriteRenderer> ().sprite = DangerMarker;
			}
			if (h4_mana_num < h4_mana_num_max/2) {
				h4_mana.GetComponent<SpriteRenderer> ().sprite = DangerMarker;
			}

			if (h1_mana_num > h1_mana_num_max/2) {
				h1_mana.GetComponent<SpriteRenderer> ().sprite = okMana;
			}
			if (h2_mana_num > h2_mana_num_max/2) {
				h2_mana.GetComponent<SpriteRenderer> ().sprite = okMana;
			}
			if (h3_mana_num > h3_mana_num_max/2) {
				h3_mana.GetComponent<SpriteRenderer> ().sprite = okMana;
			}
			if (h4_mana_num > h4_mana_num_max/2) {
				h4_mana.GetComponent<SpriteRenderer> ().sprite = okMana;
			}

			boss_attack_timer = 1f;
		}


		if (selector_delay > 0) {
			selector_delay -= Time.deltaTime;
		}

		if ((h1_health_num == 0) && (h2_health_num == 0) && (h3_health_num == 0) && (h4_health_num == 0)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("GameOverMenu");
		}
		if (bosshp.health <= 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("VictoryMenu");
		}
	
	}
}
