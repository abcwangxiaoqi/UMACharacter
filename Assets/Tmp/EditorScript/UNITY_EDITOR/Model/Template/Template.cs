#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public interface ITemplate
{
    TemplateIcon ImportIcon();//导入icon
    TemplateIcon LoadIcon();//加载icon
    List<TemplateClothItem> LoadCloths();//加载cloths
    //List<UmaDnaItem> LoadDna();//加载dna信息
    void Save(TemplateIcon icon, List<TemplateClothItem> cloths, List<UmaDnaItem> dna);//保存
}

public class TemplateIcon
{
    public TemplateIcon(string _path, bool _sourceFlag=false)
    {
        sourceFlag = _sourceFlag;
        path = _path;
        if (sourceFlag)
        {
            IObjectBase iobj = new ObjectBase(_path);
            texture = iobj.Load<Texture2D>();
        }
        else
        {
            byte[] bytes = path.ReadFileByIO();
            int width = 570;
            int height = 1125;
            texture = new Texture2D(width, height);
            texture.LoadImage(bytes);
        }
    }

    public bool sourceFlag { get; private set; }
    public string path { get; private set; }
    public Texture2D texture { get; private set; }
}

abstract public class Template : ITemplate
{
    IObjectBase JsonObj = null;
    IObjectBase IconObj = null;
    CharacterData characterData = null;
    string iconPath = "";
    public Template(EnumCharacterType sex)
    {
        string file = string.Format("{0}/{1}.txt", path, id);
        iconPath = string.Format("{0}/{1}.png", path, id);
        JsonObj = new ObjectBase(file);
        TextAsset jsonTxt = JsonObj.Load<TextAsset>();
        if (jsonTxt != null)
        {
            characterData = jsonTxt.text.JsonTransferObject<CharacterData>();
        }
        else
        {
            characterData = new CharacterData();
            characterData.sex = (int)sex;
        }
    }

    abstract public int id { get; }
    abstract public string path { get; }

    public TemplateIcon ImportIcon()
    {
        string assetp = EditorUtility.OpenFilePanel("模板Icon", "C:/Users/Administrator/Desktop", "png");
        if (string.IsNullOrEmpty(assetp))
        {
            return null;
        }

        TemplateIcon icon = new TemplateIcon(assetp);
        return icon;
    }

    public TemplateIcon LoadIcon()
    {
        return new TemplateIcon(iconPath, true);
    }

    public List<TemplateClothItem> LoadCloths()
    {
        List<TemplateClothItem> Cloths = new List<TemplateClothItem>();
        List<ClothModel> cms = characterData.avatars;
        if (cms!=null)
        {
            for (int i = 0; i < cms.Count; i++)
            {
                TemplateClothItem item = new TemplateClothItem(cms[i]);
                Cloths.Add(item);
            }
        }
        return Cloths;
    }

    //public List<UmaDnaItem> LoadDna()
    //{
    //    return characterData.dna;
    //}

    public void Save(TemplateIcon icon,List<TemplateClothItem> cloths,List<UmaDnaItem> dna)
    {
        if (characterData != null)
        {
            if(!icon.sourceFlag)
            {
                string source = icon.path;
                FileHelper.copyFile(source, iconPath, true);
            }

            List<ClothModel> cms = new List<ClothModel>();
            for (int i = 0; i < cloths.Count; i++)
            {
                if (cloths[i].cm != null)
                {
                    cms.Add(cloths[i].cm);
                }
            }
            characterData.avatars = cms;
            //characterData.dna = dna;
            string json = characterData.JsonTransferString();
            FileHelper.CreatFile(path, id + ".txt", json);
        }
    }
}
#endif