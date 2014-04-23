using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combatManagerScript : MonoBehaviour {
	
	GameObject cText;				//Variables.
	combatTextScript t;

	GameObject vic;
	victoryScript vScript;

	public GameObject hero;
	public HeroMovement heroScript;
	public SpaceZombieCombatScript zombie;
	public SpaceSpiderCombatScript spider;
	public HaliaxCombatScript haliax;
	public RatCombatScript rat;

	private List<int> listOfEnemies = new List<int>(new int[] {0,0,0,0});		//The two arrays used to see which enemies there are..
	public List<GameObject> combatEnemies =  new List<GameObject>();

	public GameObject comPlayer;
	Vector3 playerPos;

	private int numOfEnemies = 0;
	public bool inCombat = false;
	public bool combatStarted = false;
	bool CombatInitiate=false;
	bool PlayerTurn=true;
	bool giveDam = false;
	bool healthGiven = false;
	int typeofEnemy;
	public float enemyhptotal = 0;
	float[] enemyHps = new float[4] {0,0,0,0};	//health array used to track all of the enemies' health. This means that the health in combat is a temporary thing for each combat encounter.
	int turn = 0;
	int enemyHit;
	public float damage;
	public float eDamage;




	
	// Use this for initialization
	void Start () {

		numOfEnemies = 0;

		listOfEnemies [0] = 0;
		listOfEnemies [1] = 0;
		listOfEnemies [2] = 0;
		listOfEnemies [3] = 0;

		comPlayer = GameObject.FindGameObjectWithTag ("Player");
		heroScript = comPlayer.GetComponent<HeroMovement> ();

		cText = GameObject.Find ("combatTextBox");
		t = cText.GetComponent<combatTextScript>();

		vic = GameObject.Find ("VictoryConditionObject");
		vScript = vic.GetComponent<victoryScript>();


	}
	
	// Update is called once per frame
	void Update () {

		if (inCombat) { //just to test if endCombat works before we actually make it possible to end it xD
			if (Input.GetKey (KeyCode.Q)) {
					endCombat (false);
			}
		}

		if(inCombat){
			Combat(); //runs the combat function every frame when in combat.
		}
	}






	//addToCombat and startCombat is executed by enemyscript collision.

	public void addToCombat(int opp){ //function runs as many times as there will be enemies (defined in enemyscript)
		if (!inCombat) {
			listOfEnemies[numOfEnemies] = opp; //the enemy id (opp) is added into the list of enemies one at a time. 
			numOfEnemies += 1; 					//right now we can't have more than 4 enemies in battle at once.
												//the enemies' id is set into the array listOfEnemies, which is used later to spawn them.

			if (numOfEnemies > 4) {	//failsafe. There should never be more than 4 enemies.
				numOfEnemies = 0;
			}
		}
	}


	public void startCombat(){ //Spawns enemies and moves player.
		inCombat = true;
		combatStarted = true;
		t.UpdateText(0);		//Combat screen is set, so the bools are set to true and the text will appear via the updateText() function.

		if (combatStarted) {
			playerPos = comPlayer.transform.position;			//storing player position (for return) and moving him.
			comPlayer.transform.position = new Vector3 (100, 0, 0); 


			//The number coding for the enemies is as follows: 1 is Spider, 2 is Rat, 3 is Zombie, 4 is Haliax.

			int i = 0;
			foreach (int e in listOfEnemies) {	//for each enemy in listofEnemies, it will create a gameobject of the appropriate type and spawn it in combat.
				if(listOfEnemies [i] == 0)  { //Checks enemy id given in the enemy list.
						combatEnemies.Add(null); //if zero, gameobject is set to null. this is used to track if there isn't an enemy at a position.
					}
				else if (listOfEnemies [i] == 1) {
					combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/GiantSpaceSpiderCombat")));
					spider = combatEnemies[i].GetComponent<SpaceSpiderCombatScript>();
					typeofEnemy = 1;	//numbercoding used throughout the combat script.
					}
				else if (listOfEnemies [i] == 2) {
					combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/GiantSpaceRatCombat")));
					rat = combatEnemies[i].GetComponent<RatCombatScript>();
					typeofEnemy = 2;
					}
				else if (listOfEnemies [i] == 3) {
					combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/SpaceZombieCombat")));
					zombie = combatEnemies[i].GetComponent<SpaceZombieCombatScript>();
					typeofEnemy = 3;
					}
				else if (listOfEnemies [i] == 4) {
					combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/HaliaxCombat")));
					haliax = combatEnemies[i].GetComponent<HaliaxCombatScript>();
					typeofEnemy = 4;
					}
				else{
				}

				if(listOfEnemies [i] != 0)  { //moves enemies to appropriate positions
					combatEnemies [i].transform.position = new Vector3 (105, 2.3f - (i*1.2f), 0);
				}
				i++;
			}

			combatStarted = false;
		}

	}




// ----------------------------------------------- COMBAT --------------------------------------------------------------------- //


	public void Combat (){

		if (!healthGiven) { //gives the appropriate health to enemies at the start of combat. Had to do it here, because the above function didn't register the correct health, for some reason.
			int j = 0;		//it will only do it once, though because of the healthGiven boolean.
			foreach (GameObject g in combatEnemies) {	 //sets 
				if (typeofEnemy == 1 && combatEnemies[j] != null)
					enemyHps [j] = spider.EnemyHealth; //health of the enemy is set to fit the correct amount from the correct enemy script.
				else if (typeofEnemy == 2 && combatEnemies[j] != null)
						enemyHps [j] = rat.EnemyHealth;
				else if (typeofEnemy == 3 && combatEnemies[j] != null)
						enemyHps [j] = zombie.EnemyHealth;
				else if (typeofEnemy == 4 && combatEnemies[j] != null)
						enemyHps [j] = haliax.EnemyHealth;
				j++;
			}
			healthGiven = true;
			t.UpdateText(0);
		}

		GameObject HitEnemy = combatEnemies[0];	//used to determine which enemy is being hit.



	// ---------------------------------------- PLAYER TURN

		if (PlayerTurn==true){ //the player starts combat.
			if (CombatInitiate==false){
				if (Input.GetKeyUp(KeyCode.Space)){ //space iniates that the player wants to attack.
					CombatInitiate=true; 
					t.UpdateText(1);
				}
			}
			if (CombatInitiate==true){ //a keycode 1-4 defines which enemy the player wants to attack.
				if (Input.GetKey(KeyCode.Alpha1) && combatEnemies[0] != null){		//combatEnemies needs to not be null because it is only when there is an enemy at the position that the player should be allowed to attack it.
					HitEnemy=combatEnemies[0];
					CombatInitiate = false;
					giveDam = true;
					enemyHit = 0;
				}
				else if (Input.GetKey(KeyCode.Alpha2) && combatEnemies[1] != null){
					HitEnemy=combatEnemies[1];
					CombatInitiate = false;
					giveDam = true;
					enemyHit = 1;

				} else if (Input.GetKey(KeyCode.Alpha3) && combatEnemies[2] != null){
					HitEnemy=combatEnemies[2];
					CombatInitiate = false;
					giveDam = true;
					enemyHit = 2;

				} else if (Input.GetKey(KeyCode.Alpha4) && combatEnemies[3] != null){
					HitEnemy=combatEnemies[3];
					CombatInitiate = false;
					giveDam = true;
					enemyHit = 3;
				}
			}

			if (giveDam==true){ //when the enemy has been defined the damage rolls will be done.
				float eReflex = 0;
				float eToughness = 0; //first, the needed variables are created...
				float eLevel = 0;

				if(typeofEnemy==1){  //.. and filled with the appropriate numbers, depending on enemytype.
					eReflex = spider.EnemyReflex;
					eToughness = spider.EnemyToughness;
					eLevel = spider.characterlevel;
				}
				else if (typeofEnemy==2){
					eReflex = rat.EnemyReflex;
					eToughness = rat.EnemyToughness;
					eLevel = rat.characterlevel;
				}
				else if (typeofEnemy==3){
					eReflex = zombie.EnemyReflex;
					eToughness = zombie.EnemyToughness;
					eLevel = zombie.characterlevel;
				}
				else if (typeofEnemy==4){
					eReflex = haliax.EnemyReflex;
					eToughness = haliax.EnemyToughness;
					eLevel = haliax.characterlevel;
				}


				//The algorithms used for combat are as such (d20 means roll with d20 die): chance to hit: if (d20+attdex+(attlvl/2))>= (10+defrex+(deflvl/2))
														 	//damage = (d20+attstr+(attlvl/2))-(deftgh+(deflvl/2))
				 //Then, the actual damage calculation is done. 
				if((Random.Range (1,20)+heroScript.Dexterity+(heroScript.heroLevel/2))>=(10+eReflex+(eLevel/2))){ //first a chance to hit, and if it passes.. 
					damage = (Random.Range (1,20)+heroScript.Strength+(heroScript.heroLevel/2))-(eToughness+(eLevel/2)); //..damage is calculated.
					if (damage < 0){ //damage cannot be lower than zero.
						damage = 0;
					}

					int i = 0;
					foreach(GameObject g in combatEnemies){
						if(HitEnemy==combatEnemies[i]){
							enemyHps[i] -= damage; //damage is subtracted from enemy's health.
							if(enemyHps[i]<0){
								enemyHps[i]=0;
							}
						}
						i++;
					}
					t.UpdateText(2);
				}
				else{
					t.UpdateText(3);
				}

				enemyhptotal = enemyHps[0]+enemyHps[1]+enemyHps[2]+enemyHps[3]; //total enemy health is calculated.

				int j = 0;
				foreach(GameObject g in combatEnemies){
					if(enemyHps[j]<=0){ //if there are any enemies with 0 health, they are destroyed.
						Destroy(combatEnemies[j]);
					}
					j++;
				}

				if (enemyhptotal <= 0){ //if all enemies have 0 health, combat ends, with the player winning.
					endCombat(false);
				}

				giveDam = false;
				PlayerTurn = false;
			}

		} //Player turn END




	// ------------------------------------------ ENEMY TURN

		if (PlayerTurn!=true){

				float eStrength = 0;
				float eDexterity = 0;
				float eLevel = 0;
				
				if(typeofEnemy==1){
					eStrength = spider.EnemyStrength;
					eDexterity = spider.EnemyDexterity;
					eLevel = spider.characterlevel;
					
				}
				else if (typeofEnemy==2){
					eStrength = rat.EnemyStrength;
					eDexterity = rat.EnemyDexterity;
					eLevel = rat.characterlevel;
				}
				else if (typeofEnemy==3){
					eStrength = zombie.EnemyStrength;
					eDexterity = zombie.EnemyDexterity;
					eLevel = zombie.characterlevel;
				}
				else if (typeofEnemy==4){
					eStrength = haliax.EnemyStrength;
					eDexterity = haliax.EnemyDexterity;
					eLevel = haliax.characterlevel;
				}

			//And once again, damage is calcuted, using the name principles, only in reverse.
			if((Random.Range (1,20)+eDexterity+(eLevel/2))>=(10+heroScript.Reflex+(heroScript.heroLevel/2))){
				eDamage = (Random.Range (1,20)+eStrength+(eLevel/2))-(heroScript.Toughness+(heroScript.heroLevel/2));
				if (eDamage < 0){
					eDamage = 0;
				}
				heroScript.Health-=eDamage;

				if(heroScript.Health<=0){ //if the hero has 0 health, the combat ends, with the hero dead.
					endCombat(true);

				}
				t.UpdateText(4);
			}
			else{
				t.UpdateText(5);
			}
			PlayerTurn=true;

			turn++; //turn is incremented when the enemy has had it's turn.
		
		} //Enemy turn END

	} //Combat loop END






// ------------------------------------------------ COMBAT END ------------------------ //

	public void endCombat(bool heroDeath){ //parameter decides if the hero won or lost combat.

		if (heroDeath) { //checks if it was the hero's death of enemies' death that triggered endCombat.
			//this ends combat with the hero losing. Therefore the game will end, loading the menu scene.
			Application.LoadLevel(0);
			} 
		else {
			//this ends combat with the hero winning.

			if (typeofEnemy == 1){		//Gives the correct amount of xp to the hero, depending on the type and amount of enemies.
				heroScript.xp = heroScript.xp + spider.xp*numOfEnemies;
				Debug.Log("Xp: " + heroScript.xp);
			}
			if (typeofEnemy == 2){
				heroScript.xp = heroScript.xp + rat.xp*numOfEnemies;
				Debug.Log("Xp: " + heroScript.xp);
			}
			if (typeofEnemy == 3){
				heroScript.xp = heroScript.xp + zombie.xp*numOfEnemies;
				Debug.Log("Xp: " + heroScript.xp);
			}
			if (typeofEnemy == 4){
				heroScript.xp = heroScript.xp + haliax.xp*numOfEnemies;
				Debug.Log("Xp: " + heroScript.xp);
				vScript.setInfo();	//sets the info in victoryScript, for the Victory Scene.
			}


			comPlayer.transform.position = playerPos;	//When combat is ended, the player will return to the dungeon.
			}


		//all important lists are cleared and all necessary variables are set to original values, so combat can begin again.

		int i = 0;
		foreach (int l in listOfEnemies) {
			listOfEnemies[i] = 	0;
			enemyHps[i] = 0;
			i++;
		}

		foreach(GameObject g in combatEnemies){
			Destroy(g); //makes sure everything is cleaned up if the player dies.
		}

		combatEnemies.Clear ();
		numOfEnemies = 0;
		turn = 0; //resets turn counter.
		healthGiven = false;
		inCombat = false;
		t.UpdateText(0);		//All booleans and variables are reset.
	}



// ------------- SEE HEALTH -----------

	public float seeHealth(){ //for the text output. Returns the correct amount of health depending on the enemy that has been hit.
		float returner;

		if(enemyHit == 0){
			returner = enemyHps[0];
		}
		else if(enemyHit == 1){
			returner = enemyHps[1];

		}
		else if(enemyHit == 2){
			returner = enemyHps[2];
		}
		else{
			returner = enemyHps[3];
		}

		return returner;
	}


}
