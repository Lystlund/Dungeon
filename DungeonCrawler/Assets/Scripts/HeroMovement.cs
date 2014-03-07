using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		//Velocity vectors to give movement to the hero
		if (Input.GetKey(KeyCode.UpArrow)){
			rigidbody.velocity = new Vector3(0,1,0);
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
			rigidbody.velocity = new Vector3(0,-1,0);
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			rigidbody.velocity = new Vector3(1,0,0);
		}
		else if (Input.GetKey(KeyCode.LeftArrow)){
			rigidbody.velocity = new Vector3(-1,0,0);
		}
		else{
			rigidbody.velocity = new Vector3(0,0,0);
		}
	}
}
