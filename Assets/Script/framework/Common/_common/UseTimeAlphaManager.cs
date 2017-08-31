/*
 * 耗时测试脚本
 */
using UnityEngine;
using System.Collections.Generic;

public class UseTimeAlphaManager
{
    #region key

    public const string LoadRole = "加载对象耗时";

    #endregion
    static Dictionary<string, float> timeMap = new Dictionary<string, float>();
    public static void StartTimeAlpha(string key)
    {
        timeMap.Add(key, Time.realtimeSinceStartup);        
    }
    public static void OverTimeAlpha(string key)
    {
        if (!timeMap.ContainsKey(key)) return;
        float t = Time.realtimeSinceStartup - timeMap[key];
        timeMap.Remove(key);
        Debug.LogError(key+"耗时:"+t);
    }
}
