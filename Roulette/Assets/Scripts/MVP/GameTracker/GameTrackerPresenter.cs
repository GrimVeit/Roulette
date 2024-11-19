using System;
using System.Collections.Generic;

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

        gameTrackerView.OnGoToRouletteGame += gameTrackerModel.LoadRouletteGame;
        gameTrackerView.OnGoSlots1Game += gameTrackerModel.LoadSlot1Game;
        gameTrackerView.OnGoSlots2Game += gameTrackerModel.LoadSlot2Game;
        gameTrackerView.OnGoSlots3Game += gameTrackerModel.LoadSlot3Game;
    }

    private void DeactivateEvents()
    {
        gameTrackerModel.OnGetData -= gameTrackerView.SetGameData;

        gameTrackerView.OnGoToRouletteGame -= gameTrackerModel.LoadRouletteGame;
        gameTrackerView.OnGoSlots1Game -= gameTrackerModel.LoadSlot1Game;
        gameTrackerView.OnGoSlots2Game -= gameTrackerModel.LoadSlot2Game;
        gameTrackerView.OnGoSlots3Game -= gameTrackerModel.LoadSlot3Game;
    }

    #region Input

    public event Action OnGoToRouletteGame
    {
        add { gameTrackerModel.OnGoToRouletteGame += value; }
        remove { gameTrackerModel.OnGoToRouletteGame -= value; }
    }

    public event Action OnGoSlots1Game
    {
        add { gameTrackerModel.OnGoSlots1Game += value; }
        remove { gameTrackerModel.OnGoSlots1Game -= value; }
    }

    public event Action OnGoSlots2Game
    {
        add { gameTrackerModel.OnGoSlots2Game += value; }
        remove { gameTrackerModel.OnGoSlots2Game -= value; }
    }

    public event Action OnGoSlots3Game
    {
        add { gameTrackerModel.OnGoSlots3Game += value; }
        remove { gameTrackerModel.OnGoSlots3Game -= value; }
    }

    public void SetData(List<GameData> gameDatas)
    {
        gameTrackerModel.SetData(gameDatas);
    }

    #endregion
}
