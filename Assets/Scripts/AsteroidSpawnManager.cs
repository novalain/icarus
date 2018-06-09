using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnManager : MonoBehaviour {

  public GameObject Asteroid;

  [Header("Spawn Parameters")]
  public float SpawnRadius = 30.0f;
  [Header("Geometric Attributes")]
  public float MinRadius = 0.25f;
  public float MaxRadius = 2.0f;
  [Header("Initial Velocity Attributes")]
  public float InitialSpreadAngle = 90.0f;
  public float MinStartVelocity = 0.1f;
  public float MaxStartVelocity = 5.0f;


  public void AddAsteroid()
  {
    float spawnAngle = Mathf.Deg2Rad * Random.value * 360.0f;
    Vector3 SpawnPosition = new Vector3(Mathf.Cos(spawnAngle)*SpawnRadius, 0, Mathf.Sin(spawnAngle)*SpawnRadius);

    GameObject newAsteroidObj = Instantiate(Asteroid, SpawnPosition, Quaternion.identity);

    // Todo: add random mass

    // Geometrical size
    float AsteroidSize = Random.Range(MinRadius, MaxRadius);
    newAsteroidObj.transform.localScale = new Vector3(AsteroidSize, AsteroidSize, AsteroidSize);

    // initial speed and direction
    Vector3 initialDirection = (new Vector3(0,0,0) - SpawnPosition).normalized;
    float initialSpeed = Random.Range(MinStartVelocity, MaxStartVelocity);

    newAsteroidObj.GetComponent<Rigidbody>().velocity = initialDirection * initialSpeed;

    GameObject physicsObjectController = GameObject.Find("GameController");
    physicsObjectController.GetComponent<PhysicsObjectController>().PhysicsObjects.Add(newAsteroidObj);
  }



}
