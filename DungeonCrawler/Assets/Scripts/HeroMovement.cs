using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

	class HeroInfo{
		public float heroPosX;
		public float heroPosY;
		public float heroSpeed = 5.0f;
	}

	public int heroLevel = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		HeroInfo hero = new HeroInfo();
		hero.heroPosX = transform.position.x;
		hero.heroPosY = transform.position.y;

		//Velocity vectors to give movement to the hero
		if (Input.GetKey(KeyCode.UpArrow)){
			rigidbody.velocity = new Vector3(0,hero.heroSpeed,0);
			if (Input.GetKey (KeyCode.RightArrow)) {
				rigidbody.velocity = new Vector3(hero.heroSpeed,hero.heroSpeed,0);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)){
				rigidbody.velocity = new Vector3(-hero.heroSpeed,hero.heroSpeed,0);
			}
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
			rigidbody.velocity = new Vector3(0,-hero.heroSpeed,0);
			if (Input.GetKey(KeyCode.RightArrow)){
				rigidbody.velocity = new Vector3(hero.heroSpeed,-hero.heroSpeed,0);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)){
				rigidbody.velocity = new Vector3(-hero.heroSpeed,-hero.heroSpeed,0);
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			rigidbody.velocity = new Vector3(hero.heroSpeed,0,0);
		}
		else if (Input.GetKey(KeyCode.LeftArrow)){
			rigidbody.velocity = new Vector3(-hero.heroSpeed,0,0);
		}
		else{
			rigidbody.velocity = new Vector3(0,0,0);
		}
	}
}
