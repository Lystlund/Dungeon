using UnityEngine;
using System.Collections;

public class victoryScript2 : MonoBehaviour {


	public void setText(int l){		//Sets the text info to the correct level. Made this in two so this script controls the guiText directly.
		Debug.Log ("SETTING TEXT IN 2");
		guiText.text = "Hero Level: "+l;
	}
}
