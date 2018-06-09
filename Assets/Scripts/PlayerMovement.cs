using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CurrentPlayer { Player1, Player2, Player3, Player4 }

public class PlayerMovement : MonoBehaviour {
	public float speed;
	
	private Rigidbody _rigidBody;	

	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal_p1");
        float moveVertical = Input.GetAxis("Vertical_p1");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		_rigidBody.AddForce (movement * speed);
	}
}
