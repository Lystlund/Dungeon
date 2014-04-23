using UnityEngine;
using System.Collections;


//This script is made for the camera to follow a target, such as a hero.

public class CameraFollow : MonoBehaviour {

	public float LockedZ = -10.0f;	//How far away the camera is from the target.
	public Transform target;	//Apply the target, in our case the hero is the target.

	void Update () {
		//makes the cameras x,y,z position equal to targets x and way and the LockedZ.
		transform.position = new Vector3(target.position.x, target.position.y, LockedZ);
	}
}

