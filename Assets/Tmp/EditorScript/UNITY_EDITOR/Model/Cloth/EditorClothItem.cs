#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UMA;
using UnityEngine;
public abstract class EditorClothItem : IEditorCloth
{
    IObjectBase obj = null;
    IObjectBase texture_diffuse = null;//diffuseÌùÍ¼

    string Fold = "";
    IPrefabItem prefab;
    string wearpos = "";

    ECharacterResType restype = ECharacterResType.Height;
    public EditorClothItem(IObjectBase _obj, IObjectBase diffuse,ECharacterResType type)
    {
        restype = type;
        obj = _obj;

        texture_diffuse = diffuse;

        Fold = string.Format("{0}/{1}/{2}/{3}", CharacterConst.prefabPath, restype.ToString(), SexName, obj.Name);

        string assetpath = string.Format("{0}/{1}/{2}/{3}/{4}.prefab", CharacterConst.prefabPath,restype.ToString(), SexName, obj.Name, obj.Name);
        prefab = new PrefabItem(assetpath);

        wearpos = obj.Name.Substring(2, 2);
    }

    abstract public string SexName { get; }

    public void CreatPrefab()
    {
        EditorUmaMaterial uMaterial = EditorUmaMaterialFactory.Creat(obj.Name);
        Texture2D dif = texture_diffuse.Load<Texture2D>();

        ClothSlotOverlay cso = new ClothSlotOverlay(obj, dif, Fold, uMaterial, restype);
        List<SlotOverlayItem> sos = cso.CreatData();

        if (sos == null)
        {
            return;
        }

        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic["sos"] = sos;
        prefab.CreatPrefab(null,createPrefabFinish, dic);
    }

    void createPrefabFinish(GameObject go, Dictionary<string, object> paramters)
    {
        string name = prefab.Name;
        SlotOverlay so = go.AddComponent<SlotOverlay>();
        so.slotoverlays = paramters["sos"] as List<SlotOverlayItem>;
    }
}

public static class EditorClothItemFactory
{
    public static IEditorCloth Creat(EnumCharacterType sex,IObjectBase _obj, IObjectBase diffuse,ECharacterResType type)
    {
        if(sex==EnumCharacterType.Charater_Female)
        {
            return new EditorClothItem_Female(_obj, diffuse, type);
        }
        else
        {
            return new EditorClothItem_Male(_obj, diffuse, type);
        }
    }
}

public class EditorClothItem_Female : EditorClothItem
{
    public EditorClothItem_Female(IObjectBase _obj, IObjectBase diffuse,ECharacterResType type)
        : base(_obj, diffuse, type)
    {

    }

    public override string SexName
    {
        get { return CharacterConst.Female; }
    }
}

public class EditorClothItem_Male : EditorClothItem
{
    public EditorClothItem_Male(IObjectBase _obj, IObjectBase diffuse, ECharacterResType type = ECharacterResType.Height)
        : base(_obj, diffuse, type)
    {

    }
    public override string SexName
    {
        get { return CharacterConst.Male; }
    }
}
#endif