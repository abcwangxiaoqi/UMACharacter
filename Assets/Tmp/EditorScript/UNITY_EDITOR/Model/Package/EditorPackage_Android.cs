#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
public class EditorPackage_Android : EditorPackage
{
    public override BuildTarget target
    {
        get { return BuildTarget.Android; }
    }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/" + CharacterConst.AB_Android; }
    }
}
#endif