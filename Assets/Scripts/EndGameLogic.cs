using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameLogic : MonoBehaviour {

    public float endGameDelay = 4;

    private float endGameTimer = 0;
    private bool _isGameOver = false;
    private GameObject _endGamePanel;
    private Text _endGameText;
	// Use this for initialization
	void Start () {
        _endGamePanel = GameObject.Find("EndGamePanel");
        if (_endGamePanel == null) Debug.LogError("add canvas prefab containing EndGamePanel to scene");
        _endGameText = _endGamePanel.transform.Find("Text").GetComponent<Text>();
        if (_endGameText == null) Debug.LogError("could not find text component or gameobject of the child of EndGamePanel");
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
            string winnerName = playerList[0].name;
            _endGameText.text = winnerName + " won the game!";
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
