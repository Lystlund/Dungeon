using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combatManagerScript : MonoBehaviour {

	public GameObject hero;
	public HeroMovement heroScript;
	public SpaceZombieCombatScript zombie;
	public SpaceSpiderCombatScript spider;
	public HaliaxCombatScript haliax;
	public RatCombatScript rat;

	private List<int> listOfEnemies = new List<int>(new int[] {0,0,0,0});
	private List<GameObject> combatEnemies =  new List<GameObject>();

	public GameObject comPlayer;
	Vector3 playerPos;

	private int numOfEnemies = 0;
	public bool inCombat = false;
	public bool combatStarted = false;
	bool CombatInitiate=false;
	bool PlayerTurn=true;
	bool giveDam;
	int typeofEnemy;
	float enemyhptotal = 0;
	float[] enemyHps = new float[4] {0,0,0,0};
	
	// Use this for initialization
	void Start () {

		numOfEnemies = 0;

		listOfEnemies [0] = 0;
		listOfEnemies [1] = 0;
		listOfEnemies [2] = 0;
		listOfEnemies [3] = 0;

		comPlayer = GameObject.FindGameObjectWithTag ("Player");
		heroScript = comPlayer.GetComponent<HeroMovement> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (inCombat) { //just to test if endCombat works before we actually make it possible to end it xD
			if (Input.GetKey (KeyCode.Q)) {
					endCombat ();
			}
		}

		if(inCombat==true){
			Combat();
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
						//Debug.Log("0!");
					}
				else if (listOfEnemies [i] == 1) {
							combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/GiantSpaceSpiderCombat")));
							spider = combatEnemies[i].GetComponent<SpaceSpiderCombatScript>();
							enemyHps[i] = combatEnemies[i].GetComponent<SpaceSpiderCombatScript>().EnemyHealth;
					//Debug.Log("CHECKING "+enemyHps[i]+ "   "+spider.EnemyHealth);
					typeofEnemy = 1;
					}
				else if (listOfEnemies [i] == 2) {
							combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/GiantSpaceRatCombat")));
							rat = combatEnemies[i].GetComponent<RatCombatScript>();
					enemyHps[i] = combatEnemies[i].GetComponent<RatCombatScript>().EnemyHealth;
					typeofEnemy = 2;
					}
				else if (listOfEnemies [i] == 3) {
							combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/SpaceZombieCombat")));
							zombie = combatEnemies[i].GetComponent<SpaceZombieCombatScript>();
					enemyHps[i] = combatEnemies[i].GetComponent<SpaceZombieCombatScript>().EnemyHealth;
					typeofEnemy = 3;
					}
				else if (listOfEnemies [i] == 4) {
							combatEnemies.Add ((GameObject)Instantiate (Resources.Load ("PreFabs/HaliaxCombat")));
							haliax = combatEnemies[i].GetComponent<HaliaxCombatScript>();
					enemyHps[i] = combatEnemies[i].GetComponent<HaliaxCombatScript>().EnemyHealth;
					typeofEnemy = 4;
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

	public void Combat (){
		int j = 0;
		foreach(GameObject g in combatEnemies){
			enemyHps[j] = spider.EnemyHealth;
		//Debug.Log("START ENEMY "+j+"  "+enemyHps[j]);
			j++;
		}
		GameObject HitEnemy = combatEnemies[0];
		float hitEnemyHealth;

		if (PlayerTurn==true){
			if (CombatInitiate==false){
				if (Input.GetKey(KeyCode.Space)){
					CombatInitiate=true;
					//Debug.Log("COMBAT INITIATED!");

				}
			}
			if (CombatInitiate==true){
				if (Input.GetKey(KeyCode.Alpha1)){
					HitEnemy=combatEnemies[0];
					CombatInitiate = false;
					giveDam = true;
				} 
				else if (Input.GetKey(KeyCode.Alpha2)){
					HitEnemy=combatEnemies[1];
					CombatInitiate = false;
					giveDam = true;

				} else if (Input.GetKey(KeyCode.Alpha3)){
					HitEnemy=combatEnemies[2];
					CombatInitiate = false;
					giveDam = true;

				} else if (Input.GetKey(KeyCode.Alpha4)){
					HitEnemy=combatEnemies[3];
					CombatInitiate = false;
					giveDam = true;


				} 

				//Debug.Log("HIT ENEMY "+CombatInitiate);

			}
			if (giveDam==true){
				float eReflex = 0;
				float eToughness = 0;
				float eLevel = 0;

				if(typeofEnemy==1){
					eReflex = spider.EnemyReflex;
					eToughness = spider.EnemyToughness;
					eLevel = spider.characterlevel;
					//Debug.Log("STUUUUUFF "+eReflex+" "+eToughness+" "+eLevel+"       "+spider.EnemyHealth);
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
				float damage;
				if((Random.Range (1,20)+heroScript.Dexterity+(heroScript.heroLevel/2))>=(10+eReflex+(eLevel/2))){
					hit = true;
					damage = (Random.Range (1,20)+heroScript.Strength+(heroScript.heroLevel/2))-(eToughness+(eLevel/2));
					if (damage < 0){
						damage = 0;
					}
					Debug.Log("HERO DAMAGE "+damage+" "+hit);
				
					int i = 0;
					foreach(GameObject g in combatEnemies){
					//	Debug.Log("ENEMY "+i+"  "+enemyHps[i]);
						if(HitEnemy==combatEnemies[i])

							{enemyHps[i] -= damage;
								if(enemyHps[i]<0){
									enemyHps[i]=0;
								}
						}
						i++;
					}
				}
				else{
				//	Debug.Log("miss");
				}

				enemyhptotal = enemyHps[0]+enemyHps[1]+enemyHps[2]+enemyHps[3];
				Debug.Log ("Total health "+enemyhptotal);
				if (enemyhptotal <= 0){
					endCombat();
				}

				giveDam = false;
				PlayerTurn = false;
			}

		}

		if (PlayerTurn!=true){
			bool eDam = true;
			Debug.Log("ENEMY TURN BEGUN!");
			int i = 0;
			foreach(GameObject g in combatEnemies){
				if(enemyHps[i]<0){
					Destroy(combatEnemies[i]);
				}
				i++;
			}

				if (eDam==true){
				Debug.Log("DAMAGE WILL BE GIVEN!");
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
				float damage;
				if((Random.Range (1,20)+eDexterity+(eLevel/2))>=(10+heroScript.Reflex+(heroScript.heroLevel/2))){
					hit = true;
					damage = (Random.Range (1,20)+eStrength+(eLevel/2))-(heroScript.Toughness+(heroScript.heroLevel/2));
					if (damage < 0){
						damage = 0;
					}
					Debug.Log(damage+" "+heroScript.Health);
					heroScript.Health-=damage;
					if(heroScript.Health<=0){
						endCombat();
					}
					Debug.Log(damage+" "+heroScript.Health);
			}
				else{
					Debug.Log("ENEMY MISS");
				}
				eDam = false;
				PlayerTurn=true;
			}

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
