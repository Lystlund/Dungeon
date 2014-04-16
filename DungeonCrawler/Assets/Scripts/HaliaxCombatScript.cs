using UnityEngine;
using System.Collections;

public class HaliaxCombatScript : EnemyCombat {

	// Use this for initialization
	void Start () {
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.heroLevel;
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();
	
		EnemyStrength = 25;
		EnemyToughness = 25;
		EnemyDexterity = 25;
		EnemyReflex = 25;
		EnemyHealth = 2500;
		xp = 2500;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
