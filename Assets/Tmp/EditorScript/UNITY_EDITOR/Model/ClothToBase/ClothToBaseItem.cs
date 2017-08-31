#if UNITY_EDITOR
using UnityEngine;
public class ClothToBaseItem
{
    public string name;

    public Texture2D LoadTexture()
    {
        if (string.IsNullOrEmpty(name))
            return null;

        Texture2D texture = null;

        string path = string.Format("{0}/icon/{1}.png", CharacterConst.ResUrl, name);
        IObjectBase obj = new ObjectBase(path);
        texture = obj.Load<Texture2D>();

        return texture;
    }
}
#endif
