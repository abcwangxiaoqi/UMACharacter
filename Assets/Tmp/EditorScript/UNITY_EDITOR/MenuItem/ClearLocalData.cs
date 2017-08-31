#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class ClearLocalData
{
    [MenuItem("Custom/clear local data")]
    public static void clear()
    {
        Directory.Delete(Application.persistentDataPath, true);
       EditorUtility.DisplayDialog("清除缓存资源", "清除成功", "确定");
    }
}
#endif
