using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerFindSceneLogic : MonoBehaviour {
    public float goToGameTime = 10;
    public Text timerTextObj;

    private float _goToGameTimer;
	// Use this for initialization
	void Start () {
        _goToGameTimer = goToGameTime;
	}
	
	// Update is called once per frame
	void Update () {
        _goToGameTimer -= Time.deltaTime;

        timerTextObj.text = "Game starting in: " + (int)_goToGameTimer;

        if (_goToGameTimer <= 0)
        {
            //Go to game scene
            SceneManager.LoadScene(GlobalData.gameScene);
        }
	}
}
