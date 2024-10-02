using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipPresenter
{
    private ChipModel chipModel;
    private ChipView chipView;

    public ChipPresenter(ChipModel chipModel, ChipView chipView)
    {
        this.chipModel = chipModel;
        this.chipView = chipView;
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

    }

    private void DeactivateEvents()
    {

    }
}
