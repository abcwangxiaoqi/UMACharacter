#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UMA;

public interface IEditorBundleName
{
    void SetBundle();
}

abstract public class EditorBundleName : IEditorBundleName
{
    abstract public string Fold { get; }
    abstract public string Checkfiles { get; }
    abstract public void Operation(IObjectBase ob);

    public void SetBundle()
    {
        string path = CharacterConst.prefabPath + "/" + Fold;
        List<string> files = PathHelper.getAllChildFiles(path, Checkfiles);
        for (int i = 0; i < files.Count; i++)
        {
            IObjectBase obj = new ObjectBase(files[i]);
            Operation(obj);
        }
    }
}

public class EditorBundleName_Config : EditorBundleName
{
    public override string Fold
    {
        get { return "Config"; }
    }

    public override string Checkfiles
    {
        get { return ".prefab"; }
    }

    public override void Operation(IObjectBase ob)
    {
        string bundleName = string.Format("{0}/{1}.assetbundle", Fold, ob.Name);
        ob.SetAssetbundleName(bundleName);
        ob.Save();
    }
}

class EditorBundleName_Common
{
    IObjectBase obj;
    ECharacterResType resType = ECharacterResType.Height;
    public EditorBundleName_Common(IObjectBase _obj,ECharacterResType type)
    {
        obj = _obj;
        resType = type;
    }

    public void Initilize()
    {
        string comBundle = "common/common.assetbundle";
        string[] dependencies = obj.GetDependencies();
        for (int i = 0; i < dependencies.Length; i++)
        {
            IObjectBase dep = new ObjectBase(dependencies[i]);

            if (dep.Type == ".png")
            {
                if (dep.Name.Contains("_" + CharacterConst.Common))
                {
                    dep.SetAssetbundleName(comBundle);
                }
                else
                {
                    dep.SetAssetbundleName(null);
                }
            }
            else if (dep.Type == ".asset")
            {
                dep.SetAssetbundleName(null);
                UMAMaterial mat = dep.Load() as UMAMaterial;
                if (mat != null)
                {
                    dep.SetAssetbundleName(comBundle);
                }
            }
            dep.Save();
        }
    }
}

public class EditorBundleName_HumanFemale : EditorBundleName
{
    ECharacterResType resType = ECharacterResType.Height;
    public EditorBundleName_HumanFemale(ECharacterResType type)
    {
        resType = type;
    }

    public override string Fold
    {
        get
        {
            return string.Format("{0}/{1}", resType.ToString(), CharacterConst.Female);
        }
    }

    public override string Checkfiles
    {
        get { return ".prefab"; }
    }

    public override void Operation(IObjectBase ob)
    {
        string name = ob.Name;
        if (name.EndsWith("_Skinned"))
        {
            return;
        }

        string bundleName = string.Format("{0}/{1}.assetbundle", Fold, ob.Name);
        ob.SetAssetbundleName(bundleName);
        ob.Save();

        EditorBundleName_Common common = new EditorBundleName_Common(ob, resType);
        common.Initilize();
    }
}
public class EditorBundleName_HumanMale : EditorBundleName
{
    ECharacterResType resType = ECharacterResType.Height;
    public EditorBundleName_HumanMale(ECharacterResType type)
    {
        resType = type;
    }
    public override string Fold
    {
        get
        {
            return string.Format("{0}/{1}", resType.ToString(), CharacterConst.Male);
        }
    }

    public override string Checkfiles
    {
        get { return ".prefab"; }
    }

    public override void Operation(IObjectBase ob)
    {

        string name = ob.Name;
        if (name.EndsWith("_Skinned"))
        {
            return;
        }
        string bundleName = string.Format("{0}/{1}.assetbundle", Fold, ob.Name);
        ob.SetAssetbundleName(bundleName);
        ob.Save();

        EditorBundleName_Common common = new EditorBundleName_Common(ob, resType);
        common.Initilize();
    }
}
#endif