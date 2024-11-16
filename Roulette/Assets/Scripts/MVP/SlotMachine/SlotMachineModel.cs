using System;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineModel
{
    public bool IsAuto { get; private set; } = false;
    public bool IsSpinMachine { get; private set; }

    public int Bet { get; private set; } = 0;

    public event Action OnActivateMachine;
    public event Action OnDeactivateMachine;

    public event Action OnStartSpin;
    public event Action OnStopSpinnedSlot;
    public event Action OnStopSpin;

    public event Action<float> OnWin;
    public event Action OnFail;

    public event Action OnActivateAutoSpin;
    public event Action OnDeactivateAutoSpin;

    private int spinnedSlotCount = 0;

    private Combination combinations;

    private IMoneyProvider moneyProvider;
    //private IParticleEffectProvider particleEffectProvider;
    //private ISoundProvider soundProvider;
    //private ISound[] slotWheelsSound;

    private int[,] combination;

    private int slotCount;
    private float winMoney;

    private Dictionary<WinType, Action> winTypeActions = new Dictionary<WinType, Action>();

    private bool isActive = false;

    public SlotMachineModel(int columnSlot, int rowSlot, Combination combinations, IMoneyProvider moneyProvider, ISoundProvider soundProvider, IParticleEffectProvider particleEffectProvider)
    {
        this.combinations = combinations;
        this.moneyProvider = moneyProvider;

        slotCount = columnSlot;

        //slotWheelsSound = new ISound[columnSlot];
        combination = new int[rowSlot, columnSlot];

        winTypeActions[WinType.Small] = HandleSmallWin;
        winTypeActions[WinType.Big] = HandleBigWin;
        winTypeActions[WinType.NoWin] = HandleNoWin;

        //GetSounds();
    }

    #region Sounds

    //private void GetSounds()
    //{
    //    for (int i = 0; i < slotWheelsSound.Length; i++)
    //    {
    //        slotWheelsSound[i] = soundProvider.GetSound("Wheel_" + i);
    //    }
    //}

    //private void PlayWheelSounds()
    //{
    //    for (int i = 0; i < slotWheelsSound.Length; i++)
    //    {
    //        slotWheelsSound[i].SetVolume(0.1f);
    //        slotWheelsSound[i].SetPitch(1);
    //        slotWheelsSound[i].Play();
    //    }
    //}

    //private void StopWheelSounds()
    //{
    //    for (int i = 0; i < slotWheelsSound.Length; i++)
    //    {
    //        slotWheelsSound[i].Stop();
    //    }
    //}

    //public void WheelSpeed(int index, float speed)
    //{
    //    if (speed > 0.1f)
    //    {
    //        return;
    //    }

    //    slotWheelsSound[index].SetVolume(speed/2);

    //    float pitch = Mathf.Lerp(1, 0.88f, 1 - speed);
    //    slotWheelsSound[index].SetPitch(pitch * 1f);


    //}

    #endregion

    public void SetBet(int bet)
    {
        Bet = bet;

        if (Bet <= 0)
        {
            isActive = false;
            OnDeactivateMachine?.Invoke();
        }
        else
        {
            isActive = true;
            OnActivateMachine?.Invoke();
        }
    }

    public void ActivateMachine()
    {
        if (!isActive) return;

        //if (Bet == 0) MinBet();

        if (IsSpinMachine)
        {
            //soundProvider.PlayOneShot("Error");
            return;
        }

        if (!moneyProvider.CanAfford(Bet))
        {
            //soundProvider.PlayOneShot("Error");

            if (IsAuto)
                Autospin();
            return;
        }

        IsSpinMachine = true;
        //PlayWheelSounds();
        moneyProvider.SendMoney(-Bet);
        spinnedSlotCount = slotCount;
        OnStartSpin?.Invoke();
    }

    public void Autospin()
    {
        IsAuto = !IsAuto;

        if (IsAuto)
        {
            OnActivateAutoSpin?.Invoke();
            ActivateMachine();
        }
        else
        {
            OnDeactivateAutoSpin?.Invoke();
        }
    }

    public void StopSpinSlot(int[] slotID, int index)
    {
        spinnedSlotCount -= 1;

        for (int i = 0; i < slotID.Length; i++)
        {
            combination[i, index] = slotID[i];
        }

        OnStopSpinnedSlot?.Invoke();

        if (spinnedSlotCount == 0) DeactivateMachine();
    }

    public void DeactivateMachine()
    {
        OnStopSpin?.Invoke();
        CheckResults();
        IsSpinMachine = false;

        //StopWheelSounds();

        if (IsAuto)
            ActivateMachine();

    }

    private void CheckResults()
    {
        WinType winType = WinType.NoWin;

        winMoney = 0;

        foreach (var grid in combinations.SlotGrids)
        {
            int? firstValue = null;
            bool isWinningCombination = true;

            foreach (var pos in grid.slotPositions)
            {
                int row = pos.Row;
                int col = pos.Col;

                int value = combination[row, col];

                if(firstValue == null)
                {
                    firstValue = value;
                }
                else
                {
                    if(value != firstValue)
                    {
                        isWinningCombination = false;
                        break;
                    }
                }
            }

            if (isWinningCombination)
            {
                winMoney += Bet * grid.BetMultyply;

                if(grid.WinType == WinType.Big)
                   winType = grid.WinType;

                if (winType != WinType.Big)
                   winType = grid.WinType;
            }
        }

        winTypeActions[winType].Invoke();


        //int rows = combination.GetLength(0);
        //int columns = combination.GetLength(1);

        //for (int i = 0; i < rows; i++)
        //{
        //    string rowString = "Ñòðîêà " + (i + 1) + ": ";

        //    for (int j = 0; j < columns; j++)
        //    {
        //        rowString += combination[i, j] + " ";
        //    }

        //    Debug.Log(rowString.TrimEnd());
        //}
    }

    private void HandleSmallWin()
    {
        moneyProvider.SendMoney(winMoney);
        OnWin?.Invoke(winMoney);

        //soundProvider.PlayOneShot("SmallWin");
        //particleEffectProvider.Play("SmallWin");
        Debug.Log("ÀÊÒÈÂÀÖÈß ÌÀËÅÍÜÊÎÉ ÏÎÁÅÄÛ");
    }

    private void HandleBigWin()
    {
        moneyProvider.SendMoney(winMoney);
        OnWin?.Invoke(winMoney);

        //soundProvider.PlayOneShot("BigWin");
        //particleEffectProvider.Play("BigWin");
        Debug.Log("ÀÊÒÈÂÀÖÈß ÁÎËÜØÎÉ ÏÎÁÅÄÛ");
    }

    private void HandleNoWin()
    {
        OnFail?.Invoke();
        //soundProvider.PlayOneShot("NoWin");
        Debug.Log("ÀÊÒÈÂÀÖÈß ÏÐÎÈÃÐÛØÀ");
    }
}
