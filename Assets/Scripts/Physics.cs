using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {
   
    public Vector3 initialVelocity;
    public float density = 1.0f;

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

    // Math logic
    //float mass = rho * volume;
    //float volume = Mathf.Pow(radius, 3) * 4.0f / 3.0f * Mathf.PI;

    //sun logic
    //mass = 500
    //radius = 3

    //  500 /
    //  (81 * 4 /3 *Pi)

    float volume = _rigidbody.mass / density;

    float radius = Mathf.Pow( volume * 3.0f / (4.0f * Mathf.PI), 1.0f / 3.0f);
    transform.localScale = new Vector3(radius, radius, radius);

    bool isPlayer = gameObject.tag == "Player";


    foreach (GameObject planet in _physicsObjectController.PhysicsObjects)
        {
            if (GameObject.ReferenceEquals(gameObject, planet)) continue;
            Rigidbody ohterRigidbody = planet.GetComponent<Rigidbody>();

            bool otherIsPlayer = planet.tag == "Player";

      float force;
      if (isPlayer && otherIsPlayer)
      {
        force = Mathf.Pow(Mathf.Min(_rigidbody.mass, ohterRigidbody.mass),2) / Mathf.Pow(Vector3.Distance(transform.position, planet.transform.position), 2);

      }
      else
      {
            force = _rigidbody.mass * ohterRigidbody.mass / Mathf.Pow(Vector3.Distance(transform.position, planet.transform.position), 2);
      }
            Vector3 forceVec =  (planet.transform.position - transform.position).normalized * force;
            _rigidbody.AddForce(forceVec);
        }
	}

    public float GetStableOrbitVelocity(float distance, float mass1, float mass2)
    {
        return Mathf.Sqrt((mass1 + mass2 / distance));
    }
}
