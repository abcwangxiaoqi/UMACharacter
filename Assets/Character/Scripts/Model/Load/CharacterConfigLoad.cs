using UnityEngine;

public class CharacterConfigLoad : CharacterLoad
{
    CallBackWithParams<Object> callback = null;
    protected override void localLoadRes(object[] objs)
    {
        callback = objs[0] as CallBackWithParams<Object>;
        Object o = Resources.Load("Config/CharacterConfig");
        if (callback != null)
        {
            callback(o);
        }
    }

    SOAService_Resource_Character request = null;
    protected override void webLoadRes(object[] objs)
    {
        callback = objs[0] as CallBackWithParams<Object>;

        request = new SOAService_Resource_Character_Bundle_Config();
        request.AddListener(LoadComplete);        
        request.Run();
    }

    void LoadComplete(SOAData_Resource data)
    {
        if (callback != null)
        {
            callback(data.obj);
        }
    }

    public override void Stop()
    {
        if(request!=null)
        { 
            request.Stop();
        }
    }
}
