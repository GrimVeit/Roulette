using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerEffectPresenter
{
    private JokerEffectModel jokerEffectModel;
    private JokerEffectView jokerEffectView;

    public JokerEffectPresenter(JokerEffectModel jokerEffectModel, JokerEffectView jokerEffectView)
    {
        this.jokerEffectModel = jokerEffectModel;
        this.jokerEffectView = jokerEffectView;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        jokerEffectModel.OnActivateBigAnimation += jokerEffectView.ActivateBigAnimation;
        jokerEffectModel.OnActivateSmallAnaimation += jokerEffectView.ActivateSmallAnimation;
    }

    private void DeactivateEvents()
    {
        jokerEffectModel.OnActivateBigAnimation -= jokerEffectView.ActivateBigAnimation;
        jokerEffectModel.OnActivateSmallAnaimation -= jokerEffectView.ActivateSmallAnimation;
    }

    #region Input

    public void ActivateSmallAnimaion()
    {
        jokerEffectModel.ActivateSmallAnimation();
    }

    public void ActivateBigAnimation()
    {
        jokerEffectModel.ActivateBigAnimation();
    }

    #endregion
}
