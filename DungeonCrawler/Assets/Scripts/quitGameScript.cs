using UnityEngine;
using System.Collections;

public class quitGameScript : MonoBehaviour {
	
	public bool hasEscaped = false;

	void Start(){
		guiText.material.color = Color.clear;
	}


	void Update(){
		if (Input.GetKeyUp (KeyCode.Escape) && !hasEscaped) {
			guiText.material.color = Color.white;
			hasEscaped = true;
		} else if(Input.GetKeyUp (KeyCode.Escape) && hasEscaped) {
			guiText.material.color = Color.clear;
			hasEscaped = false;

		}


	}
	
	void OnMouseEnter(){
		//Change color of text when moused over
		if (hasEscaped) {
			guiText.material.color = Color.green;
		}
	}
	
	void OnMouseExit(){
		//Change color back to original color when the mouse goes away from the text
		if (hasEscaped) {
			guiText.material.color = Color.white;
		}
	}
	
	void OnMouseUp(){
		//Check if we are looking at Quit Button, when the mouse goes back up.
		//load level
		if (hasEscaped) {
			Application.LoadLevel (0);
		}
	}
}
