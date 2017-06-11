using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public static MusicManager _instance = null;

	public static MusicManager instance { get { return _instance; } }

	void Awake () {
		if (_instance != null && _instance != this) {
			Destroy (this.gameObject);
		} else {
			_instance = this;
			GameObject.DontDestroyOnLoad (this.gameObject);
		}
	}
}
