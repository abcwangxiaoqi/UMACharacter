using UnityEngine;
using System.Collections;
using UMA;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public RaceData race;//基础骨骼信息
    public RuntimeAnimatorController anim;//animator controller
    public List<SlotOverlayItem> slotoverlays;

    public void InitializeSlotData(ICharacterSlotOverly so)
    {
        if (slotoverlays == null)
            return;
        for (int i = 0; i < slotoverlays.Count; i++)
        {
            slotoverlays[i].InitializeData(so);
        }
    }
}
