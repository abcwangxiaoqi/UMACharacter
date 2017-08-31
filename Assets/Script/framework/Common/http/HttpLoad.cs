using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HttpLoad : LoadBase
{
    enum LoadType
    {
        Get,
        Post,
        PostHeader
    }

    LoadType loadType = LoadType.Get;

    public HttpLoad(string _url, bool net = true)
        : base(net)
    {
        success = true;
        if (!_url.StartsWith("file:///") && !_url.StartsWith("http://"))
        {
            url = "file:///" + _url.Replace("/","\\");
        }
        else
        {
            url =  _url;
        }
        loadType = LoadType.Get;
    }

    WWWForm form;
    public HttpLoad(string _url, WWWForm _form)
        : base(true)
    {
        success = true;
        if (!_url.StartsWith("file:///") && !_url.StartsWith("http://"))
        {
            url = "file:///" + _url;
        }
        else
        {
            url = _url;
        }
        form = _form;
        loadType = LoadType.Post;
    }

    byte[] postdata;
    Dictionary<string, string> header;
    public HttpLoad(string _url, byte[] _postdata, Dictionary<string, string> _header)
        : base(true)
    {
        success = true;
        if (!_url.StartsWith("file:///") && !_url.StartsWith("http://"))
        {
            url = "file:///" + _url;
        }
        else
        {
            url = _url;
        }

        postdata = _postdata;
        header = _header;

        loadType = LoadType.PostHeader;
    }

    /// <summary>
    /// get
    /// </summary>
    /// <returns></returns>
    public override SimpleTask Load()
    {
        if(loadType==LoadType.Get)
        {
            task = new SimpleTask(request());
        }
        else if (loadType == LoadType.Post)
        {
            task = new SimpleTask(request(form));
        }
        else if (loadType == LoadType.PostHeader)
        {
            task = new SimpleTask(request(postdata, header));
        }
        return task;
    }

    IEnumerator request(byte[] postdata, Dictionary<string, string> header)
    {
        using(WWW www = new WWW(url, postdata, header))
        {
            yield return www;
            Debug.Log("http:" + url);
            if (www.error != null)
            {
                success = false;
                error = www.error;
                yield break;
            }
            ab = www.assetBundle;
            text = www.text;
            texture = www.texture;
            bytes = www.bytes;
        }       
    }

    IEnumerator request(WWWForm form)
    {
        using(WWW www = new WWW(url, form))
        {
            yield return www;
            Debug.Log("http:" + url);
            if (www.error != null)
            {
                success = false;
                error = www.error;
                yield break;
            }
            ab = www.assetBundle;
            text = www.text;
            texture = www.texture;
            bytes = www.bytes;
        }       
    }

    IEnumerator request()
    {
        using(WWW www = new WWW(url))
        {
            yield return www;
            Debug.Log("http:" + url);
            if (www.error != null)
            {
                success = false;
                error = www.error;
                yield break;
            }
            ab = www.assetBundle;
            text = www.text;
            texture = www.texture;
            bytes = www.bytes;
        }        
    }
}
