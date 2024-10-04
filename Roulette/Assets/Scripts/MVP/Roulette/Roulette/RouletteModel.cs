using System;
using UnityEngine;

public class RouletteModel
{
    public event Action<Vector3> OnRollBallToSlot;
    public event Action OnStartSpin;

    public void StartSpin()
    {
        OnStartSpin?.Invoke();
    }

    public void RollBallToSlot(Vector3 vector)
    {
        OnRollBallToSlot?.Invoke(vector);
    }
}
