using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	//Declaring the variables 
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

	bool decideMove = true;
	bool moving = false;
	float timer;
	Vector3 targetDest = Vector3.zero;


	// Use this for initialization
	public void Start ()
	{
		//loading scripts
		hero = GameObject.FindWithTag ("Player");
		heroScript = hero.GetComponent<HeroMovement> ();
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();
	}

	void Update(){ 

		timer += Time.deltaTime;
		if (decideMove && id != 3 && id!= 4) { //Deciding to move set a new target direction to move in, which the enemy moves in for a random amount of time.

			targetDest = transform.InverseTransformDirection(Random.Range (-5, 5), Random.Range (-5, 5), 0);
			Vector3 dir = targetDest - transform.position;
			float angle = Mathf.Atan2(targetDest.y,targetDest.x) * Mathf.Rad2Deg-180;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Rotation is set to be the direction it is walking in.

			decideMove = false; //when direction is chosen, it will not be reset until it is done moving.
			moving = true;
		}
		if (moving) {
			transform.rigidbody.velocity = targetDest.normalized;
			int threshold = Random.Range(2,8); //This threshold decides how long it will take before the enemy should change direction. This is random.
				if(timer > threshold){
				timer = 0;
				moving = false; //booleans and timer reset.
				decideMove = true;
			}
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
		if (col.gameObject.tag == "Wall"){
			moving = false;
			decideMove = true;
		}

	}
}

