using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayersManager : MonoBehaviour {
	private static readonly Color[] PLAYER_COLORS = { Color.red, Color.green, Color.blue, Color.yellow };

	// Use this for initialization
	void Start () {
		PhysicsObjectController physicsObjectController = GetComponent<PhysicsObjectController>();
		for (int i = 0; i < GlobalData.numPlayers; ++i) {
			GameObject playerGameObject = (GameObject)Resources.Load("Prefabs/Player", typeof(GameObject));
			
			// Set unique color and name
			playerGameObject.name = "Player " + (i + 1);
					
			PlayerMovement playerMovementComponent = playerGameObject.GetComponent<PlayerMovement>();
			playerMovementComponent.playerType = (i + 1);
			physicsObjectController.PhysicsObjects.Add(playerGameObject);

			GameObject go = Instantiate(playerGameObject, new Vector3((i + 1) * 5, 0, 0), Quaternion.identity);	
			go.GetComponent<MeshRenderer>().material.SetColor("_Color", PLAYER_COLORS[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}