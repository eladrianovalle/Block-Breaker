using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball3D : MonoBehaviour {

	public Paddle3D paddle;

	private Rigidbody rBody;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	private AudioSource audio;

	void Awake() {
		rBody = this.GetComponent<Rigidbody> ();
		audio = gameObject.GetComponent<AudioSource> ();
	}

	void Start () {
		if (paddle == null) {
			paddle = GameObject.FindObjectOfType<Paddle3D> ();
		}
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;


			if (Input.GetMouseButtonDown (0)) {
//				print ("Mouse button clicked, ball launched!");
				hasStarted = true;
				rBody.velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionExit(Collision hit) {
		Vector3 velocityTweak = new Vector3 (Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));

		rBody.velocity += velocityTweak;
//		print ("The current velocity: " + rBody.velocity + " the velocity tweak: " + velocityTweak);

		audio.Play ();
	}
}
