using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogicScript : MonoBehaviour {

  public float AsteroidSpawningDelay = 5;
  private float m_nextAsteroidSpawnTime;

	// Use this for initialization
	void Start () {
    m_nextAsteroidSpawnTime = Time.time;
  }
	
	// Update is called once per frame
	void Update () {
    if (Time.time > m_nextAsteroidSpawnTime)
    {
      GetComponent<AsteroidSpawnManager>().AddAsteroid();
      m_nextAsteroidSpawnTime = Time.time + AsteroidSpawningDelay;
      Debug.Log("SPAWNING ASTEROIDS BIATCHESSSZZ!");
    }
  }
}
