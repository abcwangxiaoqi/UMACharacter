using UnityEngine;
using System.Collections;

public class SOAService_Resource_Character_ICON : SOAService_Resource_Character
{
    string path = "";
    public SOAService_Resource_Character_ICON(string _name)
    {
        path = string.Format("/{0}/icon/{1}.png", rootFold, _name);
    }

    Request request;

    public override void Run()
    {
        SOAData_Resource sr = CacheManager.Get<SOAData_Resource>(path);
        if (sr != null)
        {
            CallBack(sr);        
          //  CacheManager.Destory<SOAData_Resource>(path);
        }
        else
        {
            if (CharacterConst.useLocalServer)
            {
                request = new CharacterLocalServerRequest(path);
            }
            else
            {
                request = new OtherRequest(path);
            }
            request.AddListener(RequestComplete);
            request.Connect();
        }
    }

    void RequestComplete(ResponseData data)
    {
        SOAData_Resource sr = null;
        if(data.success)
        {
            sr = new SOAData_Resource(data, null);
            CacheManager.Insert<SOAData_Resource>(path, sr,true);
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
        if(request!=null)
        {
            request.Stop();
        }
    }
}
