using System;
using UnityEngine;

public class RouletteBallModel
{
    public event Action<Vector3> OnBallStopped;
    public event Action OnStartSpin;
    public void StartSpin()
    {
        OnStartSpin?.Invoke();
    }

    public void BallStopped(Vector3 vector)
    {
        OnBallStopped?.Invoke(vector);
    }
}
