using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {
   
    public Vector3 initialVelocity;

    private GameObject _gameController;
    private PhysicsObjectController  _physicsObjectController;
    private Rigidbody _rigidbody;
	// Use this for initialization
	void Start () {
        _gameController = GameObject.Find("GameController");
        if (_gameController == null) Debug.LogError("Must have GameController with that name in the scene");
        _rigidbody = GetComponent<Rigidbody>();
        _physicsObjectController = _gameController.GetComponent<PhysicsObjectController>();
        //_rigidbody.velocity = initialVelocity;


       // GameObject sun = GameObject.FindGameObjectWithTag("BlackHole");
       // if (sun == null) Debug.LogError("sun object needs to have tag 'BlackHole'");
       // float stableVelocity = GetStableOrbitVelocity(Vector3.Distance(sun.transform.position, transform.position), _rigidbody.mass, sun.GetComponent<Rigidbody>().mass);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach(GameObject planet in _physicsObjectController.PhysicsObjects)
        {
            if (GameObject.ReferenceEquals(gameObject, planet)) continue;
            Rigidbody ohterRigidbody = planet.GetComponent<Rigidbody>();

            float force = _rigidbody.mass * ohterRigidbody.mass / Mathf.Pow(Vector3.Distance(transform.position, planet.transform.position), 2);
            Vector3 forceVec =  (planet.transform.position - transform.position).normalized * force;
            _rigidbody.AddForce(forceVec);
        }
	}

    public float GetStableOrbitVelocity(float distance, float mass1, float mass2)
    {
        return Mathf.Sqrt((mass1 + mass2 / distance));
    }
}
