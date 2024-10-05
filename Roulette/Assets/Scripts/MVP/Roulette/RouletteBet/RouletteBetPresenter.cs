using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBetPresenter
{
    private RouletteBetModel rouletteBetModel;
    private RouletteBetView rouletteBetView;

    public RouletteBetPresenter(RouletteBetModel rouletteBetModel, RouletteBetView rouletteBetView)
    {
        this.rouletteBetModel = rouletteBetModel;
        this.rouletteBetView = rouletteBetView;
    }

    public void Initialize()
    {
        ActivateEvents();

        rouletteBetView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        rouletteBetView.Dispose();
    }

    private void ActivateEvents()
    {
        rouletteBetView.OnChooseCell_Action += rouletteBetModel.ChooseCell;
        rouletteBetView.OnResetCell_Action += rouletteBetModel.ResetCell;

        rouletteBetModel.OnChooseCell += rouletteBetView.ChooseCell;
        rouletteBetModel.OnResetCell += rouletteBetView.ResetCell;
    }

    private void DeactivateEvents()
    {
        rouletteBetView.OnChooseCell_Action -= rouletteBetModel.ChooseCell;
        rouletteBetView.OnResetCell_Action -= rouletteBetModel.ResetCell;

        rouletteBetModel.OnChooseCell -= rouletteBetView.ChooseCell;
        rouletteBetModel.OnResetCell -= rouletteBetView.ResetCell;
    }
}
