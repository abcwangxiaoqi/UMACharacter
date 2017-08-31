#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

abstract public class ImportBase
{
    protected List<string> files = null;

    public abstract string name { get; }
    public abstract string TargetFold { get; }

    public void Import()
    {
        if (files == null || files.Count == 0)
            return;

        for (int i = 0; i < files.Count; i++)
        {            
            string filename = FileHelper.getFileNameAndTypeByPath(files[i]);
            string target = TargetFold + "/" + filename;
            EditorUtility.DisplayProgressBar(name, string.Format("import {0} resources:{1}", name, filename), (i + 1) / (float)files.Count);
            FileHelper.copyFile(files[i], target, true);
        }
        AssetDatabase.Refresh();
        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("", "导入完成", "确定");
    }
}
#endif
