using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class patchItem : MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start () {
	
	}

    public void Ini(ClothType type)
    {
        text.text = type.name;
        gameObject.name = type.name;
    }
}
