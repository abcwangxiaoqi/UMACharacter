using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ClothModel
{
    public string wearpos { get; set; }
    public string resname { get; set; }
    public string icon { get; set; }
    public string itemid { get; set; }
    public string sex { get; set; }

    static bool isRead = false;
    static Dictionary<string, ClothModel> configDic = null;
    static List<ClothModel> configList = new List<ClothModel>();
    /// <summary>
    /// read avator' config, if local is not the newest,loaddown form service
    /// </summary>
    /// <returns></returns>
    static void read()
    {
        if (isRead)
            return;
        ICharacterSysConfig config=new CharacterSysConfig();
        TextAsset txt = config.ItemList;
        if (txt == null)
        {
            return;
        }
        string str = txt.text;
        configList = str.JsonTransferObject<List<ClothModel>>();

        configDic = new Dictionary<string, ClothModel>();

        if (configList == null)
            return;

        for (int i = 0; i < configList.Count; i++)
        {
            configDic[configList[i].itemid] = configList[i];
        }
        isRead = true;
    }


    /// <summary>
    /// get default cloths
    /// </summary>
    /// <param name="sex">sex</param>
    /// <param name="id">cloth id</param>
    /// <returns></returns>
    public static List<ClothModel> GetDefault(EnumCharacterType sex, int id = 1)
    {
        read();

        List<ClothModel> list = new List<ClothModel>();

        if (sex == EnumCharacterType.Charater_Female)
        {
            switch (id)
            {
                case 1:
                    list.Add(configDic["0202_0001"]);
                    list.Add(configDic["0204_0001"]);
                    list.Add(configDic["0205_0001"]);
                    list.Add(configDic["0206_0001"]);
                    break;
                case 2:
                    list.Add(configDic["0202_0002"]);
                    list.Add(configDic["0204_0002"]);
                    list.Add(configDic["0205_0002"]);
                    list.Add(configDic["0206_0002"]);
                    break;
                case 3:
                    list.Add(configDic["0202_0003"]);
                    list.Add(configDic["0204_0003"]);
                    list.Add(configDic["0205_0003"]);
                    list.Add(configDic["0206_0003"]);
                    break;
            }
        }
        else
        {
            switch (id)
            {
                case 1:
                    list.Add(configDic["0102_0001"]);
                    list.Add(configDic["0104_0001"]);
                    list.Add(configDic["0105_0001"]);
                    list.Add(configDic["0106_0001"]);
                    break;
                case 2:
                    list.Add(configDic["0102_0002"]);
                    list.Add(configDic["0104_0002"]);
                    list.Add(configDic["0105_0002"]);
                    list.Add(configDic["0106_0002"]);
                    break;
                case 3:
                    list.Add(configDic["0102_0003"]);
                    list.Add(configDic["0104_0003"]);
                    list.Add(configDic["0105_0003"]);
                    list.Add(configDic["0106_0003"]);
                    break;
            }
        }
        return list;
    }

    public static List<ClothModel> GetData()
    {
        read();
        return configList;
    }
}
