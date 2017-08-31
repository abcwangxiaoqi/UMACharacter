#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

public class CharacterCustomExport :ExportBase
{
    public override string[] assetpaths
    {
        get { throw new System.NotImplementedException(); }
    }

    public override string assetpath
    {
        get { return "Assets/Character"; }
    }

    public override UnityEditor.ExportPackageOptions options
    {
        get { return ExportPackageOptions.IncludeDependencies | ExportPackageOptions.Recurse; }
    }

    public override string name
    {
        get { return "CharacterSystem"; }
    }
}
#endif
