using UnityEngine;
using System.Collections;

public class SpaceZombieCombatScript : EnemyCombat {
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
		EnemyStrength = 6;
		EnemyToughness = 6;
		EnemyDexterity = 1;
		EnemyReflex = 1;
		EnemyHealth = 300;
		xp = 300;

	
	}

}
