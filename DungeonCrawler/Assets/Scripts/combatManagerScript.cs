using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combatManagerScript : MonoBehaviour {


	private List<int> listOfEnemies = new List<int>(new int[] {0,0,0,0});
	private List<GameObject> combatEnemies =  new List<GameObject>();

	public GameObject comPlayer;
	Vector3 playerPos;

	private int numOfEnemies = 0;
	public bool inCombat = false;
	public bool combatStarted = false;
	
	// Use this for initialization
	void Start () {

		numOfEnemies = 0;

		listOfEnemies [0] = 0;
		listOfEnemies [1] = 0;
		listOfEnemies [2] = 0;
		listOfEnemies [3] = 0;

		comPlayer = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {

		if (inCombat) { //just to test if endCombat works before we actually make it possible to end it xD
			if (Input.GetKey (KeyCode.Q)) {
					endCombat ();
			}
		}
	}

	//NUMBER CODING: 1 is Spider, 2 is Rat, 3 is Zombie, 4 is Haliax.

	public void addToCombat(int opp){
		if (!inCombat) {
			listOfEnemies[numOfEnemies] = opp; //the enemy id (opp) is added into the list of enemies one at a time.

			numOfEnemies += 1; //right now we can't have more than 4 enemies in battle at once. Can easily change if we want more.
			if (numOfEnemies >= 4) {
				numOfEnemies = 0;
			}
		}
	}


	public void startCombat(){
		inCombat = true;
		combatStarted = true;

		if (combatStarted) {

			playerPos = comPlayer.transform.position;
			comPlayer.transform.position = new Vector3 (100, 0, 0); //storing player position and moving him.

			int i = 0;
			foreach (int e in listOfEnemies) {

				if(listOfEnemies [i] == 0)  { //Creates enemy of the correct type depending on the id given in the enemy list.
						Debug.Log("0!");
					}
				else if (listOfEnemies [i] == 1) {
							combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/GiantSpaceSpider")));
					}
				else if (listOfEnemies [i] == 2) {
							combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/GiantSpaceRat")));
					}
				else if (listOfEnemies [i] == 3) {
							combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/SpaceZombie")));
					}
				else if (listOfEnemies [i] == 4) {
							combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/Haliax")));
					}
				else{
					Debug.Log("ERROR: UNKNOWN ENEMY ID");
				}

				if(listOfEnemies [i] != 0)  {
					combatEnemies [i].transform.position = new Vector3 (105, 2.3f - (i*1.2f), 0); //the combat enemies are then moved to the correct position.
				}
				i++;
			}
			combatStarted = false;
		}

	}


	public void endCombat(){
		comPlayer.transform.position = playerPos;

		foreach (int l in listOfEnemies) { //this probably doesn't work yet... but nvm for right now. Will figure out later.
			listOfEnemies[l] = 	0;
		}

		inCombat = false;
	}


}
