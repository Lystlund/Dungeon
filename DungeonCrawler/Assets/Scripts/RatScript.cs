using UnityEngine;
using System.Collections;

public class RatScript : Enemy {

	public GameObject hero;
	HeroMovement heroScript;
	float characterlevel;

	// Use this for initialization
	void Start () {
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.heroLevel;

		EnemyStrength = 2;
		EnemyThoughness = 5;
		EnemyDexterity = 3;
		EnemyReflex = 16;
		EnemyHealth = 150;
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (EnemyStrength);
	
	}
}
