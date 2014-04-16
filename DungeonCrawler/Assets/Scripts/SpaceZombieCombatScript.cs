using UnityEngine;
using System.Collections;

public class SpaceZombieCombatScript : EnemyCombat {

	// Use this for initialization
	void Start () {
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.heroLevel;
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();
		

		EnemyStrength = 6;
		EnemyToughness = 6;
		EnemyDexterity = 1;
		EnemyReflex = 1;
		EnemyHealth = 300;
		xp = 300;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
