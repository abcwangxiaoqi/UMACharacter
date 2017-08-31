
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public abstract class SOAService_Resource_Character : SOAService_Resource
{
    protected string rootFold = "characters";

    protected string platform =
#if UNITY_ANDROID
 "android";
#elif UNITY_IOS || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IPHONE
 "ios";
#else
 "win";
#endif

    static Dictionary<string, int> configData;
    public SOAService_Resource_Character()
    {
        if (configData == null)
        {
            string configPath = string.Format("{0}/{1}/config.Rec", Application.persistentDataPath, rootFold);
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
    }

    /// <summary>
    /// 是否从服务器获取地址
    /// </summary>
    /// <returns></returns>
    protected bool IsUpdate(string bundleName)
    {
        if (!configData.ContainsKey(bundleName))
            return true;

        AssetBundleManifest manifest = CacheManager.Get<AssetBundleManifest>(CacheKeys.CharacterManifest);
        int manifestCode = 0;
        if (manifest != null)
        {
            manifestCode = manifest.GetAssetBundleHash(bundleName).GetHashCode();
        }

        int localCode = configData[bundleName];
        if (localCode != manifestCode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void UpdateCodeToConfig(string bundleName)
    {
        if(string.IsNullOrEmpty(bundleName))
        {
            return;
        }

        AssetBundleManifest manifest = CacheManager.Get<AssetBundleManifest>(CacheKeys.CharacterManifest);
        if (manifest != null)
        {
            int code = manifest.GetAssetBundleHash(bundleName).GetHashCode();
            configData[bundleName] = code;
        }
    }
}
