using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {
    public float speed = 2;

    private Vector3 velocity;
	// Use this for initialization
	void Start () {
        velocity = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
        {
            velocity.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -1;
        }

        transform.position += velocity.normalized * speed;
    }
}
