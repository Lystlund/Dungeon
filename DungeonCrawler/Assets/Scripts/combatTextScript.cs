using UnityEngine;
using System.Collections;

public class combatTextScript : MonoBehaviour {

	//This is the script that controls the text at the bottom of the window during combat.

	GameObject hero;			//Variables
	HeroMovement heroScript;

	GameObject comMan;
	combatManagerScript combatScript;

	GUIText[] texts;
	GUIText heroText;
	GUIText enemyText;
	GUIText enemyDamText;
	GUIText heroDamText;
	string enemyHealth;


	// Use this for initialization
	void Start () {

		hero = GameObject.FindGameObjectWithTag ("Player");		//Initializing gameobjects and scripts.
		heroScript = hero.GetComponent<HeroMovement> ();
		comMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = comMan.GetComponent<combatManagerScript>();

		//enemyTextObject = Find
		texts = GetComponentsInChildren<GUIText>();		//Figuring out which script belongs to which variable through this array and 4 for-loops, checking for each script name.

		for(int i=0;i<4;i++){
			if(texts[i].name == "enemyText"){
				enemyText = texts[i];
			}
		}
		for(int i=0;i<4;i++){
			if(texts[i].name == "heroText"){
				heroText = texts[i];
			}
		}
		for(int i=0;i<4;i++){
			if(texts[i].name == "enemyDamText"){
				enemyDamText = texts[i];
			}
		}
		for(int i=0;i<4;i++){
			if(texts[i].name == "heroDamText"){
				heroDamText = texts[i];
			}
		}


		guiTexture.color = Color.clear;		//Since the game does not start in combat, the text needs to be invisible.
		guiTexture.enabled = false;
		enemyText.color = Color.clear;
		heroText.color = Color.clear;
		enemyDamText.color = Color.clear;
		heroDamText.color = Color.clear;


	}


	public void UpdateText(float type){	//This function is called at specific times during combat, when meaningful things have changed. This is to avoid it running in Update or other constantly running function.

		if(combatScript.inCombat){		//First we check if we're in combat. If so, the text is shown, if not it is invisible again.
			guiTexture.color = Color.black;
			guiTexture.enabled = true;
			enemyText.color = Color.white;
			heroText.color = Color.white;
			enemyDamText.color = Color.white;
			heroDamText.color = Color.white;
		}
		if(!combatScript.inCombat){
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			enemyText.color = Color.clear;
			heroText.color = Color.clear;
			enemyDamText.color = Color.clear;
			heroDamText.color = Color.clear;
		}


		heroText.text = "HERO: Health: "+(int)combatScript.heroHealth;
		enemyText.text = "LAST ENEMY HIT Health: "+(int)combatScript.seeHealth();

		if(combatScript.combatStarted){
		enemyDamText.text = "PLAYER TURN. Enemies Waiting";		//The fact that it is the player's turn is only displayed in the beginning of combat, because it is more valuable to display the enemy health afterwards.
		}

		if(type == 0){		//the "type" variable is used to determine where in combat we are and therefore decide what to write. type is sent as parameter when the function is called.
			heroDamText.text = "Press [SPACE] to Initiate Combat Systems.";
		}
		else if(type == 1){
			heroDamText.text = "Select Enemy to Engage with. Use [1-4] commands.";
		}
		else if(type == 2){
			heroDamText.text = "Damage to enemy: "+(int)combatScript.damage;
		}
		else if(type == 3){
			heroDamText.text = "HERO MISS.";
		}
		else if(type == 4){
			//heroDamText.text = "HERO MISS.";
			enemyDamText.text = "Enemy Damage to Hero: "+(int)combatScript.eDamage;
		}
		else if(type == 5){
			//heroDamText.text = "HERO MISS.";
			enemyDamText.text = "ENEMY MISS.";
		}



	}



}
