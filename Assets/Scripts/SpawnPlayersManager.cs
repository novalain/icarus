using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayersManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		PhysicsObjectController physicsObjectController = GetComponent<PhysicsObjectController>();
		for (int i = 0; i < GlobalData.numPlayers; ++i) {
			GameObject player = (GameObject)Resources.Load("Prefabs/Player", typeof(GameObject));
			player.name = "Player " + i;
			physicsObjectController.PhysicsObjects.Add(player);
			Instantiate(player, new Vector3((i + 1) * 5, 0, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
