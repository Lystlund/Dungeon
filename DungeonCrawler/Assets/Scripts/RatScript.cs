using UnityEngine;
using System.Collections;

public class RatScript : Enemy {
	

	// Use this for initialization
	void Start () {
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.heroLevel;
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();

		id = 2;

		EnemyStrength = 2;
		EnemyToughness = 5;
		EnemyDexterity = 3;
		EnemyReflex = 16;
		EnemyHealth = 150;
		xp = 150;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (characterlevel);
	
	}
}
