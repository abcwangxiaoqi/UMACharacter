#if UNITY_EDITOR
/*
 * 压缩assetbundle资源 并导出
 */
using UnityEngine;
using System.Collections;
using UnityEditor;

public class CompressAssetbundleZip
{ 

    public void Compress()
    {
        string path = EditorUtility.SaveFilePanel("", "C:/Users/Administrator/Desktop", CharacterConst.targetFold, "zip");
        if (string.IsNullOrEmpty(path))
            return;
        EditorUtility.DisplayProgressBar("Compress Resources", "", 0.8f);
        ZipHelper.ZipFileDirectory(CharacterConst.ResUrl, path, new string[] { ".meta", ".manifest" });
        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("导出资源", "导出成功:" + path, "确定");
    }
}
#endif
