using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX, maxX;

	private Ball ball;

	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	void Update () {
		if (autoPlay) {
			AutoPlay ();
		} else {
			ControlPaddleWithMouse ();
		}
	}

	void ControlPaddleWithMouse() {
		float mousePosInWorldBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (0, this.transform.position.y, 0);
		paddlePos.x = Mathf.Clamp (mousePosInWorldBlocks, minX, maxX);

		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0, this.transform.position.y, 0);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, minX, maxX);

		this.transform.position = paddlePos;
	}
}
