using UnityEngine;
using System.IO;
public class SOAService_Resource_Character_Bundle_Male : SOAService_Resource_Character_Bundle
{
    string Name = "";
    ECharacterResType resType = ECharacterResType.Height;
    public SOAService_Resource_Character_Bundle_Male(ECharacterResType type, string _name)
    {
        resType = type;
        Name = _name;
    }

    protected override string bundleName
    {
        get
        {
            return string.Format("{0}/{1}/{2}.assetbundle", resType.ToString().ToLower(), CharacterConst.Male, Name);
        }
    }

    protected override string name
    {
        get { return Name; }
    }

    protected override string netpath
    {
        get
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}.assetbundle", rootFold, platform, resType.ToString().ToLower(), CharacterConst.Male, Name);
        }
    }

    protected override string localpath
    {
        get
        {
            return string.Format("{0}/{1}/{2}/{3}/{4}.assetbundle", Application.persistentDataPath, rootFold, resType.ToString().ToLower(), CharacterConst.Male, Name);
        }
    }
}
