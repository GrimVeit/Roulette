using System;
using UnityEngine;

public class SlotBetModel
{
    public event Action<int> OnChooseBet_Count;
    public event Action OnChooseBet;

    public event Action<int> OnDeselectBetButton;
    public event Action<int> OnSelectBetButton;

    public event Action OnClickToBetButton;

    public event Action OnActivateBetButton;
    public event Action OnDeactivateBetButton;
    public event Action OnActivateDistrictBetButton;
    public event Action OnDeactivateDistrictBetButton;

    private bool isActive = true;

    private ISlotBet currentSlotBet;

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void Activate()
    {
        isActive = true;

        OnActivateBetButton?.Invoke();
        OnActivateDistrictBetButton?.Invoke();
    }

    public void Deactivate()
    {
        isActive = false;

        OnDeactivateBetButton?.Invoke();
        OnDeactivateDistrictBetButton?.Invoke();
    }

    public void ClickToBetButton()
    {
        if (!isActive) return;

        OnClickToBetButton?.Invoke();
    }

    public void DistrictCurrentBet()
    {
        if (!isActive) return;

        if (currentSlotBet != null)
            OnDeselectBetButton?.Invoke(currentSlotBet.BetIndex);

        OnChooseBet_Count?.Invoke(0);
    }

    public void ChooseBet(ISlotBet slotBet)
    {
        DistrictCurrentBet();

        currentSlotBet = slotBet;
        OnChooseBet_Count?.Invoke(currentSlotBet.Bet);
        OnChooseBet?.Invoke();
        OnSelectBetButton?.Invoke(currentSlotBet.BetIndex);
    }
}
