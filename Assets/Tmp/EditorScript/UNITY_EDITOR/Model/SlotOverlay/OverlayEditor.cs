#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using UMA;
using System.Collections.Generic;

public class OverlayEditor
{
    string path = "";
    Texture2D diffuse;
    string filename="";
    EditorUmaMaterial uMaterial;

    public OverlayEditor(string _path, Texture2D _diffuse, string _filename, EditorUmaMaterial _uMaterial)
    {
        path = _path;
        diffuse = _diffuse;
        filename = _filename;
        uMaterial = _uMaterial;
    }

    public OverlayDataAsset CreatOverlay()
    {
        if(string.IsNullOrEmpty(path) || string.IsNullOrEmpty(filename) || diffuse==null)
        {
            Debug.LogError("path or filename or texture is null !!!");
            return null;
        }

        OverlayDataAsset oda = OverlayDataAsset.CreateInstance<OverlayDataAsset>();
        oda.overlayName = filename;
        oda.material = uMaterial.Load();
        oda.textureList = new Texture2D[]{diffuse};
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string p = path + "/" + filename + "_" + UMAUtils.Overlay + ".asset";
        IObjectBase objBase = new ObjectBase(p);
        objBase.CreatAsset(oda);
        objBase.Save();

        return oda;
    }
}

#endif
