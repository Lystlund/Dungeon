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
		EnemyStrength = 3;
		EnemyToughness = 3;
		EnemyDexterity = 6;
		EnemyReflex = 5;
		EnemyHealth = 100;
		xp = 100;
	
	}

}
