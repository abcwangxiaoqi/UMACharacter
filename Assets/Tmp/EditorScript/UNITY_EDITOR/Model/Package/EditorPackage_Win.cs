#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
public class EditorPackage_Win : EditorPackage
{
    public override BuildTarget target
    {
        get { return BuildTarget.StandaloneWindows; }
    }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/" + CharacterConst.AB_win; }
    }
}
#endif