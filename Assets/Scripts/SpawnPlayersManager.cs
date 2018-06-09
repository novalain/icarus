using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayersManager : MonoBehaviour {
	private static readonly Color[] PLAYER_COLORS = { Color.red, Color.green, Color.blue, Color.yellow };

	// Use this for initialization
	void Start () {
        // Find Spawn Point parent object
        GameObject spawnPoints = GameObject.Find("SpawnPoints");
        if (spawnPoints == null) Debug.LogError("You need to add the spawnpoints prefab to the scene");

		PhysicsObjectController physicsObjectController = GetComponent<PhysicsObjectController>();
		for (int i = 0; i < GlobalData.numPlayers; ++i) {
			GameObject playerGameObject = (GameObject)Resources.Load("Prefabs/Player", typeof(GameObject));

            // Spawn point data
            Transform spawnPoint = spawnPoints.transform.GetChild(i);          
            Vector3 initialVelocity = spawnPoint.GetComponent<SpawnPointData>().initalVelocity;
			
			PlayerMovement playerMovementComponent = playerGameObject.GetComponent<PlayerMovement>();
			playerMovementComponent.playerType = (i + 1);
			physicsObjectController.PhysicsObjects.Add(playerGameObject);

			GameObject instanciatedGameObject = Instantiate(playerGameObject, new Vector3((i + 1) * 5, 0, 0), Quaternion.identity);	
			// Set unique color and name
			instanciatedGameObject.name = "Player " + (i + 1);
			instanciatedGameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", PLAYER_COLORS[i]);
            instanciatedGameObject.GetComponent<Rigidbody>().velocity = initialVelocity;
		}

        // Make the spawnpoints invisible
        spawnPoints.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}