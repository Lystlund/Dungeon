using UnityEngine;
using System.Collections;

public class EnemyCombat : MonoBehaviour {

	//The EnemyCombat script is a copy of the Enemy script, but instead of being the enemy that is in the dungeon, it is the enemy that is spawned in combat. Therefore it fx does not have the collision.

	public GameObject hero;
	public HeroMovement heroScript;

	public float characterlevel;
	public float EnemyStrength;
	public float EnemyToughness;
	public float EnemyDexterity;
	public float EnemyReflex;
	public float EnemyHealth;
	public GameObject combatMan;
	public combatManagerScript combatScript;
	public int xp;
	public bool alive;


	// Use this for initialization
	void Start () {
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();
		
		
		alive = true;
	
	}

}
