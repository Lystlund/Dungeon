using UnityEngine;
using System.Collections;

public class SpaceZombie : Enemy {

	public GameObject hero;
	HeroMovement heroScript;
	float characterlevel;

	// Use this for initialization
	void Start () {
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.heroLevel;
		
		EnemyStrength = 6;
		EnemyToughness = 6;
		EnemyDexterity = 1;
		EnemyReflex = 1;
		EnemyHealth = 300;
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (EnemyStrength);
	
	}
}
