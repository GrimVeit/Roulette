using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_MainMenuScene : MovePanel
{
    public event Action OnOpenPanel;
    public event Action OnClosePanel;

    [SerializeField] private List<Button> rouletteGame_Buttons;
    [SerializeField] private Button slot1_Button;
    [SerializeField] private Button slot2_Button;
    [SerializeField] private Button slot3_Button;

    public event Action GoToRouletteGame_Action;
    public event Action GoToSlot1_Action;
    public event Action GoToSlot2_Action;
    public event Action GoToSlot3_Action;

    private ISoundProvider soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public override void ActivatePanel()
    {
        OnOpenPanel?.Invoke();

        base.ActivatePanel();

        for (int i = 0; i < rouletteGame_Buttons.Count; i++)
        {
            rouletteGame_Buttons[i].onClick.AddListener(HandleGoToRouletteGame_ButtonClick);
        }

        slot1_Button.onClick.AddListener(HandleGoToSlot1Game_ButtonClick);
        slot2_Button.onClick.AddListener(HandleGoToSlot2Game_ButtonClick);
        slot3_Button.onClick.AddListener(HandleGoToSlot3Game_ButtonClick);
    }

    public override void DeactivatePanel()
    {
        OnClosePanel?.Invoke();

        base.DeactivatePanel();

        for (int i = 0; i < rouletteGame_Buttons.Count; i++)
        {
            rouletteGame_Buttons[i].onClick.RemoveListener(HandleGoToRouletteGame_ButtonClick);
        }

        slot1_Button.onClick.RemoveListener(HandleGoToSlot1Game_ButtonClick);
        slot2_Button.onClick.RemoveListener(HandleGoToSlot2Game_ButtonClick);
        slot3_Button.onClick.RemoveListener(HandleGoToSlot3Game_ButtonClick);
    }

    #region Input

    private void HandleGoToRouletteGame_ButtonClick()
    {
        soundProvider.PlayOneShot("Click");
        GoToRouletteGame_Action?.Invoke();
    }

    private void HandleGoToSlot1Game_ButtonClick()
    {
        soundProvider.PlayOneShot("Click");
        GoToSlot1_Action?.Invoke();
    }
    
    private void HandleGoToSlot2Game_ButtonClick()
    {
        soundProvider.PlayOneShot("Click");
        GoToSlot2_Action?.Invoke();
    }

    private void HandleGoToSlot3Game_ButtonClick()
    {
        soundProvider.PlayOneShot("Click");
        GoToSlot3_Action?.Invoke();
    }

    #endregion
}
