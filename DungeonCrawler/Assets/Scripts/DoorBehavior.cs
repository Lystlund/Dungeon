using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {
	public Texture DoorOpen;
	public Texture DoorClosed;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.mainTexture = DoorClosed;

	}
	
	// Update is called once per frame
	void Update () {
		float posX = transform.position.x;
		float posY = transform.position.y;
		float posZ = transform.position.z;

		if (Input.GetKey(KeyCode.E)){
			gameObject.renderer.material.mainTexture = DoorOpen;

			transform.localPosition = new Vector3(posX,posY,0);
		}
	}
}
