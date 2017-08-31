#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UMA;
using System.IO;
using System.Threading;
using UnityEditor.Animations;

public class IniEditor
{
    [MenuItem("Custom/Test")]
    static void Test()
    {
        TemplateCloth temp = new TemplateCloth();
        List<TemplateClothItem> list = temp.LoadAll();
        for (int i = 0; i < list.Count; i++)
        {
            if(list[i].texture==null)
            {
                Debug.Log("name="+list[i].name);
            }
        }
    }

    [MenuItem("Custom/Create Form data")]
    static void CreateFormData()
    {
        Caching.CleanCache();

        IFormData female1 = new FormData_Female1();
        female1.CreatJson();

        IFormData female2 = new FormData_Female2();
        female2.CreatJson();

        IFormData female3 = new FormData_Female3();
        female3.CreatJson();

        IFormData male1 = new FormData_Male1();
        male1.CreatJson();

        IFormData male2 = new FormData_Male2();
        male2.CreatJson();

        IFormData male3 = new FormData_Male3();
        male3.CreatJson();
    }

    [MenuItem("Custom/initialize data")]
    public static void iniData()
    {
        Caching.CleanCache();

        #region delete
        string heightFold = string.Format("{0}/{1}", CharacterConst.prefabPath,CharacterConst.ResHeight);
        string lowFold = string.Format("{0}/{1}", CharacterConst.prefabPath, CharacterConst.ResLow);
        if (Directory.Exists(heightFold))
        {
            Directory.Delete(heightFold, true);
        }
        if (Directory.Exists(lowFold))
        {
            Directory.Delete(lowFold, true);
        }
        #endregion

        #region Height

        #region female
        EditorUtility.DisplayProgressBar("reosurces dealing", "female resources are dealing...", 1 / 3f);
        IEditorCloth female_h = new BaseEditorCloth_Female(ECharacterResType.Height);
        female_h.CreatPrefab();
        #endregion

        #region male
        EditorUtility.DisplayProgressBar("reosurces dealing", "male resources are dealing...", 2 / 3f);
        IEditorCloth male_h = new BaseEditorCloth_Male(ECharacterResType.Height);
        male_h.CreatPrefab();
        #endregion

        #endregion

        #region Low
        #region female
        EditorUtility.DisplayProgressBar("reosurces dealing", "female resources are dealing...", 1 / 3f);
        IEditorCloth female_l = new BaseEditorCloth_Female(ECharacterResType.Low);
        female_l.CreatPrefab();
        #endregion

        #region male
        EditorUtility.DisplayProgressBar("reosurces dealing", "male resources are dealing...", 2 / 3f);
        IEditorCloth male_l = new BaseEditorCloth_Male(ECharacterResType.Low);
        male_l.CreatPrefab();
        #endregion
        #endregion

        #region config
        EditorUtility.DisplayProgressBar("reosurces dealing", "config resources are dealing...", 3 / 3f);
        EditorConfigPrefab config = new EditorConfigPrefab();
        config.Initiliaze();
        #endregion

        AssetDatabase.Refresh();
        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("", "资源生成完成", "确定");
    }
}
#endif
