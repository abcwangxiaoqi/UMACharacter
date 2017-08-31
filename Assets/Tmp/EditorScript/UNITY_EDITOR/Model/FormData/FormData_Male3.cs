#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormData_Male3 : FormData
{
    public override string filename
    {
        get { return "3"; }
    }

    public override string fold
    {
        get { return "Assets/Tmp/FormConfig/男"; }
    }

    public override List<ClothModel> avatars 
    {
        get
        {
            List<ClothModel> list = new List<ClothModel>();
            list.Add(configDic["0102_0003"]);
            list.Add(configDic["0104_0003"]);
            list.Add(configDic["0105_0003"]);
            list.Add(configDic["0106_0003"]);
            return list;
        }
    }

    public override int Sex
    {
        get { return 0; }
    }

    public override SkinColor color
    {
        get { return SkinColor.transfer(Color.white); }
    }
}
#endif
