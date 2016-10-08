using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuMaster : MonoBehaviour {

	public void goLevel1(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Tutorial");
	}

	public void goStartMenu(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("StartMenu");
	}

	public void goOptionsMenu(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("OptionsMenu");
	}

	public void selectKeyboard(){
		PlayerPrefs.GetString ("input", "keyboard");
		//UnityEngine.SceneManagement.SceneManager.LoadScene ("StartMenu");
	}

	public void selectGuitar(){
		PlayerPrefs.GetString ("input", "guitar");
		//UnityEngine.SceneManagement.SceneManager.LoadScene ("StartMenu");
	}
		






	public void quitGame(){
		Application.Quit ();
	}
	
}
