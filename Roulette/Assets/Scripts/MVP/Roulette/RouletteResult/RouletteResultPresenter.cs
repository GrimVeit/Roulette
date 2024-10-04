using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteResultPresenter
{
    private RouletteResultModel rouletteResultModel;
    private RouletteResultView rouletteResultView;

    public RouletteResultPresenter(RouletteResultModel rouletteResultModel, RouletteResultView rouletteResultView)
    {
        this.rouletteResultModel = rouletteResultModel;
        this.rouletteResultView = rouletteResultView;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {

    }

    private void DeactivateEvents()
    {

    }
}
