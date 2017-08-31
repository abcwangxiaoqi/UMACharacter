using UnityEngine;
[System.Serializable]
public class SlotOverlayItem
{
    public int partIndex;
    public UMA.SlotDataAsset slot;
    public UMA.OverlayDataAsset overlay;


    public void InitializeData(ICharacterSlotOverly so)
    {
        Material m = overlay.material.material;
        m.shader = Shader.Find(m.shader.name);
        
        so.AddSlotWithNameIndex(partIndex, slot);
        so.AddOverlayWithNameIndex(partIndex, overlay);
    }
}