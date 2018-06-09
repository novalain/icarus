using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {

    private GameObject _menuPanel;
    private bool _menuActive = false;
    private Button _mainMenuButtonCom;
	// Use this for initialization
	void Start () {
        _menuPanel = GameObject.Find("Canvas/MenuPanel");
        if (_menuPanel == null) Debug.LogError("add menu to scene with name 'MenuPanel' as a child to 'Canvas'");
        _menuPanel.SetActive(false);

        _mainMenuButtonCom = _menuPanel.transform.Find("MainMenuButton").GetComponent<Button>();
        _mainMenuButtonCom.onClick.AddListener(ReturnToMainMenu);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_menuActive)
            {
                _menuPanel.SetActive(false);
                _menuActive = false;
                Time.timeScale = 1;
            }
            else
            {
                _menuPanel.SetActive(true);
                _menuActive = true;
                Time.timeScale = 0;
            }
            
        }
	}

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
}
