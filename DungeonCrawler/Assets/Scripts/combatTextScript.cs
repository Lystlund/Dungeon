using UnityEngine;
using System.Collections;

public class combatTextScript : MonoBehaviour {

	GameObject hero;
	HeroMovement heroScript;

	GameObject comMan;
	combatManagerScript combatScript;

	public GUIText[] texts;
	GUIText heroText;
	GUIText enemyText;
	GUIText enemyDamText;
	GUIText heroDamText;
	string enemyHealth;


	// Use this for initialization
	void Start () {

		hero = GameObject.FindGameObjectWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();

		comMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = comMan.GetComponent<combatManagerScript>();

		//enemyTextObject = Find
		texts = GetComponentsInChildren<GUIText>();

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


		guiTexture.color = Color.clear;
		guiTexture.enabled = false;
		enemyText.color = Color.clear;
		heroText.color = Color.clear;
		enemyDamText.color = Color.clear;
		heroDamText.color = Color.clear;


	}
	
	// Update is called once per frame
	void Update () {
	
	}





	public void UpdateText(float type){
		Debug.Log("TEXT UPDATED");

		if(combatScript.inCombat){
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


		heroText.text = "HERO: Health: "+heroScript.Health;
		enemyText.text = "LAST ENEMY HIT Health: "+combatScript.seeHealth();

		if(combatScript.combatStarted){
		enemyDamText.text = "PLAYER TURN. Enemies Waiting";
		}

		if(type == 0){
			heroDamText.text = "Press [SPACE] to Initiate Combat Systems.";
		}
		else if(type == 1){
			heroDamText.text = "Select Enemy to Engage with. Use [1-4] commands.";
		}
		else if(type == 2){
			heroDamText.text = "Damage to enemy: "+combatScript.damage;
		}
		else if(type == 3){
			heroDamText.text = "HERO MISS.";
		}
		else if(type == 4){
			//heroDamText.text = "HERO MISS.";
			enemyDamText.text = "Enemy Damage to Hero: "+combatScript.eDamage;
		}
		else if(type == 5){
			//heroDamText.text = "HERO MISS.";
			enemyDamText.text = "ENEMY MISS.";
		}



	}



}
