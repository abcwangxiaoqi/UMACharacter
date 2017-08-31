#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public interface IExpressClip
{
    string name { get; }
    AnimationClip clip { get; }
    WrapMode wrapMode { get; }
    void CreateClip();
    void SetWrapMode(WrapMode mode);
    void Edit();
    void Delete();
    void Export();
}

public class ExpressClip : IExpressClip
{
    IObjectBase animObj = null;
    IExpressModel expressPlayer;
    public ExpressClip(string path, IExpressModel _expressPlayer)
    {
        expressPlayer = _expressPlayer;
        animObj = new ObjectBase(path);
        name = animObj.Name;
        clip = animObj.Load<AnimationClip>();
        if (clip!=null)
        {
            wrapMode = clip.wrapMode;
        }        
    }
    public string name { get; private set; }
    public AnimationClip clip { get; private set; }
    public WrapMode wrapMode { get; private set; }

    public void CreateClip()
    {
        if (clip != null)
        {
            animObj.DeleteAsset();
        }
        clip = new AnimationClip();
        clip.legacy = true;
        animObj.CreatAsset(clip);
        AssetDatabase.Refresh();
    }
    public void SetWrapMode(WrapMode mode)
    {
        clip.wrapMode = mode;
        animObj.Save();
        wrapMode = mode;
    }
    public void Edit()
    {
        if (clip == null)
            return;
        expressPlayer.AddClip(clip);
        EditorApplication.ExecuteMenuItem("Window/Animation");
    }
    public void Delete()
    {
        animObj.DeleteAsset();
    }
    public void Export()
    {
        string[] strs = { "animation files", "anim"};
        string path = EditorUtility.OpenFilePanelWithFilters("", "C:/Users/Administrator/Desktop", strs);
        if (string.IsNullOrEmpty(path))
            return;

        FileHelper.copyFile(path, animObj.path, true);

        clip= animObj.Load<AnimationClip>();
        clip.legacy = true;
        wrapMode = clip.wrapMode;
    }
}
#endif