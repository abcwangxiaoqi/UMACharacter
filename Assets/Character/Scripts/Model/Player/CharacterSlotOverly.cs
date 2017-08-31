
using UMA;
using UnityEngine;
public class CharacterSlotOverly : ICharacterSlotOverly
{
    UMADynamicAvatar umaDynamicAvatar;
    UMAContext umaContext;
    public CharacterSlotOverly(UMADynamicAvatar _umaDynamicAvatar)
    {
        umaDynamicAvatar = _umaDynamicAvatar;
        umaContext = UMAContext.FindInstance();
    }

    public void RemoveWeap(string weap)
    {
        int wp = int.Parse(weap);

        for (int i = wp*10; i < wp*10+10; i++)
        {
            RemoveSlotWithIndex(i);
        }
    }

    void RemoveSlotWithIndex(int index)
    {
        if (index < 0)
            return;
        umaDynamicAvatar.umaData.umaRecipe.slotDataList[index] = null;
    }

    public void AddSlotWithNameIndex(int index, SlotDataAsset slot)
    {
        if (index < 0)
            return;
        umaContext.slotLibrary.AddSlotAsset(slot);
        umaDynamicAvatar.umaData.umaRecipe.slotDataList[index] = umaContext.slotLibrary.InstantiateSlot(slot.slotName);
    }

    public void AddOverlayWithNameIndex(int slotIndex, OverlayDataAsset overlay)
    {
        if (slotIndex < 0)
            return;
        umaContext.overlayLibrary.AddOverlayAsset(overlay);
        umaDynamicAvatar.umaData.umaRecipe.slotDataList[slotIndex].AddOverlay(umaContext.overlayLibrary.InstantiateOverlay(overlay.overlayName));
    }

   public void AddSlotWithShareOverlays(int index, string slotName, int shareSlot)
    {
        if (index < 0)
            return;
        umaDynamicAvatar.umaData.umaRecipe.slotDataList[index] = umaContext.slotLibrary.InstantiateSlot(slotName, umaDynamicAvatar.umaData.umaRecipe.slotDataList[shareSlot].GetOverlayList());
    }

   public void SetOverlayColor(int slotIndex, OverlayDataAsset overlay, Color color)
   {
       if (slotIndex < 0)
           return;

       umaDynamicAvatar.umaData.umaRecipe.slotDataList[slotIndex].SetOverlayColor(color, new string[] { overlay.overlayName });
   }

   public void AddOverlayWithNameAndColor(int slotIndex, OverlayDataAsset overlay, Color color)
    {
        if (slotIndex < 0)
            return;
        umaContext.overlayLibrary.AddOverlayAsset(overlay);
        umaDynamicAvatar.umaData.umaRecipe.slotDataList[slotIndex].AddOverlay(umaContext.overlayLibrary.InstantiateOverlay(overlay.overlayName, color));
    }
}
