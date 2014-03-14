using UnityEngine;
using System.Collections;

public class RatScript : Enemy {

	// Use this for initialization
	void Start () {
		EnemyStrength = 2;
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (EnemyStrength);
	
	}
}
