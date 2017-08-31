#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using UMA.PoseTools;

public class ExpressionPrefab
{
    [MenuItem("Tools/生成表情资源/男")]
    static void CreatMan()
    {

        ExpressModel model = new ExpressModel_Male();
        model.Creat();
        return;

        string name = "male";

        GameObject g = GameObject.Find(name);
        if (g)
        {
            GameObject.DestroyImmediate(g);
        }

        string path="Assets/Tmp/FBX/Human_Male/Human_Male.fbx";
        Object o = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
        GameObject go = GameObject.Instantiate(o) as GameObject;

        string m1p = "Assets/Tmp/Expression/mat/male.mat";
        string m2p = "Assets/Tmp/Expression/mat/male-face.mat";

        Material m1 = AssetDatabase.LoadAssetAtPath(m1p, typeof(Object)) as Material;
        Material m2 = AssetDatabase.LoadAssetAtPath(m2p, typeof(Object)) as Material;

       SkinnedMeshRenderer[] smrs= go.GetComponentsInChildren<SkinnedMeshRenderer>();
       for (int i = 0; i < smrs.Length; i++)
       {
           if(smrs[i].gameObject.name.EndsWith("_Face"))
           {
               smrs[i].sharedMaterial = m2;
           }
           else
           {
               smrs[i].sharedMaterial = m1;
           }
       }

       Animator an = go.GetComponent<Animator>();
        if(an)
        {
            GameObject.DestroyImmediate(an);
        }

        Transform skeletonRoot = go.transform.FindChild("UMA_Male_Rig");
        string expressionPlayerPath = "Assets/Character/UMA/Content/UMA/Humanoid/Expressions/Expression Sets/Male_Expression_Set.asset";
        UMAExpressionSet expressionPlayer = AssetDatabase.LoadAssetAtPath<Object>(expressionPlayerPath) as UMAExpressionSet;

        go.AddComponent<Animation>();
        ExpressionPlayer ep=go.AddComponent<ExpressionPlayer>();
        EditModeExpressionPreview emp=go.AddComponent<EditModeExpressionPreview>();
        emp.expressionPlayer = ep;
        emp.expressionSet = expressionPlayer;
        emp.skeletonRoot = skeletonRoot;
        go.name = name;
    }

    [MenuItem("Tools/生成表情资源/女")]
    static void CreatWoman()
    {
        string name = "female";

        GameObject g = GameObject.Find(name);
        if (g)
        {
            GameObject.DestroyImmediate(g);
        }

        string path = "Assets/Tmp/FBX/Human_Female/Human_Female.fbx";
        Object o = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
        GameObject go = GameObject.Instantiate(o) as GameObject;

        string m1p = "Assets/Tmp/Expression/mat/female.mat";
        string m2p = "Assets/Tmp/Expression/mat/female-face.mat";

        Material m1 = AssetDatabase.LoadAssetAtPath(m1p, typeof(Object)) as Material;
        Material m2 = AssetDatabase.LoadAssetAtPath(m2p, typeof(Object)) as Material;

        SkinnedMeshRenderer[] smrs = go.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < smrs.Length; i++)
        {
            if (smrs[i].gameObject.name.EndsWith("_Face"))
            {
                smrs[i].sharedMaterial = m2;
            }
            else
            {
                smrs[i].sharedMaterial = m1;
            }
        }

        Animator an = go.GetComponent<Animator>();
        if (an)
        {
            GameObject.DestroyImmediate(an);
        }

        Transform skeletonRoot = go.transform.FindChild("UMA_Female_Rig");
        string expressionPlayerPath = "Assets/Character/UMA/Content/UMA/Humanoid/Expressions/Expression Sets/Female_Expression_Set.asset";
        UMAExpressionSet expressionPlayer = AssetDatabase.LoadAssetAtPath<Object>(expressionPlayerPath) as UMAExpressionSet;

        go.AddComponent<Animation>();
        ExpressionPlayer ep = go.AddComponent<ExpressionPlayer>();
        EditModeExpressionPreview emp = go.AddComponent<EditModeExpressionPreview>();
        emp.expressionPlayer = ep;
        emp.expressionSet = expressionPlayer;
        emp.skeletonRoot = skeletonRoot;
        go.name = name;
    }
}
#endif
