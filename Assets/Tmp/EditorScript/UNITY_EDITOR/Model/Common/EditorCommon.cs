#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UMA;

public abstract class EditorCommon
{
    public static OverlayDataAsset Get(string sex,string fold,string name)
    {
        EditorCommon ec = null;
        if(sex==CharacterConst.Female)
        {
            ec = new EditorCommon_Female(fold,name);
        }
        else if(sex==CharacterConst.Male)
        {
            ec = new EditorCommon_Male(fold, name);
        }
        return ec.GetOverlay();
    }

    string Fold = "";
    string Name = "";
    public EditorCommon(string fold,string name)
    {
        Fold = fold;
        Name = name;
    }

    public OverlayDataAsset GetOverlay()
    {
        #region 创建
        EditorUmaMaterial uMaterial = EditorUmaMaterialFactory.Creat(Name);

        IObjectBase texture_diffuse = new ObjectBase(texturePath);
        (new CharacterTexture(texturePath)).Handle();
        Texture2D dif = texture_diffuse.Load<Texture2D>();

        OverlayEditor oeditor = new OverlayEditor(Fold, dif, Name, uMaterial);
        OverlayDataAsset overlay = oeditor.CreatOverlay();
        #endregion
        return overlay;
    }
    abstract protected string texturePath { get; }
    abstract protected string SexName { get; }
}

public class EditorCommon_Female : EditorCommon
{
    public EditorCommon_Female(string fold, string name):
        base(fold,name)
    {

    }

    protected override string texturePath
    {
        get
        {
            return string.Format("{0}/{1}/{2}_{3}.png", CharacterConst.rootPath, CharacterConst.Female, CharacterConst.Female,CharacterConst.Common);
        }
    }

    protected override string SexName
    {
        get { return CharacterConst.Female; }
    }
}


public class EditorCommon_Male : EditorCommon
{
    public EditorCommon_Male(string fold, string name) :
        base(fold,name)
    {

    }

    protected override string texturePath
    {
        get
        {
            return string.Format("{0}/{1}/{2}_{3}.png", CharacterConst.rootPath, CharacterConst.Male, CharacterConst.Male, CharacterConst.Common);
        }
    }



    protected override string SexName
    {
        get { return CharacterConst.Male; }
    }
}
#endif
