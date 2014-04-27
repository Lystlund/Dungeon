using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {


	//Declaring varibles 
	float heroSpeed = 5.0f;
	float turnSpeed;
	float targetAngle = 0.0f;

	float heroLevel = 1;
	public int xp;
	public int xpRequired;
	float Strength;
	float Toughness;
	float Dexterity;
	float Reflex;
	float Health;

	public GameObject combatMan;
	public combatManagerScript combatScript;
	GameObject CombatMusicHolder;
	GameObject RoamingMusicHolder;
	Vector3 heroPos;
	bool quitMenu = false;
	public int w = 100;
	public int h = 100;

	//A function used for changing the angles of the hero. 
	void TargetAngle(float speed, float target){
		float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z,target,speed*Time.deltaTime);
		transform.eulerAngles = new Vector3(0,0,angle);
	}

	// Use this for initialization
	void Start () {

		//initializing the combatmanager script, the two music objects and the heros stats
		combatMan = GameObject.FindGameObjectWithTag ("Manager");
		combatScript = combatMan.GetComponent<combatManagerScript> ();
		CombatMusicHolder = GameObject.Find ("Battle_of_Kings");
		RoamingMusicHolder = GameObject.Find ("Anomaly_Detected");

		heroLevel = 1;
		xp = 0;
		xpRequired = 100;
		Strength = 10;
		Toughness = 10;
		Dexterity = 10;
		Reflex = 10;
		Health = 100;
		


	}
	
	// Update is called once per frame
	void Update () {
		//sets the vector3 positions equal to the heros position.
		heroPos.x = transform.position.x;
		heroPos.y = transform.position.y;
		heroPos.z = transform.position.z;


		//changes the music depending if you are in combat or not.
		if (combatScript.inCombat == false) {
			RoamingMusicHolder.audio.mute = false;
			CombatMusicHolder.audio.mute = true;
		}

		if (combatScript.inCombat == true) {
			RoamingMusicHolder.audio.mute = true;
			CombatMusicHolder.audio.mute = false;
		}
		//level up the hero
		if (xp >= xpRequired && heroLevel <= 19){
			heroLevel = heroLevel + 1;
			Strength = Strength + 5;
			Toughness = Toughness + 5;
			Dexterity = Dexterity + 5;
			Reflex = Reflex + 5;
			Health = Health + 2;
			xp = xp-xpRequired ;
			xpRequired = 100*((int)heroLevel);
		}

		//quitmenu
		if (Input.GetKeyDown (KeyCode.Escape) && quitMenu == false) {
			quitMenu = true;
		}


		//varible how fast the hero turns.
		turnSpeed = 200.0f;

		//Velocity vectors to give movement to the hero
		if (Input.GetKey(KeyCode.UpArrow)){
			rigidbody.velocity = new Vector3(0,heroSpeed,0);
			TargetAngle(turnSpeed,90);

			if (Input.GetKey (KeyCode.RightArrow)) {
				rigidbody.velocity = new Vector3(heroSpeed,heroSpeed,0);
				TargetAngle(turnSpeed,45);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)){
				rigidbody.velocity = new Vector3(-heroSpeed,heroSpeed,0);
				TargetAngle(turnSpeed,135);
			}
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
			rigidbody.velocity = new Vector3(0,-heroSpeed,0);
			TargetAngle(turnSpeed,270);
			if (Input.GetKey(KeyCode.RightArrow)){
				rigidbody.velocity = new Vector3(heroSpeed,-heroSpeed,0);
				TargetAngle(turnSpeed,315);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)){
				TargetAngle(turnSpeed,225);
				rigidbody.velocity = new Vector3(-heroSpeed,-heroSpeed,0);
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			rigidbody.velocity = new Vector3(heroSpeed,0,0);
			TargetAngle(turnSpeed,0);
		}
		else if (Input.GetKey(KeyCode.LeftArrow)){
			rigidbody.velocity = new Vector3(-heroSpeed,0,0);
			TargetAngle(turnSpeed,180);
		}
		else{
			rigidbody.velocity = new Vector3(0,0,0);
		}
	}

	public float getInfo(int i){  //Getter for all the relevant hero info
		if(i == 0){
			return heroLevel;
		}
		else if(i == 1){
			return Strength;
		}
		else if(i == 2){
			return Toughness;
		}
		else if(i == 3){
			return Dexterity;
		}
		else if(i == 4){
			return Reflex;
		}
		else if(i == 5){
			return Health;
		}
		else {
			return 0;
		}
	}

	// setter for the heros health
	public void setHealth(float h){
		Health = h;
	}


	void OnGUI () {
			if (quitMenu == true) {
				// Make a background box
				GUI.Box (new Rect (Screen.height/2-10, Screen.width/2-10, 100, 90), "Loot-Quest");

				// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if (GUI.Button (new Rect (Screen.height/2-20, Screen.width/2-40, 80, 20), "Menu")) {
						Application.LoadLevel (0);
				}

				// Make the second button.
			if (GUI.Button (new Rect (Screen.height/2-20, Screen.width/2-70, 80, 20), "Return")) {
					quitMenu = false;
				}
			}
		}
}