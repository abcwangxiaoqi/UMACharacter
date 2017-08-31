using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        TextAsset ta = Resources.Load<TextAsset>("test");
        CharacterData cd=ta.text.JsonTransferObject<CharacterData>();
        Debug.Log(cd.sex);
        return;

        IScence scence =
#if UNITY_EDITOR
 new ScenceEditor();
#else
        new ScenceFittingroom();
#endif

        scence.Load();
    }
}
