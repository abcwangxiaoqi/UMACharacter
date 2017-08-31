using UnityEngine;

class RoleLoad : CharacterLoad
{

    ECharacterResType resType = ECharacterResType.Height;
    public RoleLoad(ECharacterResType type)
    {
        resType = type;
    }

    #region Temp
    CallBackWithParams<Object> tempcallback;
    CharacterData tempData;
    #endregion

    protected override void localLoadRes(object[] objs)
    {
        tempData = objs[0] as CharacterData;
        tempcallback = objs[1] as CallBackWithParams<Object>;

        string sexFold = CharacterConst.Female;
        string name = CharacterConst.Female;
        if (tempData.sex == (int)EnumCharacterType.Charater_Male)
        {
            sexFold = CharacterConst.Male;
            name = CharacterConst.Male;
        }
        string prefab = string.Format("{0}/{1}/{2}",resType.ToString(), sexFold, name);
        Debug.Log(prefab);
        Object go = Resources.Load<Object>(prefab);
        tempcallback(go);
    }

    SOAService_Resource_Character request = null;
    protected override void webLoadRes(object[] objs)
    {
        tempData = objs[0] as CharacterData;
        tempcallback = objs[1] as CallBackWithParams<Object>;
        
        if(tempData.sex==(int)EnumCharacterType.Charater_Female)
        {
            request = new SOAService_Resource_Character_Bundle_Female(resType,CharacterConst.Female);
        }
        else
        {
            request = new SOAService_Resource_Character_Bundle_Male(resType,CharacterConst.Male);
        }
        request.AddListener(LoadComplete);     
        request.Run();
    }

    void LoadComplete(SOAData_Resource data)
    {
        if (tempcallback != null)
        {
            tempcallback(data.obj);
        }
    }

    public override void Stop()
    {
        if (request != null)
        {
            request.Stop();
        }
    }
}