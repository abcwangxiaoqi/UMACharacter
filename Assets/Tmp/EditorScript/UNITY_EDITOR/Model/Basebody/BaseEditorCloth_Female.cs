#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class BaseEditorCloth_Female : BaseEditorCloth
{
    public BaseEditorCloth_Female(ECharacterResType type)
        : base(EnumCharacterType.Charater_Female, type)
    {
        string path = string.Format("{0}/{1}/{2}/{3}.fbx", CharacterConst.rootPath,restype.ToString(), CharacterConst.Female, CharacterConst.Female);
        obj = new FbxItem(path);
        obj.SetReadable(true);

        prefabFold = string.Format("{0}/{1}/{2}", CharacterConst.prefabPath, restype.ToString(),CharacterConst.Female);

        baseOverlayName = string.Format("{0}_{1}", CharacterConst.Female, CharacterConst.Base);
        string skin_d = string.Format("{0}/{1}/{2}/{3}_{4}.png", CharacterConst.rootPath, restype.ToString(),CharacterConst.Female, CharacterConst.Female, CharacterConst.Base);
        skin_diff = new ObjectBase(skin_d);
    }
}

#endif
