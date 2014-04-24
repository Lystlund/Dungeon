using UnityEngine;
using System.Collections;

public class Aggro : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg-180;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
