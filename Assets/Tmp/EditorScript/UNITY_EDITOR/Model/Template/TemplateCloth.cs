#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TemplateClothItem
{
    public TemplateClothItem(ClothModel _cm) // cm
    {
        cm = _cm;
        name = _cm.resname;
        string icon = string.Format("{0}/Tmp/AllResoruces/{1}/icon/{2}.png", Application.dataPath, CharacterConst.targetFold, name);
        IObjectBase iconobj = new ObjectBase(icon);
        texture = iconobj.Load<Texture2D>();
    }

    public string name { get; private set; }
    public Texture2D texture { get; private set; }
    public ClothModel cm { get; private set; }
}

public class TemplateCloth
{
    List<TemplateClothItem> cloths = null;
    public TemplateCloth()
    {
        cloths = new List<TemplateClothItem>();

        TextAsset txt = new EditorItemList().Get();
        if(txt!=null)
        {
            List<ClothModel> chs = txt.text.JsonTransferObject<List<ClothModel>>();
            for (int i = 0; i < chs.Count; i++)
            {
                cloths.Add(new TemplateClothItem(chs[i]));
            }
        }
    }

    public List<TemplateClothItem> LoadAll()
    {
        return cloths;
    }

    public List<TemplateClothItem> Load(EnumCharacterType sex, string weap=null)
    {
        string s="01";
        if(sex==EnumCharacterType.Charater_Female)
        {
            s="02";
        }

        List<TemplateClothItem> res = cloths.FindAll((TemplateClothItem item) => 
        {
            if (string.IsNullOrEmpty(weap))
            {
                return item.cm.sex == s;
            }
            else
            {
                return item.cm.sex == s && item.cm.wearpos == weap;
            }            
        });

        return res;
    }
}
#endif
