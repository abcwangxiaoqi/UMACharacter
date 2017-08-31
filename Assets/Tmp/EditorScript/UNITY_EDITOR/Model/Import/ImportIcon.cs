#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

public class ImportIcon : ImportBase
{
    public ImportIcon()
    {
        string path = EditorUtility.OpenFolderPanel("import icon fold", "C:/Users/Administrator/Desktop", "");
        files = PathHelper.getAllChildFiles(path, ".png");
    }

    public override string name
    {
        get { return "icon"; }
    }

    public override string TargetFold
    {
        get { return CharacterConst.ResUrl + "/" + name; }
    }
}
#endif
