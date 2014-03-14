using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float LockedZ = -10.0f;

	public Transform target;

	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(target.position.x, target.position.y, LockedZ);
	}
}

