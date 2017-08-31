#if UNITY_EDITOR
using UnityEngine;
using System.Collections;


public class BaseEditorCloth_Male : BaseEditorCloth
{
    public BaseEditorCloth_Male(ECharacterResType type)
        : base(EnumCharacterType.Charater_Male, type)
    {
        string path = string.Format("{0}/{1}/{2}/{3}.fbx", CharacterConst.rootPath, restype.ToString(), CharacterConst.Male, CharacterConst.Male);
        obj = new FbxItem(path);
        obj.SetReadable(true);

        prefabFold = string.Format("{0}/{1}/{2}", CharacterConst.prefabPath, restype.ToString(), CharacterConst.Male);

        baseOverlayName = string.Format("{0}_{1}", CharacterConst.Male, CharacterConst.Base);
        string skin_d = string.Format("{0}/{1}/{2}/{3}_{4}.png", CharacterConst.rootPath, restype.ToString(), CharacterConst.Male, CharacterConst.Male, CharacterConst.Base);
        skin_diff = new ObjectBase(skin_d);
    }
}
#endif
