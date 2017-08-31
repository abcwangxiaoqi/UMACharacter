#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UMA;
using UMAEditor;
using System.IO;
using System.Collections.Generic;
using System;
public class SlotEditor
{
    UMAMaterial slotMaterial = null;
    SkinnedMeshRenderer slotMesh = null;
    string foldpath = "";
    string assetName = "";

    public SlotEditor(SkinnedMeshRenderer _slotMesh, string _name, string _foldpath, EditorUmaMaterial _uMaterial)
    {
        slotMesh = _slotMesh;
        assetName = _name;
        foldpath = _foldpath;
        slotMaterial = _uMaterial.Load();
    }

    public SlotDataAsset Creat()
    {
        if (slotMaterial == null ||
          string.IsNullOrEmpty(foldpath) ||
          string.IsNullOrEmpty(assetName))
        {
            throw new System.Exception("slotMaterial or foldpath or assetName is null");
        }

        if (!Directory.Exists(foldpath))
        {
            Directory.CreateDirectory(foldpath);
        }
        string path = PathHelper.GetRelativeAssetPath(foldpath);

        SlotDataAsset tmpSlot = UMASlotProcessingUtil.CreateSlotData(path, assetName, slotMesh, slotMaterial, null);
        return tmpSlot;
    }
}


public class ClothSlotOverlay
{
    string slotFold = "";
    string overlayFold = "";
    string baseName = "";
    EditorUmaMaterial Mat = null;
    SkinnedMeshRenderer slotMesh = null;
    Texture2D comTexture = null;
    Texture2D diff = null;
    int wearpos = -1;
    List<string> sharedMaterials = new List<string>();
    public ClothSlotOverlay(IObjectBase obj,Texture2D _diff, string Fold, EditorUmaMaterial mat,ECharacterResType type)
    {
        GameObject go = obj.Load<GameObject>();

        slotMesh = go.GetComponentInChildren<SkinnedMeshRenderer>();
        if (slotMesh == null)
        {
            throw new Exception(obj.Name + " could't find SkinnedMeshRenderer!!!");
        }

        diff = _diff;

        Material[] ms = slotMesh.sharedMaterials;
        for (int i = 0; i < ms.Length; i++)
        {
            sharedMaterials.Add(ms[i].name);
        }

        slotMesh = go.GetComponentInChildren<SkinnedMeshRenderer>();
        //slotMesh.sharedMaterial = null;
        //slotMesh.sharedMaterials = new Material[0];

        baseName = go.name;
        slotFold = Fold+"/"+UMAUtils.Slot;
        overlayFold = Fold + "/" + UMAUtils.Overlay;
        Mat = mat;

        string comTexturePath = null;
        if(baseName.StartsWith("01"))
        {// male
            comTexturePath = string.Format("{0}/{1}/{2}/{3}_{4}.png", CharacterConst.rootPath,type.ToString(), CharacterConst.Male, CharacterConst.Male, CharacterConst.Common);
        }
        else
        {// female
            comTexturePath = string.Format("{0}/{1}/{2}/{3}_{4}.png", CharacterConst.rootPath, type.ToString(), CharacterConst.Female, CharacterConst.Female, CharacterConst.Common);
        }

        IObjectBase comt = new ObjectBase(comTexturePath);
        comTexture = comt.Load<Texture2D>();
        (new CharacterTexture(comTexturePath)).Handle();

        wearpos = int.Parse(baseName.Substring(2, 2));
    }

    public List<SlotOverlayItem> CreatData()
    {
        List<SlotOverlayItem> sos = new List<SlotOverlayItem>();
        int submeshIndex = 0;
        bool first = false;
        string firstSlotPath = null;

        for (int i = 0; i < sharedMaterials.Count; i++)
        {
            SlotOverlayItem item = new SlotOverlayItem();
            string materialName = sharedMaterials[i];
            string name = baseName + "-" + i;
            if (!first)
            {
                #region slot
                SlotEditor so = new SlotEditor(slotMesh, name, slotFold, Mat);
                SlotDataAsset firstSlot = so.Creat();
                item.slot = firstSlot;
                firstSlotPath = string.Format("{0}/{1}_{2}.asset", PathHelper.GetRelativeAssetPath(slotFold), name, UMAUtils.Slot);
                #endregion

                first = true;
            }
            else
            {
                #region slot
                string target = string.Format("{0}/{1}_{2}.asset", PathHelper.GetRelativeAssetPath(slotFold), name, UMAUtils.Slot);
                FileUtil.CopyFileOrDirectory(firstSlotPath, target);

                AssetDatabase.Refresh();

                ObjectBase obj = new ObjectBase(target);
                SlotDataAsset slotSub = obj.Load<SlotDataAsset>();
                slotSub.subMeshIndex = i;
                item.slot = slotSub;
                #endregion
            }

            #region overlay
            OverlayEditor oe = null;
            if (materialName.EndsWith(CharacterConst.Common))
            {
                oe = new OverlayEditor(overlayFold, comTexture, name, Mat);
            }
            else
            {
                oe = new OverlayEditor(overlayFold, diff, name, Mat);
            }

            OverlayDataAsset overlay = oe.CreatOverlay();
            item.overlay = overlay;
            #endregion

            #region index
            item.partIndex = wearpos * 10 + i;
            #endregion

            sos.Add(item);
        }


        return sos;
    }
}
#endif
