using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {

	public bool isExitButton = false;

	void OnMouseEnter(){
		//Change color of text when moused over
		guiText.material.color = Color.green;
	}

	void OnMouseExit(){
		//Change color back to original color when the mouse goes away from the text
		guiText.material.color = Color.white;
	}

	void OnMouseUp(){
		//Check if we are looking at Quit Button, when the mouse goes back up.

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
