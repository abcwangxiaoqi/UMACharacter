#if UNITY_EDITOR
using UnityEngine;
using System.IO;
using UnityEditor;
using System.Collections.Generic;

public class Upload : IUpload
{
    string rootPath = @"E:\ServerHost";//资源服务器地址
    public void upload()
    {
        #region 创建文件
        string path = rootPath + "/" + CharacterConst.targetFold;
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
        Directory.CreateDirectory(path);
        #endregion

        #region 导入文件
        List<string> files = PathHelper.getAllChildFiles(CharacterConst.ResUrl, "");
        for (int i = 0; i < files.Count; i++)
        {
            string fileType = FileHelper.getFileTypeByPath(files[i]);
            if (fileType == ".meta" || fileType == ".manifest")
            {
                continue;
            }

            string s = files[i].Replace(CharacterConst.ResUrl, null);
            string p = path + "/" + s;

            Debug.Log("From=" + files[i]);
            Debug.Log("To=" + p);

            string fold = PathHelper.GetFoldByFullName(p);
            if (!Directory.Exists(fold))
            {
                Directory.CreateDirectory(fold);
            }

            FileHelper.copyFile(files[i], p, true);
        }
        #endregion

        AssetDatabase.Refresh();
    }
}
#endif