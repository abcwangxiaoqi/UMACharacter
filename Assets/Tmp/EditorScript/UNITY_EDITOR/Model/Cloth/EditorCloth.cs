#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public abstract class EditorCloth : IEditorCloth
{
    abstract public string sexFold { get; }
    abstract public EnumCharacterType sex { get; }

    protected ECharacterResType resType = ECharacterResType.Height;
    public EditorCloth(ECharacterResType type)
    {
        resType = type;
    }

    public void CreatPrefab()
    {
        List<string> files = PathHelper.getAllChildFiles(sexFold, ".fbx");
        for (int i = 0; i < files.Count; i++)
        {            
            string filename = FileHelper.getFileNameNoTypeByPath(files[i]);
            EditorUtility.DisplayProgressBar(sex.ToString(), string.Format("{0}:{1}/{2}", filename, i + 1,files.Count ),(i + 1) / (float)files.Count);
            if (filename.Contains("@") ||
                filename.Contains(CharacterConst.Female) ||
                filename.Contains(CharacterConst.Male))
            {
                continue;
            }

            string assetpath = PathHelper.GetRelativeAssetPath(files[i]);
            IObjectBase obj = new ObjectBase(assetpath);

            string diffusepath = sexFold + "/" + filename + ".png";
            IObjectBase texture_diffuse = new ObjectBase(diffusepath);
            (new CharacterTexture(diffusepath)).Handle();

            IEditorCloth clothitem = EditorClothItemFactory.Creat(sex, obj, texture_diffuse,resType);
            clothitem.CreatPrefab();
        }
    }
}

public static class EditorClothFactory
{
    public static IEditorCloth Creat(EnumCharacterType sex,ECharacterResType type)
    {
        if(sex==EnumCharacterType.Charater_Female)
        {
            return new EditorCloth_Female(type);
        }
        else 
        {
            return new EditorCloth_Male(type);
        }
    }
}

public class EditorCloth_Female : EditorCloth
{
    public EditorCloth_Female(ECharacterResType type)
        : base(type)
    { }

    public override string sexFold
    {
        get { return string.Format("{0}/{1}/{2}", CharacterConst.rootPath,resType.ToString(), CharacterConst.Female); }
    }

    public override EnumCharacterType sex
    {
        get { return EnumCharacterType.Charater_Female; }
    }
}
public class EditorCloth_Male : EditorCloth
{
    public EditorCloth_Male(ECharacterResType type)
        : base(type)
    { }

    public override string sexFold
    {
        get { return string.Format("{0}/{1}/{2}", CharacterConst.rootPath, resType.ToString(), CharacterConst.Male); }
    }
    public override EnumCharacterType sex
    {
        get { return EnumCharacterType.Charater_Male; }
    }
}
#endif