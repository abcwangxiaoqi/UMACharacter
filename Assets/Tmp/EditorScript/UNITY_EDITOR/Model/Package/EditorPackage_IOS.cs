#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
public class EditorPackage_IOS : EditorPackage
{
    public override BuildTarget target
    {
        get { return BuildTarget.iOS; }
    }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/" + CharacterConst.AB_Ios; }
    }
}
#endif