using UnityEngine;
using System.Collections;

public class levelScript : MonoBehaviour {

	int level;
	
	GameObject hero;
	HeroMovement heroScript;

	// Use this for initialization
	void Start () {
		hero = GameObject.FindGameObjectWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();	
	
	}
	
	// Update is called once per frame
	void Update () {

		guiText.text = "Level: " + heroScript.getInfo (0);
	
	}
}
