using UnityEngine;
using System.Collections;

public class MenuMaster : MonoBehaviour {

	public void goLevel1(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Level1");
	}

	public void quitGame(){
		Application.Quit ();
	}
	
}
