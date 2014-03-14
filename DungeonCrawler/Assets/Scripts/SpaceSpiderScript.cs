using UnityEngine;
using System.Collections;

public class SpaceSpiderScript : Enemy {

	public GameObject hero;
	HeroMovement heroScript;
	float characterlevel;

	// Use this for initialization
	void Start () {

		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.heroLevel;


		EnemyStrength = 3;
		EnemyToughness = 3;
		EnemyDexterity = 6;
		EnemyReflex = 5;
		EnemyHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (characterlevel);
	
	}
}
