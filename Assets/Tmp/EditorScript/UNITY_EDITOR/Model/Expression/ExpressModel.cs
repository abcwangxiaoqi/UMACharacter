#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UMA.PoseTools;
using System.Collections.Generic;

enum EnumExpression
{
    talk,
    blink,
    smile
}

public interface IExpressModel
{
    List<IExpressClip> clips { get; }//表情动画
    void Creat();//创建模型
    void AddClip(AnimationClip clip);
    void Play(IExpressClip expression);//播放动画
    void Stop();//停止
    void Destroy();//销毁对象
    void SetPosition(Vector3 pos);//设置 position
    void SetEulerAngles(Vector3 angles);//设置 eulerangles
    void SetParent(Transform tran);
}

abstract public class ExpressModel : IExpressModel
{
    public List<IExpressClip> clips { get; private set; }

    GameObject go;
    Animation anim;
    ExpressionPlayer ep;

    Material bodyMat;
    Material faceMat;
    Shader _shader = Shader.Find("Character/Single/Bumped Diffuse");
    public ExpressModel()
    {
        #region body
        bodyMat = new Material(_shader);
        IObjectBase bodyD = new ObjectBase(bodyDiff);
        IObjectBase bodyN = new ObjectBase(bodyNormal);
        Texture bDiff = bodyD.Load<Texture>();
        if (bDiff != null)
        {
            bodyMat.SetTexture("_MainTex", bDiff);
        }
        Texture bNor = bodyN.Load<Texture>();
        if (bNor != null)
        {
            bodyMat.SetTexture("_BumpMap", bNor);
        }

        #endregion

        #region face
        faceMat = new Material(_shader);
        IObjectBase faceD = new ObjectBase(faceDiff);
        IObjectBase faceN = new ObjectBase(faceNormal);
        Texture fDiff = faceD.Load<Texture>();
        if (fDiff != null)
        {
            faceMat.SetTexture("_MainTex", fDiff);
        }
        Texture fNor = faceN.Load<Texture>();
        if (fNor != null)
        {
            faceMat.SetTexture("_BumpMap", fNor);
        }
        #endregion

        #region expression
        clips = new List<IExpressClip>();
        string path = string.Format("{0}/{1}.anim", clipFold, EnumExpression.blink);
        IExpressClip blink = new ExpressClip(path, this);
        
        path = string.Format("{0}/{1}.anim", clipFold, EnumExpression.smile);
        IExpressClip smile = new ExpressClip(path, this);

        path = string.Format("{0}/{1}.anim", clipFold, EnumExpression.talk);
        IExpressClip talk = new ExpressClip(path, this);

        clips.Add(blink);
        clips.Add(smile);
        clips.Add(talk);
        #endregion
    }

    abstract public string name { get; }
    abstract public string fbx { get; }
    abstract public string rig { get; }
    abstract public string expression_Set { get; }
    abstract public string bodyDiff { get; }
    abstract public string bodyNormal { get; }
    abstract public string faceDiff { get; }
    abstract public string faceNormal { get; }
    abstract public string clipFold { get; }

    public void Creat()
    {
        IObjectBase iob = new ObjectBase(fbx);
        Object o = iob.Load();
        go = GameObject.Instantiate(o) as GameObject;
        go.name = name;

        SkinnedMeshRenderer[] smrs = go.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < smrs.Length; i++)
        {
            if (smrs[i].gameObject.name.EndsWith("_Face"))
            {
                smrs[i].sharedMaterial = faceMat;
            }
            else
            {
                smrs[i].sharedMaterial = bodyMat;
            }
        }


        Animator an = go.GetComponent<Animator>();
        if (an)
        {
            GameObject.DestroyImmediate(an);
        }

        Transform skeletonRoot = go.transform.FindChild(rig);

        IObjectBase set = new ObjectBase(expression_Set);
        UMAExpressionSet expressionPlayer = set.Load<UMAExpressionSet>();       

        anim= go.AddComponent<Animation>();
        ep = go.AddComponent<ExpressionPlayer>();
        EditModeExpressionPreview emp = go.AddComponent<EditModeExpressionPreview>();
        emp.expressionPlayer = ep;
        emp.expressionSet = expressionPlayer;
        emp.skeletonRoot = skeletonRoot;
        go.name = name;

        Selection.activeGameObject = go;//selected 
    }

    public void AddClip(AnimationClip clip)
    {
        if(anim!=null)
        {
            GameObject.DestroyImmediate(anim);
        }
        anim = go.AddComponent<Animation>();
        anim.AddClip(clip, clip.name);
        anim.clip = clip;
    }

    public void Stop()
    {
        anim.Stop();

        float[] zeroes = new float[ep.Values.Length];
        ep.Values = zeroes;
        EditorUtility.SetDirty(ep);
        AssetDatabase.SaveAssets();
    }

    public void Play(IExpressClip expression)
    {
        if (expression.clip == null)
            return;

        Stop();
        AddClip(expression.clip);
        anim.Play();
    }

    public void Destroy()
    {
        GameObject.Destroy(go);
    }

    public void SetPosition(Vector3 pos)
    {
        if (go == null)
            return;
        go.transform.localPosition = pos;
    }

    public void SetEulerAngles(Vector3 angles)
    {
        if (go == null)
            return;
        go.transform.localEulerAngles = angles;
    }

    public void SetParent(Transform tran)
    {
        if (go == null)
            return;
        go.transform.parent = tran;
    }
}
#endif