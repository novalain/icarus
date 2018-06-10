using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnManager : MonoBehaviour {

  public GameObject Asteroid;

  [Header("Spawn Parameters")]
  public float SpawnRadius = 30.0f;
  [Header("Geometric Attributes")]
  public float MinRadius = 0.2f;
  public float MaxRadius = 1.0f;
  [Header("Mass/Radius relationship")]
  public float MassCoefficient = 0.5f;
  [Header("Initial Velocity Attributes")]
  public float InitialSpreadAngle = 90.0f;
  public float MinStartVelocity = 0.1f;
  public float MaxStartVelocity = 5.0f;


  public void AddAsteroid()
  {
    float spawnAngle = Mathf.Deg2Rad * Random.value * 360.0f;
    Vector3 SpawnPosition = new Vector3(Mathf.Cos(spawnAngle)*SpawnRadius, 0, Mathf.Sin(spawnAngle)*SpawnRadius);

    GameObject newAsteroidObj = Instantiate(Asteroid, SpawnPosition, Quaternion.identity);
    
    // Geometrical size
    float asteroidSize = Random.Range(MinRadius, MaxRadius);
    newAsteroidObj.transform.localScale = new Vector3(asteroidSize, asteroidSize, asteroidSize);
    
    newAsteroidObj.gameObject.GetComponent<Rigidbody>().mass = asteroidSize * MassCoefficient;

    // initial speed and direction
    float directionSpread = (2*Random.value-1) * InitialSpreadAngle / 2;
    Vector3 initialDirection = Quaternion.AngleAxis(directionSpread, Vector3.up) * (new Vector3(0,0,0) - SpawnPosition).normalized;
    float initialSpeed = Random.Range(MinStartVelocity, MaxStartVelocity);

    newAsteroidObj.GetComponent<Rigidbody>().velocity = initialDirection * initialSpeed;

    GameObject physicsObjectController = GameObject.Find("GameController");
    physicsObjectController.GetComponent<PhysicsObjectController>().PhysicsObjects.Add(newAsteroidObj);
  }



}
