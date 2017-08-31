#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

public class ImportMale : ImportBase
{
    public ImportMale()
    {
        string path = EditorUtility.OpenFolderPanel("import male fold", "C:/Users/Administrator/Desktop", "");
        files = PathHelper.getAllChildFiles(path, ".fbx,.png");
    }

    public override string TargetFold
    {
        get { return string.Format("{0}/Tmp/FBX/{1}",Application.dataPath,CharacterConst.Male); }
    }

    public override string name
    {
        get { return EnumCharacterType.Charater_Male.ToString(); }
    }
}
#endif
