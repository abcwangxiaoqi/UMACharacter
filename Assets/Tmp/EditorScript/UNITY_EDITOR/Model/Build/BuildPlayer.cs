#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

abstract public class BuildPlayer
{
    string[] sences = null;
     public BuildPlayer()
    {
        sences = new string[] { "Assets/Tmp/changecloth.unity" };
    }

     abstract public BuildTarget target { get; }
     abstract public string suffix { get; }

    public void Build()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }
        AssetDatabase.Refresh();

        EditorCoroutineRunner.StartEditorCoroutine(build());


    }

    IEnumerator build()
    {
        yield return new WaitForSeconds(0.5f);
        string path = EditorUtility.SaveFilePanel("打包", "C:/Users/Administrator/Desktop", "Character", suffix);
        if (string.IsNullOrEmpty(path))
            yield return 0;

        EditorUserBuildSettings.SwitchActiveBuildTarget(target);

        string res=BuildPipeline.BuildPlayer(sences, path, target, BuildOptions.None);
        if (string.IsNullOrEmpty(res))
        {
            res = "打包成功";
        }
        else
        {
            res = "打包失败:" + res;
        }
        EditorUtility.DisplayDialog("打包", res, "确定");
    }
}
#endif
