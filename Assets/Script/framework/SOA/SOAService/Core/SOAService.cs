using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class SOAService<T>
    where T: SOAServiceData
{
    public SOAService()
    {
    }

    #region actioin
    public abstract void Run();
    public abstract void Stop();

    #endregion

    #region callback
    CallBackWithParams<T> callback = null;
    public void AddListener(CallBackWithParams<T> _callback)
    {
        if (_callback != null)
        {
            callback += _callback;
        }
    }

    protected void CallBack(T data)
    {
        if (callback != null)
        {
            callback(data);
        }
    }
    #endregion
}