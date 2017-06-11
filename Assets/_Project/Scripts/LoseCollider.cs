using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		print ("Collision2D!");
		if (collision.gameObject.tag == "Player") {
			LevelManager.LoadLose ();
		}
	}

	void OnCollisionEnter(Collision collision) {
		print ("Collision!");
		if (collision.gameObject.tag == "Player") {
			LevelManager.LoadLose ();
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		print ("Trigger2D!");
	}

	void OnTriggerEnter(Collider collider) {
		print ("Trigger!");
	}
}
