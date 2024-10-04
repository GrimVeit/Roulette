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

    }

    private void DeactivateEvents()
    {

    }
}
