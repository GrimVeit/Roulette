using System;
using UnityEngine;

public class JokerEffectModel
{
    public event Action OnActivateSmallAnaimation;
    public event Action OnActivateBigAnimation;

    public void ActivateSmallAnimation()
    {
        OnActivateSmallAnaimation?.Invoke();
    }

    public void ActivateBigAnimation()
    {
        OnActivateBigAnimation?.Invoke();
    }
}
