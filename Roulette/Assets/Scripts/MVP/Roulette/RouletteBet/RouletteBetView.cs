using System.Collections.Generic;
using UnityEngine;

public class RouletteBetView : View
{
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

    private void OnChooseCell(BetCell betCell)
    {
        usedCells.Add(betCell);
    }

    private void OnResetCell(BetCell betCell)
    {
        usedCells.Remove(betCell);
    }
}
