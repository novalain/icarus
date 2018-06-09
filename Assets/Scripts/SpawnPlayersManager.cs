using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayersManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		PhysicsObjectController physicsObjectController = GetComponent<PhysicsObjectController>();
		for (int i = 0; i < GlobalData.numPlayers; ++i) {
			GameObject playerGameObject = (GameObject)Resources.Load("Prefabs/Player", typeof(GameObject));
			playerGameObject.name = "Player " + (i + 1);
			PlayerMovement playerMovementComponent = playerGameObject.GetComponent<PlayerMovement>();
			playerMovementComponent.playerType = (i + 1);
			physicsObjectController.PhysicsObjects.Add(playerGameObject);
			Instantiate(playerGameObject, new Vector3((i + 1) * 5, 0, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
