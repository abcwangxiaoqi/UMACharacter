/// <summary>
/// 角色数据请求
/// </summary>
public class CharacterRequest : ResRequest
{
    string name = "";
    bool local = false;
    public CharacterRequest(string _name,bool _local=false)
    {
        name = _name;
        local = _local;
    }

    protected override LoaderTask IniTask(LoaderContianer contianer)
    {
        LoaderTask task = null;
        if(local)
        {
            task = new LoaderTask(contianer, LoadType.LocalAB, name);
        }
        else
        {
            task = new LoaderTask(contianer, OutUri(name), null, header);
        }
        
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
            return 3;
        }
    }
}