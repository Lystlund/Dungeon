using UnityEngine;
using System.Collections;

public class victoryScript : MonoBehaviour {

	public int level;

	GameObject hero;
	HeroMovement heroScript;

	GameObject info;
	victoryScript2 vicInfo;

	bool textSet = false;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (transform.gameObject);	//This object is meant to be kept when the Victory Scene is loaded so it is forced to not be destroyed on load.

		hero = GameObject.FindGameObjectWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();	
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 2 && !textSet) {		//Checking when we are in victory scene, and if so: initializing the victoryscript2 and printing the info.
			info = GameObject.Find ("info");
			vicInfo = info.GetComponent<victoryScript2> ();
			textSet = true;
			printInfo();
		}
	}

	
	public void setInfo(){		//Info is set and the Victory scene is loaded. This function is called when the game is won.
		level = heroScript.heroLevel;
		Application.LoadLevel (2);
	}

	void printInfo(){
		vicInfo.setText (level);
	}

}
