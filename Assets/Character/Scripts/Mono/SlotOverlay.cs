using UnityEngine;
using System.Collections;
using UMA;
using System.Collections.Generic;

public class SlotOverlay : MonoBehaviour {

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
