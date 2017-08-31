
using UnityEngine;
public class SOAService_Resource_Character_Manifest : SOAService_Resource_Character
{
    string path = "";
    public SOAService_Resource_Character_Manifest()
    {
        path = string.Format("/{0}/{1}/{2}",rootFold, platform, platform);
    }

    Request request;
    public override void Run()
    {
        if (CharacterConst.useLocalServer)
        {
            request = new CharacterLocalServerRequest(path);
        }
        else
        {
            request = new CharacterRequest(path);
        }
        request.AddListener(RequestComplete);
        request.Connect();
    }

    void RequestComplete(ResponseData data)
    {
        SOAData_Resource sr = null;
        if(data.success)
        {
            sr = new SOAData_Resource(data, "AssetBundleManifest");
            CacheManager.Insert<SOAData_Resource>(CacheKeys.CharacterManifest, sr);
        }
        else
        {
            Debug.LogError(data.error);
        }
        data.UnLoad();
        CallBack(sr);
    }

    public override void Stop()
    {
        throw new System.NotImplementedException();
    }
}
