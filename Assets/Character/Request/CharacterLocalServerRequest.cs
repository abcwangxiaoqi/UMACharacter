using UnityEngine;
using System.Collections;

public class CharacterLocalServerRequest : ResRequest
{
    string name = "";
    public CharacterLocalServerRequest(string _name)
    {
        name = _name;
    }

    protected string GetLocalServer()
    {
        return string.Format("http://192.168.31.103:80{0}", name);
    }

    protected override LoaderTask IniTask(LoaderContianer contianer)
    {
        LoaderTask task = new LoaderTask(contianer, LoadType.Get,GetLocalServer());
        return task;
    }

    protected override string contianerKey
    {
        get
        {
            return ELoaderContianerKey.RESCHARACTERREQ;
        }
    }

    protected override int contianerReqNum
    {
        get
        {
            return 1;
        }
    }
}
