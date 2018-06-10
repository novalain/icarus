using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBounds : MonoBehaviour {
    public float screenMinSize = 10;
    public float screenMaxSize = 50;


    public float playerMaxDistance = 40;
    public GameObject borderUp;
    public GameObject borderDown;
    public GameObject borderLeft;
    public GameObject borderRight;

    private GUIStyle _currentStyle;

    private Camera _cam;
    
	// Use this for initialization
	void Start () {
        _cam = Camera.main.GetComponent<Camera>();
        borderUp.transform.position = new Vector3(0, 0, playerMaxDistance);
        borderUp.transform.localScale = new Vector3(playerMaxDistance*2 + 1, 1, 1);
        borderDown.transform.position = new Vector3(0, 0, -playerMaxDistance);
        borderDown.transform.localScale = new Vector3(playerMaxDistance * 2 + 1, 1, 1);
        borderLeft.transform.position = new Vector3(-playerMaxDistance, 0, 0);
        borderLeft.transform.localScale = new Vector3(1, 1, playerMaxDistance * 2 + 1);
        borderRight.transform.position = new Vector3(playerMaxDistance, 0, 0);
        borderRight.transform.localScale = new Vector3(1, 1, playerMaxDistance * 2 +1);

    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] PlayerList = GameObject.FindGameObjectsWithTag("Player");

        float maxX = 0;
        float maxZ = 0;
        foreach(GameObject player in PlayerList)
        {
            Vector3 pos = player.transform.position;

            if (Mathf.Abs(pos.x) > maxX) maxX = Mathf.Abs(pos.x);
            if (Mathf.Abs(pos.z) > maxZ) maxZ = Mathf.Abs(pos.z);
        }
        float maxDist = Mathf.Max(maxX, maxZ);
        _cam.orthographicSize = Mathf.Min( Mathf.Max( maxDist + maxDist/3, screenMinSize), screenMaxSize);
	}
}
