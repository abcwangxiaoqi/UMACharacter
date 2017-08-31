using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform cameraTarget;

	[Range(0.5f, 5.0f)]
	public float headDistance = 0.8f;
	[Range(0.5f, 5.0f)]
	public float bodyDistance = 2.0f;
	
	[HideInInspector]
	public float distance = 2.0f;
	
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;

	[Range(-90.0f, 0.0f)]
	public int yMinLimit = -20;
	[Range(0.0f, 90.0f)]
	public int yMaxLimit = 80;
	
	private float x = 0.0f;
	private float y = 0.0f;
	
	public float smoothTime = 0.3f;
	
	private float xSmooth = 0.0f;
	private float ySmooth = 0.0f;
	private float xVelocity = 0.0f;
	private float yVelocity = 0.0f;
	
	private Vector3 posSmooth = Vector3.zero;
	
	void Start () {
		if (cameraTarget == null) {Debug.LogError("Camera Target is missing! Please link it to UMAzing>Camera Target");}

		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		if (GetComponent<Rigidbody>()) {
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		
	}
	
	void Update () {
		
		if (cameraTarget) {
			if (Input.GetMouseButton(1)) {
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
				y = Mathf.Clamp (y, yMinLimit, yMaxLimit);

			}
			
			xSmooth = Mathf.SmoothDamp(xSmooth, x, ref xVelocity, smoothTime);
			ySmooth = Mathf.SmoothDamp(ySmooth, y, ref yVelocity, smoothTime);
			
			ySmooth = ClampAngle(ySmooth, yMinLimit, yMaxLimit);
			
			Quaternion rotation = Quaternion.Euler(ySmooth, xSmooth, 0);
			
			posSmooth = cameraTarget.position;
			
			transform.rotation = rotation;
			transform.position = rotation * new Vector3(0.0f, 0.0f, -distance) + posSmooth;
		} 
		
	}
	
	static float ClampAngle (float angle, float min, float max) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
