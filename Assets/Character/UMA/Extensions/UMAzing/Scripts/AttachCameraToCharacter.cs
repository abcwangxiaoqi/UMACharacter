using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachCameraToCharacter : MonoBehaviour {

	public GameObject overrideAttachTo;
	public Vector3 cameraPosition = new Vector3(-1.8f, -0.5f, -1.8f);
	public Vector3 cameraRotation = new Vector3(0f, 12.0f, 90.0f);

	private GameObject attachToGO;

	void Start() {

		StartCoroutine(WaitAndAttach());
	}

	IEnumerator WaitAndAttach() {

		// Wait until we find a character to attach to
		while (true) {
			if (GameObject.Find("Global") != null) break;
			yield return new WaitForSeconds(0.1f);
		}

		if (overrideAttachTo == null) {
			attachToGO = GameObject.Find("Global");
		}
		else {
			attachToGO = overrideAttachTo;
		}

		gameObject.transform.parent = attachToGO.transform;
		gameObject.transform.localPosition = cameraPosition;
		gameObject.transform.localEulerAngles = cameraRotation;

		yield return new WaitForEndOfFrame();
	}
	
}
