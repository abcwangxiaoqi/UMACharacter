using UnityEngine;
public class SOAService_Resource_Character_Denpen : SOAService_Resource_Character
{
    string bundleName = "";
    string netpath = "";
    string localpath = "";
    public SOAService_Resource_Character_Denpen(string _name)
    {
        bundleName = _name;
        netpath = string.Format("/{0}/{1}/{2}", rootFold, platform,bundleName);
        localpath = string.Format("{0}/{1}/{2}", Application.persistentDataPath, rootFold, bundleName);
    }
    Request request = null;
    public override void Run()
    {
        if (IsUpdate(bundleName))
        {
            if (CharacterConst.useLocalServer)
            {
                request = new CharacterLocalServerRequest(netpath);
            }
            else
            {
                request = new CharacterRequest(netpath);
            }
        }
        else
        {
            request = new LocalABRequest(localpath);
        }
        request.AddListener(RequestComplete);
        request.Connect();
    }

    ResponseData currentData = null;
    void RequestComplete(ResponseData data)
    {
        if (data.success)
        {
            if (data.isWWW)
            {
                data.bytes.GetHashCode();
                data.bytes.SaveToLocal(localpath);
                UpdateCodeToConfig(bundleName);
            }
            currentData = data;

            //依赖文件需要缓存起来
            CacheManager.Insert<AssetBundle>(bundleName, data.ab, true);
        }
        else
        {            
            Debug.LogError(data.error);
            data.UnLoad();
        }
        CallBack(null);
    }

    public override void Stop()
    {
        request.Stop();
    }
}
