using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 0;
	public int playerType = 0;

	private Rigidbody _rigidBody;	

	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		_rigidBody.AddForce (movement * speed);
	}
}
