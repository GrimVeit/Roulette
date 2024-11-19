using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTrackerModel
{
    public event Action OnGoToRouletteGame;
    public event Action OnGoSlots1Game;
    public event Action OnGoSlots2Game;
    public event Action OnGoSlots3Game;

    public event Action<List<GameData>> OnGetData;

    public void LoadRouletteGame()
    {
        OnGoToRouletteGame?.Invoke();
    }

    public void LoadSlot1Game()
    {
        OnGoSlots1Game?.Invoke();
    }

    public void LoadSlot2Game()
    {
        OnGoSlots2Game?.Invoke();
    }
    
    public void LoadSlot3Game()
    {
        OnGoSlots3Game?.Invoke();
    }

    public void SetData(List<GameData> gameDatas)
    {
        OnGetData?.Invoke(gameDatas);
    }
}
