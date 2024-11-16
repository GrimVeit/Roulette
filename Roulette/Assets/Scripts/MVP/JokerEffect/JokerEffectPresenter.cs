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

    }

    public void Dispose()
    {

    }
}
