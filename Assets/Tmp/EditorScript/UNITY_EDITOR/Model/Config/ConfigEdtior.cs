#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EditorItemList
{
    string name = "";
    string fold = "";
    public EditorItemList()
    {
        fold = Application.dataPath + "/Tmp/Prefab/Resources/Config";
        name = "ItemList.txt";
    }

    public void Initiliaze()
    {
        int index = 1;
        List<string> files = PathHelper.getAllChildFiles(CharacterConst.prefabPath+"/"+CharacterConst.ResHeight, ".prefab");
        List<ClothModel> xmls = new List<ClothModel>();
        for (int i = 0; i < files.Count; i++)
        {
            IObjectBase objBase = new ObjectBase(files[i]);
            GameObject obj = objBase.Load<GameObject>();

            string sex = objBase.Name.Substring(0, 2);
            if (sex != "01" && sex != "02")
            {
                continue;
            }

            if (!obj.GetComponent<SlotOverlay>())
            {
                continue;
            }

            ClothModel xl = EditorUtil.CreateClothModelByAsset(objBase);
            xmls.Add(xl);
            index++;
        }
        string json = xmls.JsonTransferString();
        FileHelper.CreatFile(fold, name, json);
        AssetDatabase.Refresh();
    }

    public TextAsset Get()
    {
        string assetpath = fold + "/" + name;
        ObjectBase o = new ObjectBase(assetpath);
        return o.Load() as TextAsset;
    }
}

public class EditorConfigPrefab
{
    IPrefabItem prefabItem;
    public EditorConfigPrefab()
    {
        prefabItem = new PrefabItem("Assets/Tmp/Prefab/Resources/Config/CharacterConfig.prefab");
    }    

    public void Initiliaze()
    {
        prefabItem.CreatPrefab(null, CreatePrefab); 
    }

    void CreatePrefab(GameObject go,Dictionary<string,object> parms)
    {
        EditorItemList list = new EditorItemList();
        list.Initiliaze();
        CharacterConfig config=go.GetComponent<CharacterConfig>();
        if(config==null)
        {
            config = go.AddComponent<CharacterConfig>();
        }
        config.ItemList = list.Get();
    }
}
#endif