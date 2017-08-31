/// <summary>
/// 资源请求
/// </summary>
using System.Collections.Generic;
public abstract class ResRequest : NetRequest
{
    string rooturi = "api/v1/resource/object";

    protected Dictionary<string, string> header
    {
        get
        {
            return SOAConst.GetHeaders("/platform/resource");
        }
    }

    protected string OutUri(string name,string bucket=SOAConst.NormalBucket)
    {
        string url = string.Format("{0}/{1}", SOAConst.URL, rooturi);

        Dictionary<string, string> form = new Dictionary<string, string>();
        form["name"] = name;
        form["bucket"] = bucket;
        form["zone"] = "pek3a";

        url = SOAConst.GetUrlByDic(url, form);
        return url.ToLower();
    }
}