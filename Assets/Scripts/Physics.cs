using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsData))]
public class Physics : MonoBehaviour {
   
    public Vector3 initialVelocity;

    private GameObject _gameController;
    private PhysicsObjectController  _physicsObjectController;
    private Rigidbody _rigidbody;
    private PhysicsData _physicsData;
	// Use this for initialization
	void Start () {

        _gameController = GameObject.Find("GameController");
        if (_gameController == null) Debug.LogError("Must have GameController with that name in the scene");
        _physicsData = GetComponent<PhysicsData>();
        _rigidbody = GetComponent<Rigidbody>();
        _physicsObjectController = _gameController.GetComponent<PhysicsObjectController>();
        _rigidbody.velocity = initialVelocity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach(GameObject planet in _physicsObjectController.PhysicsObjects)
        {
            if (GameObject.ReferenceEquals(gameObject, planet)) continue;
            PhysicsData otherPhysicsData = planet.GetComponent<PhysicsData>();

            float force = _physicsData.mass * otherPhysicsData.mass / Mathf.Pow(Vector3.Distance(transform.position, planet.transform.position), 2);
            Vector3 forceVec =  (planet.transform.position - transform.position).normalized * force;
            _rigidbody.AddForce(forceVec);
        }
	}

}
