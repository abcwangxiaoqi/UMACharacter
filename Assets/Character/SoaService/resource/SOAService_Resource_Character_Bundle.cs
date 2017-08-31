using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public abstract class SOAService_Resource_Character_Bundle : SOAService_Resource_Character
{
    static CharacterManifestDenpenLoad manifest;

    public override void Run()
    {
        stopFlag = false;
        SOAData_Resource sr = CacheManager.Get<SOAData_Resource>(bundleName);
        if(sr!=null)
        {
            CacheManager.Destory<SOAData_Resource>(bundleName);
            CallBack(sr);
        }
        else
        {
            LoadTarget();
        }
    }

    Request request;
    void LoadTarget()
    {
        if (stopFlag)
            return;

        bool needupdate = IsUpdate(bundleName);
        if (!needupdate)
        {
            request = new LocalABRequest(localpath);
        }
        else
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
        request.AddListener(RequestComplete);
        request.Connect();
    }

    void RequestComplete(ResponseData data)
    {
        SOAData_Resource sr =null;
        if(data.success)
        {
            if(data.isWWW)
            {
                data.bytes.SaveToLocal(localpath);
                UpdateCodeToConfig(bundleName);
            }
            sr = new SOAData_Resource(data, name);
            CacheManager.Insert<SOAData_Resource>(bundleName, sr);
        }
        else
        {
            Debug.LogError(data.error);
        }
        data.UnLoad();
        CallBack(sr);
    }

    bool stopFlag = false;
    public override void Stop()
    {        
        stopFlag = true;
        if (request!=null)
        {
            request.Stop();
        }
    }
    protected abstract string bundleName { get; }
    protected abstract string name { get; }
    protected abstract string netpath { get; }
    protected abstract string localpath { get; }  

}
