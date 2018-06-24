using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuMatchMaker : MonoBehaviour {
    public bool showGUI;
    public NetworkManager manager;

    public GameObject serverButton;
    public GameObject onlineMenuTransform;
    public GameObject hostButton;
    public GameObject matchNameInput;

    private bool matchesFound = false;


    void Awake()
    {

        
    }


    // Use this for initialization
    void Start () {
        manager = GetComponent<NetworkManager>();

        hostButton.GetComponent<Button>().onClick.AddListener(delegate { HostMatch(); });
    }
	
	// Update is called once per frame
	void Update () {
        if (manager.matches != null && !matchesFound)
        {
            matchesFound = true;
            //create current match buttons

            int xpos = 10;
            int ypos = 0;
            int spacing = 10;

            foreach (var match in manager.matches)
            {
                GameObject newButton = Instantiate(serverButton, onlineMenuTransform.transform);
                newButton.transform.position += new Vector3(0, -ypos, 0); 
                Button button = newButton.GetComponent<Button>();
                button.onClick.AddListener(delegate { OnClickServerButton(match); });
                newButton.transform.Find("Text").GetComponent<Text>().text = match.name;
                ypos += spacing;
            }
        }
    }

    public void findMatches()
    {
        manager.StartMatchMaker();   
        manager.matchMaker.ListMatches(0, 20,  "", false, 0, 0, manager.OnMatchList);
    }

    public void OnClickServerButton(UnityEngine.Networking.Match.MatchInfoSnapshot match)
    {
        manager.matchName = match.name;
        manager.matchSize = (uint)match.currentSize;
        manager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, manager.OnMatchJoined);
    } 



    public void HostMatch()
    {
        manager.matchSize = 4;
        manager.matchName = matchNameInput.GetComponent<InputField>().text;
        manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);
    }
}
