using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string level) {
		Debug.Log ("Level load call for level: "+level);
		SceneManager.LoadScene (level);

	}

	public void QuitRequest() {
		Debug.Log ("Quit request received!");
		Application.Quit ();
	}

	public static void LoadWin() {
		SceneManager.LoadScene ("Win");
	}

	public static void LoadLose() {
		SceneManager.LoadScene ("Lose");
	}
}
