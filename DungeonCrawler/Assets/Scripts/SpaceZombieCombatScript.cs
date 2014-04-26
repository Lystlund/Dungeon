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
		EnemyStrength = 10;
		EnemyToughness = 10;
		EnemyDexterity = 2;
		EnemyReflex = 2;
		EnemyHealth = 100;
		xp = 500;

	
	}

	public new void setLevel(){
		//sets level
		characterlevel = heroScript.getInfo (0);
		Debug.Log ("SETTING LEVEL"+heroScript.getInfo (0));
		//figures stats and xp out depending on level
		if (characterlevel != 1) {
			Debug.Log (heroScript.getInfo (0));
			EnemyStrength = 10 + 4.9f * characterlevel;
			EnemyToughness = 10 + 4.9f * characterlevel;
			EnemyDexterity = 2 + 5.05f * characterlevel;
			EnemyReflex = 2 + 5.05f * characterlevel;
			EnemyHealth = 100 + 2f * characterlevel;
			xp = 400 * (int)characterlevel;
			Debug.Log ("SPIDER LEVEL: " + characterlevel + " health: " + EnemyHealth);
		}
	}

}
