using UnityEngine;
using System.Collections;

public class SpaceSpiderCombatScript : EnemyCombat {

	// Use this for initialization
	void Start () {
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.heroLevel;
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();
		
	
		EnemyStrength = 3;
		EnemyToughness = 3;
		EnemyDexterity = 6;
		EnemyReflex = 5;
		EnemyHealth = 100;
		xp = 100;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
