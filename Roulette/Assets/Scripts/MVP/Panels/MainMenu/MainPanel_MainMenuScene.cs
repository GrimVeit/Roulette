using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_MainMenuScene : MovePanel
{
    public event Action OnOpenPanel;
    public event Action OnClosePanel;

    [SerializeField] private Button chooseRouletteGame_Button;
    [SerializeField] private Button chooseSlotGame_Button;
    [SerializeField] private Image imageRouletteButton;
    [SerializeField] private Image imageSlotMachineButton;
    [SerializeField] private Sprite spriteRouletteActive;
    [SerializeField] private Sprite spriteSlotMachineActive;
    [SerializeField] private Sprite spriteRouletteDeactive;
    [SerializeField] private Sprite spriteSlotMachineDeactive;

    public event Action OnChooseRoulettePanel;
    public event Action OnChooseSlotPanel;

    private ISoundProvider soundProvider;

    public override void Initialize()
    {
        base.Initialize();

        chooseRouletteGame_Button.onClick.AddListener(HandlerClickToChooseRouletteGameButton);
        chooseSlotGame_Button.onClick.AddListener(HandlerClickToChooseSlotGameButton);
    }

    public override void Dispose()
    {
        base.Dispose();

        chooseRouletteGame_Button.onClick.RemoveListener(HandlerClickToChooseRouletteGameButton);
        chooseSlotGame_Button.onClick.RemoveListener(HandlerClickToChooseSlotGameButton);
    }

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public override void ActivatePanel()
    {
        OnOpenPanel?.Invoke();

        base.ActivatePanel();
    }

    public override void DeactivatePanel()
    {
        OnClosePanel?.Invoke();

        base.DeactivatePanel();
    }



    public void ActivateRouletteButton()
    {
        imageRouletteButton.sprite = spriteRouletteActive;
    }

    public void DeactivateRouletteButton()
    {
        imageRouletteButton.sprite = spriteRouletteDeactive;
    }

    public void ActivateSlotMachineButton()
    {
        imageSlotMachineButton.sprite = spriteSlotMachineActive;
    }

    public void DeactivateSlotMachineButton()
    {
        imageSlotMachineButton.sprite = spriteSlotMachineDeactive;
    }

    #region Input


    private void HandlerClickToChooseRouletteGameButton()
    {
        OnChooseRoulettePanel?.Invoke();
    }

    private void HandlerClickToChooseSlotGameButton()
    {
        OnChooseSlotPanel?.Invoke();
    }

    #endregion
}
