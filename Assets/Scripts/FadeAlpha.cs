using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAlpha : MonoBehaviour {
	[SerializeField] private float fadePerSecond = 2.5f;
	private float direction = -1.0f;
         
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Material material = GetComponent<Renderer>().material;
		Color color = GetComponent<Renderer>().material.color;
       // material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));	

		if (color.a <= 0.3f) {
			direction = 1.0f;
		} else if (color.a >= 1.0f) {
			direction = -1.0f;
		}

		material.color = new Color(color.r, color.g, color.b, color.a + direction * (0.5f * fadePerSecond * Time.deltaTime));
	}
}
