using UnityEngine;
using System.Collections;

public class SpaceZombie : Enemy {
	//The script for the enemy of the game Zombie

	// Use this for initialization
	new void Start () {
		//Load scripts 
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.getInfo(0);
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();

		//Set enemies variables, these are declaired in the Enemy script
		id = 3;
		EnemyStrength = 10;
		EnemyToughness = 10;
		EnemyDexterity = 2;
		EnemyReflex = 2;
		EnemyHealth = 100;
		xp = 500;
	
	}

}
