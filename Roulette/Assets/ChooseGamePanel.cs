using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseGamePanel : MovePanel
{
    public event Action OnClickBackButton;

    [SerializeField] private Button backButton;

    private ISoundProvider soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        backButton.onClick.AddListener(HandlerClickToBackButton);
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        backButton.onClick.RemoveListener(HandlerClickToBackButton);
    }

    private void HandlerClickToBackButton()
    {
        soundProvider.PlayOneShot("ClickClose");
        OnClickBackButton?.Invoke();
    }
}