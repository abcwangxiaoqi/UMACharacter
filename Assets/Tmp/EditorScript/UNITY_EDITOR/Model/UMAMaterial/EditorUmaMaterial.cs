#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UMA;

abstract public class EditorUmaMaterial
{
    IObjectBase objectBase;
    public EditorUmaMaterial()
    {
        objectBase = new ObjectBase(Path);
    }

    abstract public string Path { get; }

    public UMAMaterial Load()
    {
        return objectBase.Load<UMAMaterial>();
    }
}

public static class EditorUmaMaterialFactory
{
    public static EditorUmaMaterial Creat(string name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        string type = name.Substring(2, 2);
        
        if(type==WearPosConst.WAER_POS_HAIR)
        {
            return new EditorUmaMaterial_Hair();
        }
        else if (type == WearPosConst.WAER_POS_CLOTH || 
            type == WearPosConst.WEAR_POS_PANT ||
            type == WearPosConst.WEAR_POS_SHOE)
        {
            return new EditorUmaMaterial_Cloth();
        }
        else
        {
            return new EditorUmaMaterial_Base();
        }
    }
}

public class EditorUmaMaterial_Hair : EditorUmaMaterial
{
    public override string Path
    {
        get { return "Assets/Tmp/MaterialSamples/Character-hair.asset"; }
    }
}

public class EditorUmaMaterial_Cloth : EditorUmaMaterial
{
    public override string Path
    {
        get { return "Assets/Tmp/MaterialSamples/Character-single-alphacutoff.asset"; }
    }
}
public class EditorUmaMaterial_Base : EditorUmaMaterial
{
    public override string Path
    {
        get { return "Assets/Tmp/MaterialSamples/Character-single.asset"; }
    }
}
#endif