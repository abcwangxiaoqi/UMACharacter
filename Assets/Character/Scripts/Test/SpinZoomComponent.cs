using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SpinZoomComponent : MonoBehaviour {

    Transform trans;

    /// <summary>
    /// 旋转速度
    /// </summary>
    public float speed = 10f;
    
    /// <summary>
    /// 放大缩小速度
    /// </summary>
    public float scrollSensive = 10f;

    /// <summary>
    /// 最小距离
    /// </summary>
    public float MinFieldView = 0f;

    /// <summary>
    /// 最大距离
    /// </summary>
    public float MaxFieldView = 160f;


	//
	public bool CanMove=true;

    bool leftDown = false;

    Camera cam;
	// Use this for initialization
	void Start () {
        trans = transform;
        cam = Camera.main.GetComponent<Camera>();
	}
	
	void Update () 
    {
		if (!CanMove)
			return;

		/*
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit rayCastHit;
		if (Physics.Raycast (ray, out rayCastHit)) {
			Debug.Log (rayCastHit.ToString ());
			return;
		}
		*/

        if (EventSystem.current.IsPointerOverGameObject())//whether tap on ui
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            leftDown = true;
       
        }
        if (Input.GetMouseButtonUp(0))
        {
            leftDown = false;
        }

        if(leftDown)
        {
            float x = Input.GetAxis("Mouse X");

            trans.localRotation = Quaternion.Euler(0f, -0.5f * x * speed, 0f) * trans.localRotation;

			float y = Input.GetAxis("Mouse Y");

			Vector3 v = trans.localPosition;
			v.y += 0.05f*y;
			trans.localPosition = v;
        }

        float w = Input.GetAxis("Mouse ScrollWheel");


        if(w != 0)
        {
            cam.fieldOfView -= w * scrollSensive;

            if (cam.fieldOfView < MinFieldView)
                cam.fieldOfView = MinFieldView;

            if (cam.fieldOfView > MaxFieldView)
                cam.fieldOfView = MaxFieldView;
        }

	}
}
