using UnityEngine;

class ClothLoad : CharacterLoad
{
    
    ECharacterResType resType = ECharacterResType.Height;
    public ClothLoad(ECharacterResType type)
    {
        resType = type;
    }

    CallBackWithParams<Object> tempCallback;
    ClothModel cm;

    protected override void localLoadRes(object[] objs)
    {
        cm = objs[0] as ClothModel;
        tempCallback = objs[1] as CallBackWithParams<Object>;

        string sexFold = CharacterConst.Female;
        if (cm.sex == "01")
        {
            sexFold = CharacterConst.Male;
        }
        string prefab = string.Format("{0}/{1}/{2}/{3}",resType.ToString(), sexFold, cm.resname, cm.resname);
        Debug.Log(prefab);
        Object go = Resources.Load<Object>(prefab);
        tempCallback(go);
    }
    SOAService_Resource_Character request = null;
    protected override void webLoadRes(object[] objs)
    {
        cm = objs[0] as ClothModel;
        tempCallback = objs[1] as CallBackWithParams<Object>;

       
        if(cm.sex=="01")
        {
            request = new SOAService_Resource_Character_Bundle_Male(resType,cm.resname);
        }
        else
        {
            request = new SOAService_Resource_Character_Bundle_Female(resType,cm.resname);
        }
        request.AddListener(LoadComplelte);
        request.Run();
    }

    void LoadComplelte(SOAData_Resource data)
    {
        if (tempCallback != null)
        {
            tempCallback(data.obj);
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
