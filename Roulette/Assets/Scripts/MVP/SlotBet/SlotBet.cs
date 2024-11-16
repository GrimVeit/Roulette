using System;
using UnityEngine;
using UnityEngine.UI;

public class SlotBet : MonoBehaviour, ISlotBet
{
    [SerializeField] private Button buttonBet;
    [SerializeField] private int bet;
    private int currentIndex;
    private bool isSelect = false;

    public int Bet => bet;
    public int BetIndex => currentIndex;
    public bool IsSelect => isSelect;

    public void Initialize(int index)
    {
        currentIndex = index;

        buttonBet.onClick.AddListener(HandlerClickToChooseBetButton);
    }

    public void Dispose()
    {
        buttonBet.onClick.RemoveListener(HandlerClickToChooseBetButton);
    }

    public void Select()
    {
        isSelect = true;
        buttonBet.gameObject.SetActive(false);
    }

    public void Deselect()
    {
        isSelect = false;
        buttonBet.gameObject.SetActive(true);
    }

    #region Input

    public event Action<ISlotBet> OnChooseBet;

    private void HandlerClickToChooseBetButton()
    {
        OnChooseBet?.Invoke(this);
    }

    #endregion
}


public interface ISlotBet
{
    int Bet { get; }
    int BetIndex { get; }
    bool IsSelect { get; }
}
