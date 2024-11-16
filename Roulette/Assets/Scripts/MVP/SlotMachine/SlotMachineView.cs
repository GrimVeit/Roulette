using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineView : View
{
    public event Action OnClickSpin;
    public event Action OnClickAutoSpin;
    public event Action OnStartSpinSlot;
    public event Action<int, float> OnWheelSpeed;
    public event Action<int[], int> OnStopSpinSlot;

    [SerializeField] private Button spinButton;
    [SerializeField] private Image imageSpinButton;
    [SerializeField] private Sprite spriteActiveSpinButton;
    [SerializeField] private Sprite spriteDeactiveSpinButton;
    //[SerializeField] private Button autoSpinButton;

    //[SerializeField] private TextMeshProUGUI winMoneyText;
    //[SerializeField] private Transform winMoneyDisplay;

    //private Vector3 defaultSizeWinMoneyDisplay;


    [SerializeField] private Slot[] slots;
    [SerializeField] private int rowCounts;

    public void Initialize()
    {
        //defaultSizeWinMoneyDisplay = winMoneyDisplay.transform.localScale;

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Initialize(i, rowCounts);
            slots[i].OnStopSpin += EndSpinSlot;
            slots[i].OnStartSpin += StartSpinSlot;
            slots[i].OnWheelSpeed += WheelSpeed;
        }

        spinButton.onClick.AddListener(HandlerSpinClick);
        //autoSpinButton.onClick.AddListener(HandlerAutoSpinClick);

    }

    public void OnDestroy()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].OnStartSpin -= StartSpinSlot;
            slots[i].OnStopSpin -= EndSpinSlot;
            slots[i].OnWheelSpeed -= WheelSpeed;
        }

        spinButton.onClick.RemoveListener(HandlerSpinClick);
        //autoSpinButton.onClick.RemoveListener(HandlerAutoSpinClick);
    }

    public void ActivateMachine()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].StartSpin();
        }
    }

    public void ActivateSpinButton()
    {
        imageSpinButton.sprite = spriteActiveSpinButton;
    }

    public void DeactivateSpinButton()
    {
        imageSpinButton.sprite = spriteDeactiveSpinButton;
    }


    public void StartSpinSlot()
    {
        OnStartSpinSlot?.Invoke();
    }

    public void EndSpinSlot(int[] slotIDs, int index)
    {
        OnStopSpinSlot?.Invoke(slotIDs, index);
    }


    public void WinMoney(float money)
    {
        //winMoneyText.text = money.ToString();
        //winMoneyDisplay.DOScale(new Vector3(1.8f, 1.8f, 1.8f), 0.1f).OnComplete(() => winMoneyDisplay.DOScale(defaultSizeWinMoneyDisplay, 0.2f));
    }

    public void FailMoney()
    {
        //winMoneyText.text = 0.ToString();
    }

    public void WheelSpeed(int index, float speed)
    {
        OnWheelSpeed?.Invoke(index, speed);
    }

    public void StartAutoSpin()
    {

    }

    public void StopAutoSpin()
    {

    }

    #region Input

    private void HandlerSpinClick()
    {
        OnClickSpin?.Invoke();
    }

    private void HandlerAutoSpinClick()
    {
        OnClickAutoSpin?.Invoke();
    }

    #endregion

}
