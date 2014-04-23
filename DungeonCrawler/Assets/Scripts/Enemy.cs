using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public GameObject hero;
	public HeroMovement heroScript;
	public float characterlevel;
	protected int numToCombat;
	protected int id;

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
	public void Start ()
	{
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();


		alive = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log (characterlevel);
		if (alive == false)
		{
			heroScript.xp = heroScript.xp + xp;
		}
	}

	void OnTriggerEnter(Collider other)
	{	
		if(other.gameObject.tag == "Enemy")
		{
			alive = false;
		}
	}

	//Collision. Starts combat with 1-4 enemies if collision is with player.
	protected virtual void OnCollisionEnter(Collision col){
		if (col.gameObject == GameObject.FindGameObjectWithTag ("Player")) {
			numToCombat = Random.Range(1,5);	//picks a random number between 1 and 4. This decides how many enemies there will be in the combat

			if(id==4){ //checks if it is the boss. If so, it should only ever spawn 1.
				combatScript.addToCombat(id);
			}
			else{
				for(int i = 0; i<numToCombat; i++){ //other cases it runs addToCombat (function in combatManagerScript) random number of times, to add enemies to combat.
					combatScript.addToCombat(id);
				}
			}
			combatScript.startCombat(); //combat starts and gameobject in the level is destroyed.
			Destroy(this.gameObject); //the enemy in the dungeon is destroyed.
		}

	}

}

