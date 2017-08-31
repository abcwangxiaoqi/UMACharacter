using UnityEngine;
using UMA;

public interface ICharacterSlotOverly
{
    void RemoveWeap(string weap);
    //void RemoveSlotWithIndex(int index);
    void AddSlotWithNameIndex(int index, SlotDataAsset slot);
    void AddOverlayWithNameIndex(int slotIndex, OverlayDataAsset overlay);
    void AddSlotWithShareOverlays(int index, string slotName, int shareSlot);
    void AddOverlayWithNameAndColor(int slotIndex, OverlayDataAsset overlay, Color color);
    void SetOverlayColor(int slotIndex, OverlayDataAsset overlay, Color color);
}