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

    public event Action OnOpenChooseRoulettePanel;
    public event Action OnCloseChooseRoulettePanel;
    public event Action OnOpenChooseSlotPanel;
    public event Action OnCloseChooseSlotPanel;

    private ISoundProvider soundProvider;

    private bool isRoulettePanelOpen = false;
    private bool isSlotPanelOpen = false;

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

    #region Input


    private void HandlerClickToChooseRouletteGameButton()
    {
        if (isRoulettePanelOpen)
        {
            isRoulettePanelOpen = false;
            OnCloseChooseRoulettePanel?.Invoke();
        }
        else
        {
            isRoulettePanelOpen = true;
            OnOpenChooseRoulettePanel?.Invoke();
        }
    }

    private void HandlerClickToChooseSlotGameButton()
    {
        if (isSlotPanelOpen)
        {
            isSlotPanelOpen = false;
            OnCloseChooseSlotPanel?.Invoke();
        }
        else
        {
            isSlotPanelOpen = true;
            OnOpenChooseSlotPanel?.Invoke();
        }
    }

    #endregion
}
