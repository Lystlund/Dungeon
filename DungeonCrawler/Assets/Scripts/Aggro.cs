﻿using UnityEngine;
using System.Collections;

public class Aggro : MonoBehaviour {

	//Define variables
	GameObject hero;
	Transform target;
	float distance;



	// Use this for initialization
	void Start () {
		//find the hero object
		hero = GameObject.FindGameObjectWithTag ("Player");
		//set target equal to its position
		target = hero.transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Calculates the distance between Hero and Enemy
		distance = Vector3.Distance (hero.transform.position, this.transform.position);
		//finds the direction the hero is minus the position of the enemy the script is applied on.
		Vector3 dir = target.position - transform.position;
		//calculates the angle (we subtract with -180 due to the rotation of our enemies)
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg-180;
		//changes the enemies rotation

		if (distance <= 2){
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
