using UnityEngine;
using System.Collections;

public class victoryScript2 : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setText(int l){
		Debug.Log ("SETTING TEXT IN 2");
		guiText.text = "Final Level: "+l;
	}
}
