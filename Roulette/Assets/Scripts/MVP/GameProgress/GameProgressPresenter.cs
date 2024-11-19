using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressPresenter : IGameUnlocker
{
    private GameProgressModel gameProgressModel;

    public GameProgressPresenter(GameProgressModel gameProgressModel)
    {
        this.gameProgressModel = gameProgressModel;
    }

    public void Initialize()
    {
        gameProgressModel.Initialize();
    }

    public void Dispose()
    {
        gameProgressModel.Dispose();
    }

    #region Input

    public void UnlockGame(GameType type, int number)
    {
        gameProgressModel.UnlockGame(type, number);
    }

    public event Action<List<GameData>> OnGetData
    {
        add { gameProgressModel.OnGetData += value; }
        remove { gameProgressModel.OnGetData -= value; }
    }

    #endregion
}

public interface IGameUnlocker
{
    public void UnlockGame(GameType type, int number);
}
