using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	[SerializeField]
	private int maxHits;
	private int timesHit;

	void Awake () {
		timesHit = 0;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ball") {
			timesHit++;
		}
	}

	void Update () {
		if (timesHit >= maxHits) {
			this.gameObject.transform.position = new Vector3 (100f, 100f);
		}
	}
}
