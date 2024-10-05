using System;
using UnityEngine;

public class BetCell : MonoBehaviour, ICell
{
    [SerializeField] private Bet bet;

    public event Action<BetCell, ChipData> OnChooseCell;
    public event Action<BetCell, ChipData> OnResetCell;

    public void ChooseBet(ChipData chipData)
    {
        OnChooseCell?.Invoke(this, chipData);
    }

    public void ResetBet(ChipData chipData)
    {
        OnResetCell?.Invoke(this, chipData);
    }
}

public interface ICell
{
    void ChooseBet(ChipData chipData);
    void ResetBet(ChipData chipData);
}
