using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CharacterData
{
    public int sex { get; set; }//sex
    public List<ClothModel> avatars { get; set; }// cloth pant shoe hair
    //public List<UmaDnaItem> dna { get; set; }// body shap
    //public SkinColor skin { get; set; }//skin color

    //public Dictionary<EnumUmaParamters, float> getDna()
    //{
    //    Dictionary<EnumUmaParamters, float> dic = new Dictionary<EnumUmaParamters, float>();

    //     System.Array arrys = System.Enum.GetValues(typeof(EnumUmaParamters));
    //     for (int j = 0; j < arrys.Length; j++)
    //     {
    //         EnumUmaParamters eup = (EnumUmaParamters)arrys.GetValue(j);

    //         if(dna!=null && dna.Count>0)
    //         {
    //             UmaDnaItem cur = dna.Find((UmaDnaItem d) =>
    //             {
    //                 return d.dnaKey == (int)eup;
    //             });
    //             if (cur != null)
    //             {
    //                 dic.Add(eup, (float)cur.dnaValue);
    //             }
    //             else
    //             {
    //                 float v = UmaDnaConst.dnaItemDic[eup].def;
    //                 dic.Add(eup, v);
    //             }
    //         }
    //         else
    //         {
    //             float v = UmaDnaConst.dnaItemDic[eup].def;
    //             dic.Add(eup, v);
    //         }      
    //     }

    //     return dic;
    //}

    public static CharacterData defData(EnumCharacterType type)
    {
        CharacterData cd = new CharacterData();
        cd.sex = (int)type;
        cd.avatars = ClothModel.GetDefault(type,1);
        //cd.skin = SkinColor.transfer(Color.white);
        return cd;
    }
}