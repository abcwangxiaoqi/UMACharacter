using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFader : MonoBehaviour {

	public Texture2D fadeOutTexture;
	
	[Range(0.1f, 5.0f)]
	public float fadeTime = 2.5f;
	
	int drawDepth = -1000;
	float alpha = 1.0f; 
	float fadeDir = -1f;

	void Start(){
		alpha = 1;
		fadeIn();
	}

	void OnGUI() {
		alpha += fadeDir / fadeTime * Time.deltaTime;	
		alpha = Mathf.Clamp01(alpha);	
	 
	 	Color guiColor = GUI.color;

	 	guiColor.a = alpha;

		GUI.color = guiColor;
	 
		GUI.depth = drawDepth;
	 
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
	 
	public void fadeIn(){
		fadeDir = -1f;	
	}
	 
	public void fadeOut(){
		fadeDir = 1f;	
	}

	public void fadeOutAndLoadScene(string levelName){
		fadeDir = 1f;	
		StartCoroutine(WaitAndLoadLevel(levelName));
	}

	IEnumerator WaitAndLoadLevel(string levelName){
		yield return new WaitForSeconds(fadeTime / 2);
		Application.LoadLevel(levelName);
	}
	 
	
}

 
 
