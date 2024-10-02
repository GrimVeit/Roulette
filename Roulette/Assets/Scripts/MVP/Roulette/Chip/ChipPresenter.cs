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
        chipView.OnRecallAllBets += chipModel.RecallAllBets;
        chipView.OnRetractLastBet += chipModel.RetractLastBet;

        chipModel.OnSpawn += chipView.SpawnChip;
        chipModel.OnRecallAllBets += chipView.RecallAllBets;
        chipModel.OnRetractLastBet += chipView.RetractLastBet;
    }

    private void DeactivateEvents()
    {
        chipView.OnRecallAllBets -= chipModel.RecallAllBets;
        chipView.OnRetractLastBet -= chipModel.RetractLastBet;

        chipModel.OnSpawn -= chipView.SpawnChip;
        chipModel.OnRecallAllBets -= chipView.RecallAllBets;
        chipModel.OnRetractLastBet -= chipView.RetractLastBet;
    }

    #region Input

    public void SpawnChip(ChipData chipData, Vector2 vector) 
    {
        chipModel.SpawnChip(chipData, vector);
    }

    #endregion
}
