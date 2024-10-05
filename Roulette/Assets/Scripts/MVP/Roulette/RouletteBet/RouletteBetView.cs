using System;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBetView : View
{
    public event Action<BetCell, ChipData> OnChooseCell_Action;
    public event Action<BetCell, ChipData> OnResetCell_Action;

    [SerializeField] private List<BetCell> betCells = new List<BetCell>();

    [SerializeField] private List<BetCell> usedCells = new List<BetCell>();

    public void Initialize()
    {
        for (int i = 0; i < betCells.Count; i++)
        {
            betCells[i].OnChooseCell += OnChooseCell;
            betCells[i].OnResetCell += OnResetCell;
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < betCells.Count; i++)
        {
            betCells[i].OnChooseCell -= OnChooseCell;
            betCells[i].OnResetCell -= OnResetCell;
        }
    }

    public void ChooseCell(BetCell betCell)
    {
        usedCells.Add(betCell);
    }

    public void ResetCell(BetCell betCell)
    {
        usedCells.Remove(betCell);
    }

    #region Input

    private void OnChooseCell(BetCell betCell, ChipData chipData)
    {
        OnChooseCell_Action?.Invoke(betCell, chipData);
    }

    private void OnResetCell(BetCell betCell, ChipData chipData)
    {
        OnResetCell_Action?.Invoke(betCell, chipData);
    }

    #endregion
}
