using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {

	/// <summary>
	/// A class used to store the doors attributes such as position.
	/// </summary>
	/// <returns>Class Door</returns>

	public Texture DoorOpen;
	public Texture DoorClosed;
	public float DoorPosX;
	public float DoorPosY;
	public float DoorPosZ = -0.7f;

	/// <summary>
	/// A function which is used for making doors auto close after being activated for a certain amount of time
	/// so far the default is set to 5 seconds and return them to a height where they can collide with the player
	/// </summary>
	/// <returns>The auto close.</returns>
	/*
	IEnumerator DoorAutoClose() {
		Debug.Log("X: " + DoorPosX);
		Debug.Log("Y: " + DoorPosY);
		Debug.Log("Door Opened");
		yield return new WaitForSeconds(5);
		Debug.Log("Door Closed");

		gameObject.renderer.material.mainTexture = DoorClosed;
		transform.localPosition = new Vector3(DoorPosX,DoorPosY,DoorPosZ);
	}
    */
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		/* This is the statement which opens the door and change its z-position to 0 doing so the hero
		can walk over it. It also starts the function DoorAutoClose */
		DoorPosX = transform.position.x;
		DoorPosY = transform.position.y;

		if (Input.GetKey(KeyCode.E)){
			gameObject.renderer.material.mainTexture = DoorOpen;
			transform.localPosition = new Vector3(DoorPosX,DoorPosY,0);
			//StartCoroutine(DoorAutoClose());

		}

	}
}
