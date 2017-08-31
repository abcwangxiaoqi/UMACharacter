
using System;
using System.Collections.Generic;
using System.Text;
public static class SOAConst
{
    public const string NormalBucket = "jhtest";
    public const string GeoBucket = "artistwork";

    public static string URL
    {
        get
        {
            return Global.GatewayUrl;
        }
    }

    public static Dictionary<string, string> GetHeaders(string ServiceName,string method = "GET")
    {
        Dictionary<string, string> header = new Dictionary<string, string>();
        header["appId"] = Global.AppID;
        header["nonce"] = DateTime.UtcNow.Millisecond.ToString();
        header["service"] = ServiceName;
        header["timestamp"] = string.Format("{0}Z", DateTime.UtcNow.ToString("s"));

        StringBuilder sb = new StringBuilder();

        sb.AppendFormat("{0}\n{1}\n", method, ServiceName);
        header.Foreach<string, string>((string key, string v) =>
        {
            sb.AppendFormat("{0}={1}&", key, v);
            return true;
        });

        header["sign"] = Utils.GetHMACSHA256Base64String(sb.ToString().TrimEnd('&'), Global.AppKey);
        return header;
    }

    public static string GetUrlByDic(string url,Dictionary<string,string> parmters)
    {
        if (parmters == null)
            return url;

        StringBuilder sb = new StringBuilder();
        parmters.Foreach<string, string>((string key, string val) =>
        {
            sb.AppendFormat("{0}={1}&", key, val);
            return true;
        });

        string UrlContent = sb.ToString().TrimEnd('&');
        url = string.Format("{0}?{1}", url, UrlContent);
        return url;
    }
}
