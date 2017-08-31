#if UNITY_EDITOR
using UMA;
using UnityEngine;
public abstract class BaseClothItemEditor
{
    public GameObject gameObject = null;
    public string baseFold = "";
    EditorUmaMaterial uMaterial;
    ECharacterResType resType = ECharacterResType.Height;
    public BaseClothItemEditor(IFbxItem _go,ECharacterResType type)
    {
        resType = type;
        gameObject = _go.Load<GameObject>();
        if (gameObject.name == CharacterConst.Female)
        {
            baseFold = string.Format("{0}/{1}/{2}/{3}", CharacterConst.prefabPath, resType.ToString(),CharacterConst.Female, CharacterConst.Base);
        }
        else if (gameObject.name == CharacterConst.Male)
        {
            baseFold = string.Format("{0}/{1}/{2}/{3}", CharacterConst.prefabPath, resType.ToString(),CharacterConst.Male, CharacterConst.Base);
        }

        uMaterial = new EditorUmaMaterial_Base();
    }

    abstract public string PartName{get;}

    abstract public int WearPos { get; }

    public SlotDataAsset CreatSlot()
    {
        string fold = string.Format("{0}/{1}/{2}", baseFold, PartName, UMAUtils.Slot);
        GameObject go = gameObject.FindInChildren(gameObject.name + "_" + PartName);


        SkinnedMeshRenderer slotMesh = go.GetComponentInChildren<SkinnedMeshRenderer>();
        if (slotMesh==null)
        {
            throw new System.Exception(gameObject.name + " SkinnedMeshRenderer is null");
        }
        slotMesh.sharedMaterial = null;
        slotMesh.sharedMaterials = new Material[0];

        SlotEditor se = new SlotEditor(slotMesh, go.name,fold, uMaterial);
        SlotDataAsset slot =se.Creat();
        return slot;
    }

    public OverlayDataAsset CreatOverlay()
    {
        string fold = string.Format("{0}/{1}/{2}", baseFold, PartName, UMAUtils.Slot);
        string texturePath=string.Format("{0}/{1}/{2}/{3}_{4}.png",CharacterConst.rootPath,resType.ToString(),gameObject.name,gameObject.name,PartName);
        string filename=string.Format("{0}_{1}",gameObject.name,PartName);
        IObjectBase textureObj=new ObjectBase(texturePath);
        Texture2D t=textureObj.Load<Texture2D>();
        (new CharacterTexture(texturePath)).Handle();

        OverlayEditor oe = new OverlayEditor(fold, t, filename, uMaterial);
        OverlayDataAsset oda=oe.CreatOverlay();

        return oda;
    }
}
#endif