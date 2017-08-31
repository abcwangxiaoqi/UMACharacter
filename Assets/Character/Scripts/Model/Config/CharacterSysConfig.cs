
using UnityEngine;
public class CharacterSysConfig : ICharacterSysConfig
{
    static TextAsset itemList = null;

    public void Initialize(Object o)
    {
        GameObject go = GameObject.Instantiate(o) as GameObject;
        CharacterConfig config = go.GetComponent<CharacterConfig>();
        itemList = config.ItemList;
        GameObject.Destroy(go);
    }

    public TextAsset ItemList
    {
        get
        {
            return itemList;
        }
    }
}
