using UnityEngine;
using System.Collections;

public class textureScript : MonoBehaviour {

	GUITexture blackThing;
	float aVal = 1.0f;
	Color thisColor;
	public bool fadeIn = true;
	float fadeSpeed = 10f;

	// Use this for initialization

	void Awake(){
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	void Start () {

		blackThing = GetComponent<GUITexture> ();
		//thisColor = blackThing.color;

		//thisColor.a = 1.0f;

		blackThing.color = thisColor;




		//StartCoroutine(Fade(2.0f));
	}
	
	// Update is called once per frame
	void Update () {
		blackThing.color = thisColor;

		Debug.Log("ThisColor: "+thisColor.a + "  blackthingcolor: "+blackThing.color.a+"   "+fadeIn);	
	}



	public IEnumerator Fade(float dur){
		Debug.Log("FADEIN ACTUALLY STARTED!!!");

		float speed = 1.0f/dur;

		float time = 0.0f;
		while(time < dur){
			time += Time.deltaTime;

			thisColor.a = Mathf.InverseLerp(0.0f, dur, time);
			yield return 0;
		}

		fadeIn = false;
		yield return 0;

		time  = 0.0f;
		while(time < dur){
			time += Time.deltaTime;

			thisColor.a = Mathf.InverseLerp(dur, 0.0f, time);
			yield return 0;
		}

		yield return 0;

	}
	

}
