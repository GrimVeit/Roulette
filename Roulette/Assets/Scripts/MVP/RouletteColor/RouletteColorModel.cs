using System;
using UnityEngine;

public class RouletteColorModel
{
    public event Action<int> OnChooseColorIndex;

    private int currentIndex;

    public void Initialize()
    {
        currentIndex = PlayerPrefs.GetInt(PlayerPrefsKeys.ROULETTE_COLOR_INDEX, 0);
        OnChooseColorIndex?.Invoke(currentIndex);
    }

    public void Dispose()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.ROULETTE_COLOR_INDEX, currentIndex);
    }

    public void ChooseColorIndex(int index)
    {
        currentIndex = index;
        OnChooseColorIndex?.Invoke(currentIndex);
    }
}
