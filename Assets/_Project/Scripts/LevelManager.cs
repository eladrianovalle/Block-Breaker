using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static void LoadLevel(string level) {
		Brick.breakableBricks = 0;
		SceneManager.LoadScene (level);
	}

	public void QuitRequest() {
		Application.Quit ();
	}

	public static void LoadWin() {
		LoadLevel ("Win");
	}

	public static void LoadLose() {
		LoadLevel ("Lose");
	}

	public static void LoadNextLevel() {
		Brick.breakableBricks = 0;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public static void BrickDestroyed() {
		if (Brick.breakableBricks <= 0) {
			LoadNextLevel ();
		}
	}


}


