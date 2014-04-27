using UnityEngine;
using System.Collections;

public class RatCombatScript : EnemyCombat {
	//The script for the enemy of the game Rat

	// Use this for initialization
	new void Start () {
		//Load scripts 
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.getInfo(0);
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();
		
		//Set enemies variables, these are declaired in the Enemy script
		EnemyStrength = 2;
		EnemyToughness = 3;
		EnemyDexterity = 6;
		EnemyReflex = 11;
		EnemyHealth = 30;
		xp = 250;
	}

	public new void setLevel(){
		//gets level from hero.
		characterlevel = heroScript.getInfo (0);
		//figures stats and xp out depending on level
		if (characterlevel != 1) {
			EnemyStrength = 2 + 4 * characterlevel;
			EnemyToughness = 3 + 4 * characterlevel;
			EnemyDexterity = 6 + 4.9f * characterlevel;
			EnemyReflex = 11 + 4.9f * characterlevel;
			EnemyHealth = 30 + 0.5f * characterlevel;
			xp = 250;
		}
	}

}
