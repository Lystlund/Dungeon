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
		EnemyToughness = 5;
		EnemyDexterity = 3;
		EnemyReflex = 16;
		EnemyHealth = 150;
		xp = 150;
		Debug.Log("LEVEL"+heroScript.getInfo(0));
	}

	public new void setLevel(){
		//gets level from hero.
		characterlevel = heroScript.getInfo (0);
		Debug.Log ("SETTING LEVEL"+heroScript.getInfo (0));
		//figures stats and xp out depending on level
		if (characterlevel != 1) {
			Debug.Log (heroScript.getInfo (0));
			EnemyStrength = 2 + 4 * characterlevel;
			EnemyToughness = 3 + 4 * characterlevel;
			EnemyDexterity = 6 + 4.9f * characterlevel;
			EnemyReflex = 15 + 4.9f * characterlevel;
			EnemyHealth = 30 + 0.5f * characterlevel;
			xp = 250 * (int)characterlevel;
			Debug.Log ("RAT LEVEL: " + characterlevel + " health: " + EnemyHealth);
		}
	}

}
