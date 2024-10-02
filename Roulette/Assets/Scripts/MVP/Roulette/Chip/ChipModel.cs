

using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChipModel
{
    public event Action OnRecallAllBets;
    public event Action OnRetractLastBet;

    public event Action<ChipData, Vector2> OnSpawn;

    public void SpawnChip(ChipData chipData, Vector2 vector)
    {
        OnSpawn?.Invoke(chipData, vector);
    }

    public void RecallAllBets()
    {
        OnRecallAllBets?.Invoke();
    }

    public void RetractLastBet()
    {
        OnRetractLastBet?.Invoke();
    }
}
