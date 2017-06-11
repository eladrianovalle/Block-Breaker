using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Paddle paddle;

	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		

			if (Input.GetMouseButtonDown (0)) {
				print ("Mouse button clicked, ball launched!");
				hasStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}
}
