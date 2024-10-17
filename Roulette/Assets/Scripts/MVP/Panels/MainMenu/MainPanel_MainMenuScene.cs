using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_MainMenuScene : MovePanel
{
    public event Action OnOpenPanel;
    public event Action OnClosePanel;

    [SerializeField] private Button miniGame_Button;
    [SerializeField] private Button chooseColor_Button;

    public event Action GoToMiniGame_Action;
    public event Action GoToChooseColorPanel;

    private ISoundProvider soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public override void ActivatePanel()
    {
        OnOpenPanel?.Invoke();

        base.ActivatePanel();

        miniGame_Button.onClick.AddListener(HandleGoToMiniGame_ButtonClick);
        chooseColor_Button.onClick.AddListener(HandleChooseColor_ButtonClick);
    }

    public override void DeactivatePanel()
    {
        OnClosePanel?.Invoke();

        base.DeactivatePanel();

        miniGame_Button.onClick.RemoveListener(HandleGoToMiniGame_ButtonClick);
        chooseColor_Button.onClick.RemoveListener(HandleChooseColor_ButtonClick);
    }

    private void HandleGoToMiniGame_ButtonClick()
    {
        soundProvider.PlayOneShot("Click");
        GoToMiniGame_Action?.Invoke();
    }

    private void HandleChooseColor_ButtonClick()
    {
        soundProvider.PlayOneShot("Click");
        GoToChooseColorPanel?.Invoke();
    }
}
