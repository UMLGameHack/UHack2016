﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuMaster : MonoBehaviour {

	public void goLevel1(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Tutorial");
	}

	public void goStartMenu(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("StartMenu");
	}




	public void quitGame(){
		Application.Quit ();
	}
	
}