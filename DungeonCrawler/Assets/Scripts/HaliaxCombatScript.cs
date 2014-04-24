using UnityEngine;
using System.Collections;

public class HaliaxCombatScript : EnemyCombat {
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
		EnemyStrength = 25;
		EnemyToughness = 25;
		EnemyDexterity = 25;
		EnemyReflex = 25;
		EnemyHealth = 2500;
		xp = 2500;
	}

	//The boss' level is constant so this doesn't need to change anything.
	public new void setLevel(){
	}
}
