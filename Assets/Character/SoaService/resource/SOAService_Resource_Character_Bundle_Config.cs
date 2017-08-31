using UnityEngine;
public class SOAService_Resource_Character_Bundle_Config : SOAService_Resource_Character_Bundle
{
    string filename = "characterconfig";
    protected override string bundleName
    {
        get
        {
            return string.Format("config/{0}.assetbundle", filename);
        }
    }

    protected override string name
    {
        get 
        {
            return filename;
        }
    }

    protected override string netpath
    {
        get 
        {
            return string.Format("/{0}/{1}/config/{2}.assetbundle", rootFold, platform, filename);
        }
    }

    protected override string localpath
    {
         get 
        {
            return string.Format("{0}/{1}/config/{2}.assetbundle", Application.persistentDataPath, rootFold, filename);
        }
    }
}
