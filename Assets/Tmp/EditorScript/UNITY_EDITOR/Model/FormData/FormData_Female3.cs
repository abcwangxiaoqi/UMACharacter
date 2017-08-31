#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormData_Female3 : FormData
{
    public override string filename
    {
        get { return "3"; }
    }

    public override string fold
    {
        get { return "Assets/Tmp/FormConfig/女"; }
    }

    public override List<ClothModel> avatars 
    {
        get
        {
            List<ClothModel> list = new List<ClothModel>();
            list.Add(configDic["0202_0003"]);
            list.Add(configDic["0204_0003"]);
            list.Add(configDic["0205_0003"]);
            list.Add(configDic["0206_0003"]);
            return list;
        }
    }

    public override int Sex
    {
        get { return 1; }
    }

    public override SkinColor color
    {
        get { return SkinColor.transfer(Color.white); }
    }
}
#endif
