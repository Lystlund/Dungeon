using UnityEngine;
using System.Collections;

public class textureScript : MonoBehaviour {

	GUITexture blackThing;
	float aVal = 1.0f;
	Color thisColor;
	bool fadeIn = true;
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



		//if(fadeIn){
		StartCoroutine(Fade(2.0f));
		//	FadeToBlack();
		Debug.Log("FADEIN STARTED!!!");
		//fadeIn = false;
		//StartCoroutine(FadeOut(2.0f));
		Debug.Log("FADEOUT STARTED)");
		//}


	
	}
	
	// Update is called once per frame
	void Update () {
		blackThing.color = thisColor;

		//blackThing.color = Color.Lerp(blackThing.color, Color.clear, fadeSpeed * Time.deltaTime);


		//StartCombatFade();
		/*
		if(fadeIn){
			StartCombatFade();
		}

		if(blackThing.color ==  Color.clear){
			EndCombatFade();
		}

		if(!fadeIn){
			Debug.Log("FADEIN DONE");
		}*/

		Debug.Log("ThisColor: "+thisColor.a + "  blackthingcolor: "+blackThing.color.a+"   "+fadeIn);	
	}



	void FadeToBlack(){
		blackThing.color = Color.Lerp(blackThing.color, Color.black, fadeSpeed * Time.deltaTime);

	}

	void FadeToClear(){
		blackThing.color = Color.Lerp(blackThing.color, Color.clear, fadeSpeed * Time.deltaTime);
	}


	void StartCombatFade(){
		FadeToBlack();

		if(blackThing.color.a >= 95.5f){
			blackThing.color = Color.clear;
			blackThing.enabled = false;
			fadeIn = false;
		}
	}

	void EndCombatFade(){
		blackThing.enabled = true;
		FadeToClear();

		if(blackThing.color.a <= 0.05f){
			blackThing.color = Color.black;
		}
	}


	IEnumerator Fade(float dur){
		Debug.Log("FADEIN ACTUALLY STARTED!!!");

		float speed = 1.0f/dur;

		float time = 0.0f;
		while(time < dur){
			time += Time.deltaTime;

			thisColor.a = Mathf.InverseLerp(0.0f, dur, time);
			yield return 0;
		}
		/*
		for(float i = 0; i<10;i+=Time.deltaTime*speed){
			thisColor.a = thisColor.a = Mathf.Lerp(0.0f,1.0f,i);
		
			yield return 0;
		}*/
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

	/*
	IEnumerator FadeOut(float dur){
		Debug.Log("FADEOUT ACTUALLY STARTED");
		//yield return new WaitForSeconds(1);
		float speed = 1.0f/dur;
		for(float i = 0; i<10;i+=Time.deltaTime*speed){
			thisColor.a = thisColor.a = Mathf.Lerp(1.0f,0.0f,i);
			
			yield return 0;
		}
		//yield return new WaitForSeconds(2);

	

	}
*/
	

}
