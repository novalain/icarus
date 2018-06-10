using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfPlayersPicker : MonoBehaviour {
    public int numberOfPlayers = 4;
    public Button morePlayersButton;
    public Button lessPlayersButton;
    public Text numberOfPlayersText;
	// Use this for initialization
	void Start () {
        numberOfPlayersText.text = "Players: " + numberOfPlayers;
	}
	
	// Update is called once per frame
	void Update () {
        GlobalData.numPlayers = numberOfPlayers;
	}

    public void RemovePlayer()
    {
        if (numberOfPlayers > 2) numberOfPlayers -= 1;
        numberOfPlayersText.text = "Players: " + numberOfPlayers;
    }

    public void AddPlayer()
    {
        if (numberOfPlayers < 4) numberOfPlayers += 1;
        numberOfPlayersText.text = "Players: " + numberOfPlayers;
    }
}
