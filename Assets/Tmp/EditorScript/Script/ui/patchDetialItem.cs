using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class patchDetialItem : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
	}

    ClothModel clothModel;
   public  void Ini(ClothModel cm)
    {
        clothModel = cm;
        text.text = clothModel.resname;
        gameObject.name = clothModel.resname;
    }

}
