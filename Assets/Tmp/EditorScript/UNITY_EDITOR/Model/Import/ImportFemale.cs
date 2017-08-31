#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

public class ImportFemale : ImportBase
{
    public ImportFemale()
    {
        string path = EditorUtility.OpenFolderPanel("import female fold", "C:/Users/Administrator/Desktop", "");
        files = PathHelper.getAllChildFiles(path, ".fbx,.png");
    }

    public override string TargetFold
    {
        get { return string.Format("{0}/Tmp/FBX/{1}", Application.dataPath, CharacterConst.Female); }
    }

    public override string name
    {
        get { return EnumCharacterType.Charater_Female.ToString(); }
    }
}
#endif