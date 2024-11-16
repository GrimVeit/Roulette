using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotBetView : View
{
    [SerializeField] private List<SlotBet> slotBets = new List<SlotBet>();
    [SerializeField] private TextMeshProUGUI textBet;

    [SerializeField] private Button buttonDistrictBet;
    [SerializeField] private Image imageButtonDistrictBet;
    [SerializeField] private Sprite spriteActivateDistrictBet;
    [SerializeField] private Sprite spriteDeactivateDistrictBet;

    [SerializeField] private Button buttonBet;
    [SerializeField] private Image imageButtonBet;
    [SerializeField] private Sprite spriteActivateBet;
    [SerializeField] private Sprite spriteDeactivateBet;

    public void Initialize()
    {
        for (int i = 0; i < slotBets.Count; i++)
        {
            slotBets[i].OnChooseBet += HandlerClickToChooseBet;
            slotBets[i].Initialize(i);
        }

        buttonBet.onClick.AddListener(HandlerClickToBet);
        buttonDistrictBet.onClick.AddListener(HandlerClickToDistrictBet);
    }

    public void Dispose()
    {
        for (int i = 0; i < slotBets.Count; i++)
        {
            slotBets[i].OnChooseBet -= HandlerClickToChooseBet;
            slotBets[i].Initialize(i);
        }

        buttonBet.onClick.RemoveListener(HandlerClickToBet);
        buttonDistrictBet.onClick.RemoveListener(HandlerClickToDistrictBet);
    }

    public void Select(int index)
    {
        slotBets[index].Select();
    }

    public void Deselect(int index)
    {
        slotBets[index].Deselect();
    }

    public void DisplayBet(int bet)
    {
        textBet.text = bet.ToString();
    }

    public void ActivateBetButton()
    {
        imageButtonBet.sprite = spriteActivateBet;
    }

    public void DeactivateBetButton()
    {
        imageButtonBet.sprite = spriteDeactivateBet;
    }

    public void ActivateBetDistrictButton()
    {
        imageButtonDistrictBet.sprite = spriteActivateDistrictBet;
    }

    public void DeactivateBetDistrictButton()
    {
        imageButtonDistrictBet.sprite = spriteDeactivateDistrictBet;
    }

    #region Input

    public event Action<ISlotBet> OnChooseBet;

    public event Action OnClickToBet;
    public event Action OnDistrictBet;

    private void HandlerClickToChooseBet(ISlotBet slotBet)
    {
        OnChooseBet(slotBet);
    }

    private void HandlerClickToDistrictBet()
    {
        OnDistrictBet?.Invoke();
    }

    private void HandlerClickToBet()
    {
        OnClickToBet?.Invoke();
    }

    #endregion
}
