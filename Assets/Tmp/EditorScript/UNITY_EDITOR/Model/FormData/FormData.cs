#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

abstract public class FormData : IFormData
{
    public Dictionary<string, ClothModel> configDic;
    public FormData()
    {
        if (configDic==null)
        {
            configDic = new Dictionary<string, ClothModel>();

            TextAsset txt = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Tmp/Prefab/Resources/Config/ItemList.txt");
            List<ClothModel> list = txt.text.JsonTransferObject<List<ClothModel>>();
            for (int i = 0; i < list.Count; i++)
            {
                configDic[list[i].itemid] = list[i];
            }
        }
    }

    abstract public string filename { get; }
    abstract public string fold { get; }
    abstract public int Sex { get; }
    abstract public SkinColor color { get; }
    abstract public List<ClothModel> avatars { get; }
    public void CreatJson()
    {
        CharacterData Data = new CharacterData();
        Data.sex = Sex;
        //Data.skin = color;
        Data.avatars = avatars;

        string json = Data.JsonTransferString();
        FileHelper.CreatFile(fold, filename + ".txt", json);
    }
}
#endif
