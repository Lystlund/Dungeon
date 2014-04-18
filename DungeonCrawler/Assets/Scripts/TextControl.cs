using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {

	public bool isExitButton = false;

	void OnMouseEnter(){
		//Change color of text
		guiText.material.color = Color.green;
	}

	void OnMouseExit(){
		//Change color back to original color
		guiText.material.color = Color.white;
	}

	void OnMouseUp(){
		//Check if we are looking at Quit Button

		if (isExitButton == true){
			//quit the game
			Application.Quit();
		}

		else{
			//load level
			Application.LoadLevel(1);
		}
	}
}
