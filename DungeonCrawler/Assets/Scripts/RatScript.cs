using UnityEngine;
using System.Collections;

public class RatScript : Enemy {
	//The script for the enemy of the game Rat

	// Use this for initialization
	void Start () {
		//Load scripts 
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.getInfo(0);
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();

		//Set enemies variables, these are declaired in the Enemy script
		id = 2;
		EnemyStrength = 2;
		EnemyToughness = 5;
		EnemyDexterity = 3;
		EnemyReflex = 16;
		EnemyHealth = 150;
		xp = 150;
	
	}

}
