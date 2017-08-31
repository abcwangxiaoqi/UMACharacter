#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using UMA;

public class PackagerEditor
{
    [MenuItem("Custom/Pack Assetbundle/Win")]
    static void Assetbundle_Win()
    {
        IniAssetbundleName();
        IEditorPackage win = new EditorPackage_Android();
        win.Package();
    }

    [MenuItem("Custom/Pack Assetbundle/IOS")]
    static void Assetbundle_IOS()
    {
        IniAssetbundleName();
        IEditorPackage ios = new EditorPackage_IOS();
        ios.Package();
    }
    [MenuItem("Custom/Pack Assetbundle/Android")]
    static void Assetbundle_Android()
    {
        IniAssetbundleName();
        IEditorPackage android = new EditorPackage_Android();
        android.Package();
    }

    [MenuItem("Custom/Pack Assetbundle/ALL")]
    public static void Assetbundle_All()
    {
        IniAssetbundleName();

        //IEditorPackage win = new EditorPackage_Win();
        //win.Package();
        IEditorPackage ios = new EditorPackage_IOS();
        ios.Package();
        IEditorPackage android = new EditorPackage_Android();
        android.Package();
    }


    static void IniAssetbundleName()
    {
        EditorUtility.DisplayProgressBar("Set Assetbundle Name", "set config resources' assetbundlaname", 1 / 3f);
        IEditorBundleName bundle = new EditorBundleName_Config();
        bundle.SetBundle();

        #region height
        EditorUtility.DisplayProgressBar("Set Assetbundle Name", "set female resources' assetbundlaname", 2 / 3f);
        bundle = new EditorBundleName_HumanFemale(ECharacterResType.Height);
        bundle.SetBundle();
        EditorUtility.DisplayProgressBar("Set Assetbundle Name", "set female resources' assetbundlaname", 3 / 3f);
        bundle = new EditorBundleName_HumanMale(ECharacterResType.Height);
        bundle.SetBundle();
        #endregion

        #region low
        EditorUtility.DisplayProgressBar("Set Assetbundle Name", "set female resources' assetbundlaname", 2 / 3f);
        bundle = new EditorBundleName_HumanFemale(ECharacterResType.Low);
        bundle.SetBundle();
        EditorUtility.DisplayProgressBar("Set Assetbundle Name", "set female resources' assetbundlaname", 3 / 3f);
        bundle = new EditorBundleName_HumanMale(ECharacterResType.Low);
        bundle.SetBundle();
        #endregion
    }
}
#endif