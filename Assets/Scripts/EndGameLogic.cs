using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameLogic : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        if (playerList.Length <= 1)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
	}
}
