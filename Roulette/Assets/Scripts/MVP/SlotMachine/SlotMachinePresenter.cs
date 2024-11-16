using System;

public class SlotMachinePresenter
{
    private SlotMachineModel slotMachineModel;
    private SlotMachineView slotMachineView;

    public SlotMachinePresenter(SlotMachineModel slotMachineModel, SlotMachineView slotMachineView)
    {
        this.slotMachineModel = slotMachineModel;
        this.slotMachineView = slotMachineView;
    }

    public void Initialize()
    {
        slotMachineView.Initialize();

        ActivateInputEvents();

        slotMachineModel.OnStartSpin += slotMachineView.ActivateMachine;
        slotMachineModel.OnStartSpin += slotMachineView.DeactivateSpinButton;
        slotMachineModel.OnStopSpin += slotMachineView.ActivateSpinButton;
        slotMachineModel.OnActivateMachine += slotMachineView.ActivateSpinButton;
        slotMachineModel.OnDeactivateMachine += slotMachineView.DeactivateSpinButton;

        ActivateDisplayEvents();
    }

    public void Dispose()
    {
        DeactivateInputEvents();

        slotMachineModel.OnStartSpin -= slotMachineView.ActivateMachine;
        slotMachineModel.OnStartSpin -= slotMachineView.DeactivateSpinButton;
        slotMachineModel.OnStopSpin -= slotMachineView.ActivateSpinButton;
        slotMachineModel.OnActivateMachine -= slotMachineView.ActivateSpinButton;
        slotMachineModel.OnDeactivateMachine -= slotMachineView.DeactivateSpinButton;

        DeactivateDisplayEvents();
    }

    private void ActivateInputEvents()
    {
        slotMachineView.OnStopSpinSlot += slotMachineModel.StopSpinSlot;
        slotMachineView.OnClickSpin += slotMachineModel.ActivateMachine;
        slotMachineView.OnClickAutoSpin += slotMachineModel.Autospin;
        //slotMachineView.OnWheelSpeed += slotMachineModel.WheelSpeed;
    }

    private void ActivateDisplayEvents()
    {
        slotMachineModel.OnWin += slotMachineView.WinMoney;
        slotMachineModel.OnFail += slotMachineView.FailMoney;
        slotMachineModel.OnActivateAutoSpin += slotMachineView.StartAutoSpin;
        slotMachineModel.OnDeactivateAutoSpin += slotMachineView.StopAutoSpin;
    }

    private void DeactivateInputEvents()
    {
        slotMachineView.OnStopSpinSlot -= slotMachineModel.StopSpinSlot;
        slotMachineView.OnClickSpin -= slotMachineModel.ActivateMachine;
        slotMachineView.OnClickAutoSpin -= slotMachineModel.Autospin;
        //slotMachineView.OnWheelSpeed -= slotMachineModel.WheelSpeed;
    }

    private void DeactivateDisplayEvents()
    {
        slotMachineModel.OnWin -= slotMachineView.WinMoney;
        slotMachineModel.OnFail -= slotMachineView.FailMoney;
        slotMachineModel.OnActivateAutoSpin -= slotMachineView.StartAutoSpin;
        slotMachineModel.OnDeactivateAutoSpin -= slotMachineView.StopAutoSpin;
    }

    #region PublicEvents

    public event Action<float> OnWin
    {
        add { slotMachineModel.OnWin += value; }
        remove { slotMachineModel.OnWin -= value; }
    }

    public event Action OnFail
    {
        add { slotMachineModel.OnFail += value; }
        remove { slotMachineModel.OnFail -= value; }
    }

    public event Action OnStartSpin
    {
        add { slotMachineModel.OnStartSpin += value; }
        remove { slotMachineModel.OnStartSpin -= value; }
    }

    public event Action OnStopSpin
    {
        add { slotMachineModel.OnStopSpin += value; }
        remove { slotMachineModel.OnStopSpin -= value; }
    }

    public void SetBet(int bet)
    {
        slotMachineModel.SetBet(bet);
    }

    #endregion
}
