using UnityEngine;
using System.Collections;

public class Haliax : Enemy {
	//The script for the boss of the game Haliax

	// Use this for initialization
	new void Start () {
		//Load scripts 
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.getInfo(0);
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();

		//Set enemies variables, these are declaired in the Enemy script
		id = 4;
		EnemyStrength = 105;
		EnemyToughness = 105;
		EnemyDexterity = 105;
		EnemyReflex = 105;
		EnemyHealth = 200;
		xp = 2500;
	
	}

}
