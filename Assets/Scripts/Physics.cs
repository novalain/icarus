using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsData))]
public class Physics : MonoBehaviour {
    public GameObject controller;
    private Vector3 velocity;

    private PhysicsObjectController  poc;
	// Use this for initialization
	void Start () {
        velocity = new Vector3(0, 0, 0);
        poc = controller.GetComponent<PhysicsObjectController>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject planet in poc.PhysicsObjects)
        {

        }
	}

    public void AddForce(Vector3 force)
    {

    }
}
