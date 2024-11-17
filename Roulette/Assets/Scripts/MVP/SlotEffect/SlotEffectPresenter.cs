using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotEffectPresenter
{
    private SlotEffectModel slotEffectModel;
    private SlotEffectView slotEffectView;

    public SlotEffectPresenter(SlotEffectModel slotEffectModel, SlotEffectView slotEffectView)
    {
        this.slotEffectModel = slotEffectModel;
        this.slotEffectView = slotEffectView;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        slotEffectModel.OnGetSlotGrid += slotEffectView.VisualSlotGrid;
    }

    private void DeactivateEvents()
    {
        slotEffectModel.OnGetSlotGrid -= slotEffectView.VisualSlotGrid;
    }


    #region Input

    public void SetSlotGrid(SlotGrid slotGrid, List<SlotValue> slotValues)
    {
        slotEffectModel.SetSlotGrid(slotGrid, slotValues);
    }

    #endregion
}
