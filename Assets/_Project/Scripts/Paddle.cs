using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	void Update () {
		ControlPaddleMovement ();
	}

	void ControlPaddleMovement() {
		float mousePosInWorldBlocks = Input.mousePosition.x / Screen.width * 16;

		Vector3 paddlePos = new Vector3 (0, this.transform.position.y, 0);
		paddlePos.x = Mathf.Clamp (mousePosInWorldBlocks, .5f, 15.5f);

		this.transform.position = paddlePos;
	}
}
