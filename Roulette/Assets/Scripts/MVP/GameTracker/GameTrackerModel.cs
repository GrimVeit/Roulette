using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTrackerModel
{
    public event Action<List<GameData>> OnGetData;

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void SetData(List<GameData> gameDatas)
    {
        OnGetData?.Invoke(gameDatas);
    }
}
