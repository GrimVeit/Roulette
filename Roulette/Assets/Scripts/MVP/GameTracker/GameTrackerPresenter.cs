using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTrackerPresenter
{
    private GameTrackerModel gameTrackerModel;
    private GameTrackerView gameTrackerView;

    public GameTrackerPresenter(GameTrackerModel gameTrackerModel, GameTrackerView gameTrackerView)
    {
        this.gameTrackerModel = gameTrackerModel;
        this.gameTrackerView = gameTrackerView;
    }

    public void Initialize()
    {
        ActivateEvents();

        gameTrackerView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        gameTrackerView.Dispose();
    }

    private void ActivateEvents()
    {
        gameTrackerModel.OnGetData += gameTrackerView.SetGameData;
    }

    private void DeactivateEvents()
    {
        gameTrackerModel.OnGetData -= gameTrackerView.SetGameData;
    }

    #region Input

    public void SetData(List<GameData> gameDatas)
    {
        gameTrackerModel.SetData(gameDatas);
    }

    #endregion
}
