using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Paddle paddle;

	private Rigidbody2D rBody;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	private AudioSource audio;

	void Awake() {
		rBody = this.GetComponent<Rigidbody2D> ();
		audio = gameObject.GetComponent<AudioSource> ();
	}

	void Start () {
		if (paddle == null) {
			paddle = GameObject.FindObjectOfType<Paddle> ();
		}
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		

			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				rBody.velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionExit2D(Collision2D hit) {
		if (hasStarted) {
			Vector2 velocityTweak = new Vector2 (Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
			rBody.velocity += velocityTweak;

			print ("The current velocity: " + rBody.velocity + " the velocity tweak: " + velocityTweak);

			audio.Play ();
		}
	}
}
