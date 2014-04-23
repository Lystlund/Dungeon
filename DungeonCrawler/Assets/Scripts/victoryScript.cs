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

		DontDestroyOnLoad (transform.gameObject);

		hero = GameObject.FindGameObjectWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();	
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 2 && !textSet) {
			info = GameObject.Find ("info");
			vicInfo = info.GetComponent<victoryScript2> ();
			textSet = true;
			printInfo();
		}
	}

	
	public void setInfo(){
		level = heroScript.heroLevel;
		Application.LoadLevel (2);
	}

	void printInfo(){
		vicInfo.setText (level);
	}

}
