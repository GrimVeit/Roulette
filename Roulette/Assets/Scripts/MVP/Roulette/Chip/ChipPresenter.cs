using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

        chipView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        chipView.Dispose();
    }

    private void ActivateEvents()
    {
        chipView.OnRecallAllChips += chipModel.RecallAllChips;
        chipView.OnRetractLastChip += chipModel.RetractLastChip;

        chipModel.OnSpawn += chipView.SpawnChip;
        chipModel.OnRecallAllChips += chipView.RecallAllChips;
        chipModel.OnRetractLastChip += chipView.RetractLastChip;
    }

    private void DeactivateEvents()
    {
        chipView.OnRecallAllChips -= chipModel.RecallAllChips;
        chipView.OnRetractLastChip -= chipModel.RetractLastChip;

        chipModel.OnSpawn -= chipView.SpawnChip;
        chipModel.OnRecallAllChips -= chipView.RecallAllChips;
        chipModel.OnRetractLastChip -= chipView.RetractLastChip;
    }

    #region Input

    public void SpawnChip(ChipData chipData, ICell cell, Vector2 vector) 
    {
        chipModel.SpawnChip(chipData, cell, vector);
    }

    #endregion
}
