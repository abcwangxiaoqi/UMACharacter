using UnityEngine;
using System.Collections.Generic;

public static class Debuger
{
    static bool rootSwitch = true;

    #region config
    // config switch ,if not contain key ,defalt true
    static Dictionary<EnumLogType, bool> configSwitch = new Dictionary<EnumLogType, bool>()
    {
        {EnumLogType.None,true}
    };
    #endregion

    #region log
    static public void Log(object message, EnumLogType type = EnumLogType.None)
    {
        Log(message, null, type);
    }
    static public void Log(object message, Object context, EnumLogType type = EnumLogType.None)
    {
        if (!rootSwitch)
            return;

        if (configSwitch.ContainsKey(type))
        {
            if (configSwitch[type])
            {
                Debug.Log(message, context);
            }
        }
        else
        {
            Debug.Log(message, context);
        }
    }
    #endregion

    #region error
    static public void LogError(object message, EnumLogType type = EnumLogType.None)
    {
        LogError(message, null, type);
    }
    static public void LogError(object message, Object context, EnumLogType type = EnumLogType.None)
    {
        if (!rootSwitch)
            return;

        if (configSwitch.ContainsKey(type))
        {
            if (configSwitch[type])
            {
                Debug.LogError(message, context);
            }
        }
        else
        {
            Debug.LogError(message, context);
        }
    }
    #endregion

    #region warning
    static public void LogWarning(object message, EnumLogType type = EnumLogType.None)
    {
        LogWarning(message, null, type);
    }
    static public void LogWarning(object message, Object context, EnumLogType type = EnumLogType.None)
    {
        if (!rootSwitch)
            return;

        if (configSwitch.ContainsKey(type))
        {
            if (configSwitch[type])
            {
                Debug.LogWarning(message, context);
            }
        }
        else
        {
            Debug.LogWarning(message, context);
        }
    }
    #endregion
}

public enum EnumLogType
{
    None,
}


