using UnityEngine;

public class SOAData_Resource : SOAServiceData
{
    public string name { get; private set; }
    public Object obj { get; private set; }
    public Object[] objs { get; private set; }
    public Texture texture { get; private set; }
    public string text { get; private set; }

    public T Get<T>() where T : Object
    {
        if (obj == null)
            return null;
        return obj as T;
    }

    public SOAData_Resource(ResponseData data, string _name)
    {
        name = _name;
        texture = data.texture;
        text = data.text;

        AssetBundle ab = data.ab;

        if (ab == null)
            return;

        obj = ab.LoadAsset(_name);

        if(obj!=null)
        {
            obj.RefreshShader();
            obj.ClearNoUseAnimator();
        }
       
        objs = ab.LoadAllAssets();
        if(objs!=null)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] == obj || objs[i]==null)
                {
                    continue;
                }
                objs[i].RefreshShader();
                objs[i].ClearNoUseAnimator();
            }
        }     
    }

    public void Dispose()
    {
        name = null;
        obj = null;
        objs = null;
        texture = null;
        text = null;
    }
}
