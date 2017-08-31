#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

public static class PackageUtil
{
    /// <summary>
    /// 导出apk
    /// </summary>
    /// <param name="path">导出路径</param>
    public static void PackageApk(string[] secens, string path)
    {
        BuildPipeline.BuildPlayer(secens, path, BuildTarget.Android, BuildOptions.None);
    }

    /// <summary>
    /// 导出android工程文件
    /// </summary>
    /// <param name="secens">场景</param>
    /// <param name="path">导出路径</param>
    public static void ExportAndroidProject(string[] secens,string path)
    {
        BuildPipeline.BuildPlayer(secens, path, BuildTarget.Android, BuildOptions.AcceptExternalModificationsToPlayer);
    }
}
#endif