#if UNITY_EDITOR
using System.Collections.Generic;
using UMA;
using UnityEditor;
using UnityEngine;

abstract public class BaseEditorCloth : IEditorCloth
{
    protected IFbxItem obj = null;
    protected IObjectBase skin_diff;
    protected string baseOverlayName = "";

    protected string prefabFold = "";
    EnumCharacterType sex;

    protected ECharacterResType restype = ECharacterResType.Height;

    public BaseEditorCloth(EnumCharacterType _sex,ECharacterResType type)
    {
        sex = _sex;
        restype = type;
    }

    public void CreatPrefab()
    {        
        #region cloths
        EditorUtility.DisplayProgressBar(sex.ToString(), "clothes resources are dealing...", 1 / 7f);
        IEditorCloth cloths = EditorClothFactory.Creat(sex, restype);
        cloths.CreatPrefab();
        #endregion
        
        #region race
        EditorUtility.DisplayProgressBar(sex.ToString(), "create race...", 2 / 7f);
        TPoseEditor pose = TPoseEditorFactory.Creat(sex, obj,restype);
        RaceData rd =pose.CreatTPose();
        #endregion
        
        #region animator

        EditorUtility.DisplayProgressBar(sex.ToString(), "animations resources are dealing...", 3 / 7f);
        IEditorAnimation anim = EditorAnimationFactory.Creat(sex,restype);
        RuntimeAnimatorController controller = anim.Creat();

        #endregion
       
        #region base
        EditorUtility.DisplayProgressBar(sex.ToString(), "body parts resources are dealing...", 5 / 7f);

        List<SlotOverlayItem> sos = new List<SlotOverlayItem>();

        SlotOverlayItem eyeItem = new SlotOverlayItem();
        BaseClothItemEditor eyes = new EyesEditor(obj,restype);
        SlotDataAsset eyes_slot = eyes.CreatSlot();
        OverlayDataAsset eyes_overlay = eyes.CreatOverlay();
        eyeItem.slot = eyes_slot;
        eyeItem.overlay = eyes_overlay;
        eyeItem.partIndex = eyes.WearPos;

        SlotOverlayItem faceItem = new SlotOverlayItem();
        BaseClothItemEditor face = new FaceEditor(obj, restype);
        SlotDataAsset face_slot = face.CreatSlot();
        OverlayDataAsset face_overlay = face.CreatOverlay();
        faceItem.slot = face_slot;
        faceItem.overlay = face_overlay;
        faceItem.partIndex = face.WearPos;


        sos.Add(eyeItem);
        sos.Add(faceItem);
        #endregion
        
        #region CharacterPlayer
        EditorUtility.DisplayProgressBar(sex.ToString(), "create character...", 7 / 7f);
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic["animatorController"] = controller;
        dic["race"] = rd;
        dic["sos"] = sos;

        string assetpath=string.Format("{0}/{1}.prefab",prefabFold,obj.Name);
        IPrefabItem prefab = new PrefabItem(assetpath);
        prefab.CreatPrefab(null, CreatPrefabFinish, dic);
        #endregion        
    }

    void CreatPrefabFinish(GameObject go, Dictionary<string, object> dic)
    {
        PlayerData pd = go.AddComponent<PlayerData>();

        pd.race = dic["race"] as RaceData;
        pd.anim = dic["animatorController"] as RuntimeAnimatorController;
        pd.slotoverlays = dic["sos"] as List<SlotOverlayItem>;
    }
}
#endif