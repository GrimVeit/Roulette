using System;
using UnityEngine;

public class UIMainMenuRoot : MonoBehaviour
{
    [SerializeField] private MainPanel_MainMenuScene mainPanel;
    [SerializeField] private DailyRewardPanel_MainMenuScene dailyRewardPanel;

    private bool isCooldownDailyRewardPanelActivated;
    private bool isCooldownDailyBonusPanelActivated;

    private ISoundProvider soundProvider;
    //private IParticleEffectProvider particleEffectProvider;

    private Panel currentPanel;

    public void Initialize()
    {
        mainPanel.SetSoundProvider(soundProvider);
        dailyRewardPanel.SetSoundProvider(soundProvider);

        mainPanel.Initialize();
        dailyRewardPanel.Initialize();
    }

    public void Activate()
    {
        //mainPanel.GoToRouletteGame_Action += HandlerGoToRouletteGame;

        dailyRewardPanel.OnClickBackButton += OpenMainPanel;

        OpenMainPanel();
    }

    public void Deactivate()
    {
        //mainPanel.GoToRouletteGame_Action -= HandlerGoToRouletteGame;

        dailyRewardPanel.OnClickBackButton -= OpenMainPanel;
    }

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void SetParticleEffectProvider(IParticleEffectProvider particleEffectProvider)
    {
        //this.particleEffectProvider = particleEffectProvider;
    }

    public void Dispose()
    {
        mainPanel.Dispose();
        dailyRewardPanel.Dispose();
    }


    private void OpenPanel(Panel panel)
    {
        if (currentPanel != null)
            currentPanel.DeactivatePanel();

        //soundProvider.PlayOneShot("ShoohPanel_Open");
        currentPanel = panel;
        currentPanel.ActivatePanel();

    }

    private void OpenOtherPanel(Panel panel)
    {
        panel.ActivatePanel();
    }

    private void CloseOtherPanel(Panel panel)
    {
        panel.DeactivatePanel();
    }

    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }

    public void OpenDailyRewardPanel()
    {
        OpenPanel(dailyRewardPanel);
    }

    #region Input Actions

    public event Action OnActivateMainMenuPanel
    {
        add { mainPanel.OnOpenPanel += value; }
        remove { mainPanel.OnOpenPanel -= value; }
    }

    public event Action OnDeactivateMainMenuPanel
    {
        add { mainPanel.OnClosePanel += value; }
        remove { mainPanel.OnClosePanel -= value; }
    }

    public event Action OnClickBackButtonFromDailyPanel
    {
        add { dailyRewardPanel.OnClickBackButton += value; }
        remove { dailyRewardPanel.OnClickBackButton -= value; }
    }

    public event Action OnGoToRouletteGame_Action
    {
        add { mainPanel.GoToRouletteGame_Action += value; }
        remove { mainPanel.GoToRouletteGame_Action -= value; }
    }

    public event Action OnGoToSlots1_Action
    {
        add { mainPanel.GoToSlot1_Action += value; }
        remove { mainPanel.GoToSlot1_Action -= value; }
    }

    public event Action OnGoToSlots2_Action
    {
        add { mainPanel.GoToSlot2_Action += value; }
        remove { mainPanel.GoToSlot2_Action -= value; }
    }

    public event Action OnGoToSlots3_Action
    {
        add { mainPanel.GoToSlot3_Action += value; }
        remove { mainPanel.GoToSlot3_Action -= value; }
    }

    #endregion
}
