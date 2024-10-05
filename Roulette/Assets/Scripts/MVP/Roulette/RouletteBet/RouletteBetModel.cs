using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBetModel
{
    public event Action<BetCell> OnChooseCell;
    public event Action<BetCell> OnResetCell;

    private IMoneyProvider moneyProvider;
    public RouletteBetModel(IMoneyProvider moneyProvider)
    {
        this.moneyProvider = moneyProvider;
    }

    public void ChooseCell(BetCell betCell, ChipData chipData)
    {
        moneyProvider.SendMoney(-chipData.Nominal);
        OnChooseCell?.Invoke(betCell);
    }

    public void ResetCell(BetCell betCell, ChipData chipData)
    {
        moneyProvider.SendMoney(chipData.Nominal);
        OnResetCell?.Invoke(betCell);
    }
}
