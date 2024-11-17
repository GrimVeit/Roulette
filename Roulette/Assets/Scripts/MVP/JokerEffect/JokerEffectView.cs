using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerEffectView : View
{
    [SerializeField] private List<Joker> jokers = new List<Joker>();

    [SerializeField] private float durationForSmallAnimation;
    [SerializeField] private float speedChangeForSmallAnimation;
    [SerializeField] private float durationForBigAnimation;
    [SerializeField] private float speedChangeForBigAnimation;

    public void ActivateSmallAnimation()
    {
        for (int i = 0; i < jokers.Count; i++)
        {
            jokers[i].ActivateAnimation(durationForSmallAnimation, speedChangeForSmallAnimation);
        }
    }

    public void ActivateBigAnimation()
    {
        for (int i = 0; i < jokers.Count; i++)
        {
            jokers[i].ActivateAnimation(durationForBigAnimation, speedChangeForBigAnimation);
        }
    }
}
