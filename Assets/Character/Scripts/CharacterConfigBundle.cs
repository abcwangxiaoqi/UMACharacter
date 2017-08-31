using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class CharacterConfigBundle
{
    static CharacterConfigBundle instance = null;
    public static CharacterConfigBundle Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CharacterConfigBundle();
            }
            return instance;
        }
    }
    Dictionary<string, int> configData;
    AssetBundleManifest manifest;
    public CharacterConfigBundle()
    {
        manifest = CacheManager.Get<AssetBundleManifest>(CacheKeys.CharacterManifest);

        string configPath = string.Format("{0}/characters/config.Rec", Application.persistentDataPath);
        configData = new Dictionary<string, int>();
        if (File.Exists(configPath))
        {
            configData = configPath.ReadFromLocal<Dictionary<string, int>>();
        }

        //定义保存
        GameMain.Instacne.destroyHandle += () =>
        {
            configData.SaveToLocal<Dictionary<string, int>>(configPath);
        };
    }

    public bool OutUrl(string name, out string url)
    {
        if (configData.ContainsKey(name))
        {
            int manifestCode = 0;
            if (manifest != null)
            {
                manifestCode = manifest.GetAssetBundleHash(name).GetHashCode();
            }

            int localCode = configData[name];
            if (localCode != manifestCode)
            {
                //网络地址
                url = "";
                return true;
            }
            else
            {
                //本地地址
                url = "";
                return false;
            }
        }
        else
        {
            //网络地址
            url = "";
            return true;
        }
    }

    public string[] GetDenpen(string name)
    {
        return manifest.GetAllDependencies(name);
    }

    public void UpdateCode(string name)
    {
        configData[name] = manifest.GetAssetBundleHash(name).GetHashCode();
    }
}
