using UnityEngine;
using System.Collections;

public class Haliax : Enemy {

	public GameObject hero;
	HeroMovement heroScript;
	float characterlevel;

	// Use this for initialization
	void Start () {
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		characterlevel = heroScript.heroLevel;
		
		EnemyStrength = 25;
		EnemyToughness = 25;
		EnemyDexterity = 25;
		EnemyReflex = 25;
		EnemyHealth = 2500;
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (EnemyStrength);
	
	}
}
