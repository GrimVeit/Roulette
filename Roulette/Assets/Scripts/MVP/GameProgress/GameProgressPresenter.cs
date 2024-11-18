using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressPresenter
{
    private GameProgressModel gameProgressModel;
    private GameProgressView gameProgressView;

    public GameProgressPresenter(GameProgressModel gameProgressModel, GameProgressView gameProgressView)
    {
        this.gameProgressModel = gameProgressModel;
        this.gameProgressView = gameProgressView;
    }

    public void Initialize()
    {
        ActivateEvents();

        gameProgressModel.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        gameProgressModel.Dispose();
    }

    private void ActivateEvents()
    {

    }

    private void DeactivateEvents()
    {

    }

    #region Input

    public event Action<List<GameData>> OnGetData
    {
        add { gameProgressModel.OnGetData += value; }
        remove { gameProgressModel.OnGetData -= value; }
    }

    #endregion
}
