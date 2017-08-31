#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

abstract public class ExportBase
{
    abstract public string[] assetpaths { get; }
    abstract public string assetpath { get; }
    abstract public string name { get; }
    abstract public ExportPackageOptions options { get; }

    public void ExportAsset()
    {      
        string targetpath = EditorUtility.SaveFilePanel("保存", "C:/Users/Administrator/Desktop", name, "unitypackage");
        if (string.IsNullOrEmpty(targetpath))
            return;

        EditorUtility.DisplayProgressBar("导出", "正在导出......", 0.9f);
        AssetDatabase.ExportPackage(assetpath, targetpath, options);
        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("导出", "导出成功", "确定");
    }

    public void ExportAssets()
    {        
        string targetpath = EditorUtility.SaveFilePanel("保存", "C:/Users/Administrator/Desktop", name, "unitypackage");
        if (string.IsNullOrEmpty(targetpath))
            return;

        EditorUtility.DisplayProgressBar("导出", "正在导出......", 0.9f);
        AssetDatabase.ExportPackage(assetpaths, targetpath, options);
        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("导出", "导出成功", "确定");
    }
}
#endif
