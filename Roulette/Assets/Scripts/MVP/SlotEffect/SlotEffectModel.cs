using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotEffectModel
{
    public event Action<SlotGrid, List<SlotValue>> OnGetSlotGrid;

    public void SetSlotGrid(SlotGrid slotGrid, List<SlotValue> slotValues)
    {
        OnGetSlotGrid?.Invoke(slotGrid, slotValues);
    }
}
