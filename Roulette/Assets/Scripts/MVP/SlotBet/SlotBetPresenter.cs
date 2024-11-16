using System;

public class SlotBetPresenter
{
    private SlotBetModel slotBetModel;
    private SlotBetView slotBetView;

    public SlotBetPresenter(SlotBetModel slotBetModel, SlotBetView slotBetView)
    {
        this.slotBetModel = slotBetModel;
        this.slotBetView = slotBetView;
    }

    public void Initialize()
    {
        ActivateEvents();

        slotBetModel.Initialize();
        slotBetView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        slotBetModel.Dispose();
        slotBetView.Dispose();
    }

    private void ActivateEvents()
    {
        slotBetView.OnChooseBet += slotBetModel.ChooseBet;
        slotBetView.OnDistrictBet += slotBetModel.DistrictCurrentBet;
        slotBetView.OnClickToBet += slotBetModel.ClickToBetButton;

        slotBetModel.OnChooseBet_Count += slotBetView.DisplayBet;
        slotBetModel.OnSelectBetButton += slotBetView.Select;
        slotBetModel.OnDeselectBetButton += slotBetView.Deselect;

        slotBetModel.OnActivateBetButton += slotBetView.ActivateBetButton;
        slotBetModel.OnDeactivateBetButton += slotBetView.DeactivateBetButton;
        slotBetModel.OnActivateDistrictBetButton += slotBetView.ActivateBetDistrictButton;
        slotBetModel.OnDeactivateDistrictBetButton += slotBetView.DeactivateBetDistrictButton;
    }

    private void DeactivateEvents()
    {
        slotBetView.OnChooseBet -= slotBetModel.ChooseBet;
        slotBetView.OnDistrictBet -= slotBetModel.DistrictCurrentBet;
        slotBetView.OnClickToBet -= slotBetModel.ClickToBetButton;

        slotBetModel.OnChooseBet_Count -= slotBetView.DisplayBet;
        slotBetModel.OnSelectBetButton -= slotBetView.Select;
        slotBetModel.OnDeselectBetButton -= slotBetView.Deselect;
    }

    #region Input

    public void Activate()
    {
        slotBetModel.Activate();
    }

    public void Deactivate()
    {
        slotBetModel.Deactivate();
    }

    public event Action OnClickToBet
    {
        add { slotBetModel.OnClickToBetButton += value; }
        remove { slotBetModel.OnClickToBetButton -= value; }
    }

    public event Action OnChooseBet
    {
        add { slotBetModel.OnChooseBet += value; }
        remove { slotBetModel.OnChooseBet -= value; }
    }

    public event Action<int> OnChooseBet_Count
    {
        add { slotBetModel.OnChooseBet_Count += value; }
        remove { slotBetModel.OnChooseBet_Count -= value; }
    }

    #endregion
}
