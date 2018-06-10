using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayersManager : MonoBehaviour {
    public bool spawnSun = true;

	private static readonly Color[] PLAYER_COLORS = { Color.red, Color.green, Color.blue, Color.yellow };

	// Use this for initialization
	void Start () {

		 // Find Spawn Point parent object
        GameObject spawnPoints = GameObject.Find("SpawnPoints");
        if (spawnPoints == null) Debug.LogError("You need to add the spawnpoints prefab to the scene");

        PhysicsObjectController physicsObjectController = GetComponent<PhysicsObjectController>();
        // Instanciate Sun
        if (spawnSun)
        {
            GameObject sunPrefab = (GameObject)Resources.Load("Prefabs/Planet", typeof(GameObject));
            GameObject sunObject = Instantiate(sunPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            sunObject.name = "Sun";
        
		    physicsObjectController.PhysicsObjects.Add(sunObject);
        }

        for (int i = 0; i < GlobalData.numPlayers; ++i) {
            // Spawn point data
            Transform spawnPoint = spawnPoints.transform.GetChild(i);          
            Vector3 initialVelocity = spawnPoint.GetComponent<SpawnPointData>().initalVelocity;

			GameObject playerGameObject = (GameObject)Resources.Load("Prefabs/Player", typeof(GameObject));
			GameObject instanciatedGameObject = Instantiate(playerGameObject, spawnPoint.position, Quaternion.identity);
			
			PlayerMovement playerMovementComponent = instanciatedGameObject.GetComponent<PlayerMovement>();
			playerMovementComponent.playerType = (i + 1);
			physicsObjectController.PhysicsObjects.Add(instanciatedGameObject);


			// Decactivate the children we don't need for current player
			int j = 0;
			foreach (Transform child in instanciatedGameObject.transform) {
				if (j != i) {
					child.gameObject.SetActive(false);
				}
				++j;
			}
				
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