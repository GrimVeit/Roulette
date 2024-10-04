using System;
using UnityEngine;

public class BetCell : MonoBehaviour, ICell
{
    [SerializeField] private Bet bet;

    public event Action<BetCell> OnChooseCell;
    public event Action<BetCell> OnResetCell;

    public void ChooseBet(int bet)
    {
        //OnChooseCell?.Invoke(this);

        Debug.Log("Выбрана ставка с такими данными");

        for (int i = 0; i < this.bet.Numbers.Count; i++)
        {
            Debug.Log(this.bet.Numbers[i]);
        }
    }

    public void ResetBet()
    {
        OnResetCell?.Invoke(this);
    }
}

public interface ICell
{
    void ChooseBet(int bet);
    void ResetBet();
}
