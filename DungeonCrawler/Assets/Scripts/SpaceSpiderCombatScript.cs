using UnityEngine;
using System.Collections;

public class SpaceSpiderCombatScript : EnemyCombat {
	//The script for the enemy of the game Spider

	// Use this for initialization
	new void Start () {
		//Load scripts 
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.getInfo(0);
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();
		
		//Set enemies variables, these are declaired in the Enemy script
		EnemyStrength = 5;
		EnemyToughness = 3;
		EnemyDexterity = 4;
		EnemyReflex = 5;
		EnemyHealth = 50;
		xp = 400;
	
	}

	public new void setLevel(){
		//sets level
		characterlevel = heroScript.getInfo (0);
		Debug.Log ("SETTING LEVEL"+heroScript.getInfo (0));
		//figures stats and xp out depending on level
		if (characterlevel != 1) {
			Debug.Log (heroScript.getInfo (0));
			EnemyStrength = 5 + 4.7f * characterlevel;
			EnemyToughness = 3 + 4.7f * characterlevel;
			EnemyDexterity = 4 + 4.7f * characterlevel;
			EnemyReflex = 5 + 4.7f * characterlevel;
			EnemyHealth = 50 + 1f * characterlevel;
			xp = 400;
			Debug.Log ("SPIDER LEVEL: " + characterlevel + " health: " + EnemyHealth);
		}
	}
}
