#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormData_Female2 : FormData
{
    public override string filename
    {
        get { return "2"; }
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
            list.Add(configDic["0202_0002"]);
            list.Add(configDic["0204_0002"]);
            list.Add(configDic["0205_0002"]);
            list.Add(configDic["0206_0002"]);
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
