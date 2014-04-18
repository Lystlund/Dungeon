using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combatManagerScript : MonoBehaviour {

	GameObject fadeTex;
	textureScript fadeScript;

	GameObject cText;
	combatTextScript t;

	public GameObject hero;
	public HeroMovement heroScript;
	public SpaceZombieCombatScript zombie;
	public SpaceSpiderCombatScript spider;
	public HaliaxCombatScript haliax;
	public RatCombatScript rat;

	private List<int> listOfEnemies = new List<int>(new int[] {0,0,0,0});
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
	float[] enemyHps = new float[4] {0,0,0,0};
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

		fadeTex = GameObject.FindGameObjectWithTag("Fader");
		fadeScript = fadeTex.GetComponent<textureScript>();

		cText = GameObject.Find ("combatTextBox");
		t = cText.GetComponent<combatTextScript>();


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
		//Debug.Log ("INCOMBAT: " + inCombat + " COMBATSTARTED: " + combatStarted + " PLAYERTURN: " + PlayerTurn);
	}


	//NUMBER CODING: 1 is Spider, 2 is Rat, 3 is Zombie, 4 is Haliax.



	public void addToCombat(int opp){ //function runs as many times as there will be enemies (defined in enemyscript)
		if (!inCombat) {
			listOfEnemies[numOfEnemies] = opp; //the enemy id (opp) is added into the list of enemies one at a time.
			numOfEnemies += 1; //right now we can't have more than 4 enemies in battle at once. Can easily change if we want more.
			if (numOfEnemies >= 4) {
				numOfEnemies = 0;
			}
		}
	}


	public void startCombat(){ //is started by enemyscript collision. Spawns enemies and moves player.
		inCombat = true;
		combatStarted = true;
		t.UpdateText(0);

		//StartCoroutine(fadeScript.Fade(2.0f)); //FOR FADING. WILL HAPPEN LATER

		Debug.Log ("COMBAT STARTED");

		if (combatStarted) {
			//while(!fadeScript.fadeIn){} //also for fading.
			playerPos = comPlayer.transform.position;
			comPlayer.transform.position = new Vector3 (100, 0, 0); //storing player position (for return) and moving him.

			int i = 0;
			foreach (int e in listOfEnemies) {
				//Debug.Log("Number in listofEnemies: "+listOfEnemies[i]);
				if(listOfEnemies [i] == 0)  { //Creates enemy of the correct type depending on the id given in the enemy list.
						Debug.Log("The Enemy is 0! So no enemy");
						combatEnemies.Add(null); //if zero, gameobject is set to null. this is used to track if there isn't an enemy at a position.
					}
				else if (listOfEnemies [i] == 1) {
					combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/GiantSpaceSpiderCombat")));
					spider = combatEnemies[i].GetComponent<SpaceSpiderCombatScript>();
					enemyHps[i] = spider.EnemyHealth;
					//Debug.Log("CHECKING "+enemyHps[i]+ "   "+spider.EnemyHealth);
					typeofEnemy = 1;
					}
				else if (listOfEnemies [i] == 2) {
					combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/GiantSpaceRatCombat")));
					rat = combatEnemies[i].GetComponent<RatCombatScript>();
					enemyHps[i] = rat.EnemyHealth;
					typeofEnemy = 2;
					}
				else if (listOfEnemies [i] == 3) {
					combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/SpaceZombieCombat")));
					zombie = combatEnemies[i].GetComponent<SpaceZombieCombatScript>();
					enemyHps[i] = zombie.EnemyHealth;
					typeofEnemy = 3;
					}
				else if (listOfEnemies [i] == 4) {
					combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/HaliaxCombat")));
					haliax = combatEnemies[i].GetComponent<HaliaxCombatScript>();
					enemyHps[i] = haliax.EnemyHealth;
					typeofEnemy = 4;
					}
				else{
					Debug.Log("ERROR: UNKNOWN ENEMY ID");
				}

				if(listOfEnemies [i] != 0)  { //moves enemies to appropriate positions
					combatEnemies [i].transform.position = new Vector3 (105, 2.3f - (i*1.2f), 0); //the combat enemies are then moved to the correct position.
				}
				i++;
			}

			combatStarted = false;
		}

	}




// ----------------------------------------------- COMBAT --------------------------------------------------------------------- //


	public void Combat (){

		if (!healthGiven) { //gives the appropriate health to enemies at the start of combat. Had to do it here, because the above function didn't register the correct health, for some reason.
			int j = 0;
			foreach (GameObject g in combatEnemies) {	 //
				if (typeofEnemy == 1 && combatEnemies[j] != null)
						enemyHps [j] = spider.EnemyHealth;
				else if (typeofEnemy == 2 && combatEnemies[j] != null)
						enemyHps [j] = rat.EnemyHealth;
				else if (typeofEnemy == 3 && combatEnemies[j] != null)
						enemyHps [j] = zombie.EnemyHealth;
				else if (typeofEnemy == 4 && combatEnemies[j] != null)
						enemyHps [j] = haliax.EnemyHealth;
				//Debug.Log("START ENEMY "+j+"  "+enemyHps[j]);
				j++;
			}
			Debug.Log("HEALTH GIVEN");
			healthGiven = true;
			t.UpdateText(0);
		}

		GameObject HitEnemy = combatEnemies[0];
		float hitEnemyHealth;



	// ---------------------------------------- PLAYER TURN

		if (PlayerTurn==true){ //the player starts. Maybe later we'll implement so the person with the highest reflex starts.
			if (CombatInitiate==false){
				if (Input.GetKeyUp(KeyCode.Space)){ //space iniates that the player wants to attack.
					CombatInitiate=true; 
					t.UpdateText(1);
					//Debug.Log("COMBAT INITIATED!");
				}
			}
			if (CombatInitiate==true){ //a keycode 1-4 defines which enemy the player wants to attack.
				if (Input.GetKey(KeyCode.Alpha1) && combatEnemies[0] != null){
					Debug.Log(combatEnemies[1]);
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
				//Debug.Log("HIT ENEMY "+CombatInitiate);
			}

			if (giveDam==true){ //when the enemy has been defined the damage rolls will be done.
				float eReflex = 0;
				float eToughness = 0; //first, the needed variables are created...
				float eLevel = 0;

				if(typeofEnemy==1){  //.. and filled with the appropriate numbers, depending on enemytype.
					eReflex = spider.EnemyReflex;
					eToughness = spider.EnemyToughness;
					eLevel = spider.characterlevel;
					//Debug.Log("STUUUUUFF "+eReflex+" "+eToughness+" "+eLevel+"  "+spider.EnemyHealth);
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

				//chance to hit: (d20+attdex+(attlvl/2))>= (10+defrex+(deflvl/2))
				//damage: (d20+attstr+(attlvl/2))-(deftgh+(deflvl/2))
				bool hit = false;
				 //Then, the actual damage calculation is done. 
				if((Random.Range (1,20)+heroScript.Dexterity+(heroScript.heroLevel/2))>=(10+eReflex+(eLevel/2))){ //first a chance to hit, and if it passes.. 
					hit = true;
					damage = (Random.Range (1,20)+heroScript.Strength+(heroScript.heroLevel/2))-(eToughness+(eLevel/2)); //..damage is calculated.
					if (damage < 0){ //damage cannot be lower than zero.
						damage = 0;
					}
					Debug.Log("HERO DAMAGE "+damage+" "+hit);

					int i = 0;
					foreach(GameObject g in combatEnemies){
					//	Debug.Log("ENEMY "+i+"  "+enemyHps[i]);
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
					Debug.Log("HERO MISS");
					t.UpdateText(3);
				}

				enemyhptotal = enemyHps[0]+enemyHps[1]+enemyHps[2]+enemyHps[3]; //total enemy health is calculated to check if the combat is still going.
				Debug.Log ("Total health "+enemyhptotal+" Individuals: "+enemyHps[0]+" "+enemyHps[1]+" "+enemyHps[2]+" "+enemyHps[3]);


				int j = 0;
				foreach(GameObject g in combatEnemies){
					if(enemyHps[j]<=0){ //if there are any enemies with 0 health, they are destroyed.
						Destroy(combatEnemies[j]);
					}
					j++;
				}

				if (enemyhptotal <= 0){ //if all enemies have 0 health, combat is ended, with the player winning.
					endCombat(false);
				}

				giveDam = false;
				PlayerTurn = false;
			}

		}




	// ------------------------------------------ ENEMY TURN

		if (PlayerTurn!=true){
			bool eDam = true;
			Debug.Log("ENEMY TURN BEGUN!");
			//t.UpdateText(0);

				if (eDam==true){
				Debug.Log("DAMAGE WILL BE GIVEN!"); //just as in player turn, variables are created, then filled in with appropriate stats.
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
				bool hit = false;
				if((Random.Range (1,20)+eDexterity+(eLevel/2))>=(10+heroScript.Reflex+(heroScript.heroLevel/2))){
					hit = true;
					eDamage = (Random.Range (1,20)+eStrength+(eLevel/2))-(heroScript.Toughness+(heroScript.heroLevel/2));
					if (eDamage < 0){
						eDamage = 0;
					}
					Debug.Log(eDamage+" "+heroScript.Health);
					heroScript.Health-=eDamage;

					if(heroScript.Health<=0){ //if the hero has 0 health, the combat ends, with the hero dead.
						endCombat(true);

					}
					Debug.Log("ENEMY DAMAGE: "+eDamage);
					t.UpdateText(4);
			}
				else{
					Debug.Log("ENEMY MISS");
					t.UpdateText(5);
				}
				eDam = false;
				PlayerTurn=true;
				Debug.Log("HERO HEALTH: "+heroScript.Health);
				//t.UpdateText(0);
			}
			turn++; //turn is incremented when the enemy has had it's turn. THIS NEEDS TO BE CHANGED IF WE EVER IMPLEMENT REFLEX START THINGY.
			//t.UpdateText(0);
		}
		//Debug.Log ("TURN: " + turn);
	}






// ------------------------------------------------ COMBAT END ------------------------ //

	public void endCombat(bool heroDeath){ 

		if (heroDeath) { //checks if it was the hero's death of enemies' death that triggered endCombat. Right now they do the same thing.
			Debug.Log("GAME OVER!"); //this needs to change when we have a GAME OVER screen.
			comPlayer.transform.position = playerPos;
			} 
		else {
			Debug.Log("THE PLAYER WON!");
			comPlayer.transform.position = playerPos;
			}


		//the lists are cleared and all necessary variables are set to original values, so combat can begin again.

		int i = 0;
		foreach (int l in listOfEnemies) { //this probably doesn't work yet... but nvm for right now. Will figure out later.
			listOfEnemies[i] = 	0;
			//Debug.Log("END OF COMBAT CHECK: "+listOfEnemies[i]);
			i++;
		}

		foreach(GameObject g in combatEnemies){
			Debug.Log("GAMEOBJECKTS: "+g); //OMG! THIS IS BRILLIANT! Why havent I thought of this before?!?! GAMEOBJECKTS! SERIOUSLY. DAMMIT, BRAIN.. You're failing me.
			Destroy(g); //makes sure everything is cleaned up if the player dies.
		}

		combatEnemies.Clear ();
		numOfEnemies = 0;
		turn = 0; //resets turn counter.
		healthGiven = false;
		inCombat = false;
		t.UpdateText(0);
	}




	public float seeHealth(){ //for the text output.
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
