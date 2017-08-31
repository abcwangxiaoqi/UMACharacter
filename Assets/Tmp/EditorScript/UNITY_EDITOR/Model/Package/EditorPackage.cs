#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using UnityEngine;
abstract public class EditorPackage : IEditorPackage
{
    abstract public BuildTarget target { get; }
    abstract public string path { get; }

    public void Package()
    {
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
        Directory.CreateDirectory(path);

        bool res= EditorUserBuildSettings.SwitchActiveBuildTarget(target);
        if (res)
        {
            BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.ChunkBasedCompression, target);//lz4 压缩
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.LogError("switch target failure=="+target.ToString());
        }
    }
}
#endif