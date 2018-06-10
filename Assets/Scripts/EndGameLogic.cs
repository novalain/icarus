using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameLogic : MonoBehaviour {

    public float endGameDelay = 4;

    private float endGameTimer = 0;
    private bool _isGameOver = false;
    private GameObject _endGamePanel;
	// Use this for initialization
	void Start () {
        _endGamePanel = GameObject.Find("EndGamePanel");
        if (_endGamePanel == null) Debug.LogError("add canvas prefab containing EndGamePanel to scene");
        _endGamePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        if (playerList.Length <= 1 && !_isGameOver)
        {
            _isGameOver = true;
            endGameTimer = endGameDelay;
            _endGamePanel.SetActive(true);
            
            //SceneManager.LoadScene("MainMenuScene");
        }

        if (_isGameOver)
        {
            endGameTimer -= Time.deltaTime;
            if (endGameTimer <= 0)
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }


	}


}
