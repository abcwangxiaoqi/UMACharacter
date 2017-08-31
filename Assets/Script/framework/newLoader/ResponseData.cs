using UnityEngine;
public class ResponseData
{
    public ResponseData(LoadBase load)
    {
        isWWW = load.isWWW;
        bytes = load.bytes;
        ab = load.ab;
        url = load.url;
        text = load.text;
        texture = load.texture;
        success = load.success;
        error = load.error;
    }

    public bool isWWW { get; private set; }
    public byte[] bytes { get; private set; }
    public string url { get; private set; }
    public string text { get; private set; }
    public Texture texture { get; private set; }
    public AssetBundle ab { get; private set; }
    public bool success { get; private set; }
    public string error { get; private set; }

    public void UnLoad()
    {
        Framer framer = new Framer(unload, 1,false);
        framer.Start();
    }

    void unload()
    {
        if (ab != null)
        {
            ab.Unload(false);
            ab = null;
        }
        error = null;
        bytes = null;
        url = null;
        text = null;
        texture = null;
    }
}