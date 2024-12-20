using System;
using UnityEngine;

public class UIMainMenuRoot : MonoBehaviour
{
    [SerializeField] private MainPanel_MainMenuScene mainPanel;
    [SerializeField] private DailyRewardPanel_MainMenuScene dailyRewardPanel;

    [SerializeField] private ChooseRouletteGamePanel chooseRouletteGamePanel;
    [SerializeField] private ChooseSlotGamePanel chooseSlotGamePanel;
    [SerializeField] private ChooseGamePanel chooseGamePanel;

    private bool isCooldownDailyRewardPanelActivated;
    private bool isCooldownDailyBonusPanelActivated;

    private ISoundProvider soundProvider;
    //private IParticleEffectProvider particleEffectProvider;

    private Panel currentPanel;

    public void Initialize()
    {
        mainPanel.SetSoundProvider(soundProvider);
        dailyRewardPanel.SetSoundProvider(soundProvider);
        chooseRouletteGamePanel.SetSoundProvider(soundProvider);
        chooseSlotGamePanel.SetSoundProvider(soundProvider);
        chooseGamePanel.SetSoundProvider(soundProvider);

        mainPanel.Initialize();
        dailyRewardPanel.Initialize();
        chooseRouletteGamePanel.Initialize();
        chooseSlotGamePanel.Initialize();
        chooseGamePanel.Initialize();
    }

    public void Activate()
    {
        //mainPanel.GoToRouletteGame_Action += HandlerGoToRouletteGame;

        dailyRewardPanel.OnClickBackButton += OpenMainPanel;

        chooseRouletteGamePanel.OnOpenPanel += mainPanel.DeactivateRouletteButton;
        chooseRouletteGamePanel.OnClosePanel += mainPanel.ActivateRouletteButton;
        chooseSlotGamePanel.OnOpenPanel += mainPanel.DeactivateSlotMachineButton;
        chooseSlotGamePanel.OnClosePanel += mainPanel.ActivateSlotMachineButton;

        mainPanel.OnChooseRoulettePanel += CheckChooseRouletteGame;
        mainPanel.OnChooseSlotPanel += CheckChooseSlotGame;

        chooseRouletteGamePanel.OnOpenChooseGamePanel_Action += OpenChooseGamePanel;
        chooseSlotGamePanel.OnOpenChooseGamePanel_Action += OpenChooseGamePanel;
        chooseGamePanel.OnClickBackButton += CloseChooseGamePanel;

        OpenMainPanel();
    }

    public void Deactivate()
    {
        //mainPanel.GoToRouletteGame_Action -= HandlerGoToRouletteGame;

        dailyRewardPanel.OnClickBackButton -= OpenMainPanel;

        chooseRouletteGamePanel.OnOpenPanel -= mainPanel.DeactivateRouletteButton;
        chooseRouletteGamePanel.OnClosePanel -= mainPanel.ActivateRouletteButton;
        chooseSlotGamePanel.OnOpenPanel -= mainPanel.DeactivateSlotMachineButton;
        chooseSlotGamePanel.OnClosePanel -= mainPanel.ActivateSlotMachineButton;

        mainPanel.OnChooseRoulettePanel -= CheckChooseRouletteGame;
        mainPanel.OnChooseSlotPanel -= CheckChooseSlotGame;

        chooseRouletteGamePanel.OnOpenChooseGamePanel_Action -= OpenChooseGamePanel;
        chooseSlotGamePanel.OnOpenChooseGamePanel_Action -= OpenChooseGamePanel;
        chooseGamePanel.OnClickBackButton -= CloseChooseGamePanel;

        currentPanel.DeactivatePanel();
        chooseGamePanel.DeactivatePanel();
    }

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void SetParticleEffectProvider(IParticleEffectProvider particleEffectProvider)
    {
        //this.particleEffectProvider = particleEffectProvider;
    }

    private void CheckChooseRouletteGame()
    {
        if (chooseRouletteGamePanel.IsOpenPanel)
        {
            CloseChooseRouletteGamePanel();
        }
        else
        {
            OpenChooseRouletteGamePanel();
        }
    }

    private void CheckChooseSlotGame()
    {
        if (chooseSlotGamePanel.IsOpenPanel)
        {
            CloseChooseSlotGamePanel();
        }
        else
        {
            OpenChooseSlotGamePanel();
        }
    }

    public void Dispose()
    {
        mainPanel.Dispose();
        dailyRewardPanel.Dispose();
        chooseRouletteGamePanel.Dispose();
        chooseSlotGamePanel.Dispose();
        chooseGamePanel.Dispose();
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
        if (chooseRouletteGamePanel.IsOpenPanel)
        {
            CloseChooseRouletteGamePanel();
        }

        if (chooseSlotGamePanel.IsOpenPanel)
        {
            CloseChooseSlotGamePanel();
        }

        OpenPanel(dailyRewardPanel);
    }

    public void OpenChooseRouletteGamePanel()
    {
        OpenOtherPanel(chooseRouletteGamePanel);
    }

    public void CloseChooseRouletteGamePanel()
    {
        CloseOtherPanel(chooseRouletteGamePanel);
    }

    public void OpenChooseSlotGamePanel()
    {
        OpenOtherPanel(chooseSlotGamePanel);
    }

    public void CloseChooseSlotGamePanel()
    {
        CloseOtherPanel(chooseSlotGamePanel);
    }

    public void OpenChooseGamePanel()
    {
        OpenOtherPanel(chooseGamePanel);
    }

    public void CloseChooseGamePanel()
    {
        CloseOtherPanel(chooseGamePanel);
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

    public event Action OnOpenChooseGamePanelFromRoulette
    {
        add { chooseRouletteGamePanel.OnOpenChooseGamePanel_Action += value; }
        remove { chooseRouletteGamePanel.OnOpenChooseGamePanel_Action -= value; }
    }

    public event Action OnOpenChooseGamePanelFromSlots
    {
        add { chooseSlotGamePanel.OnOpenChooseGamePanel_Action += value; }
        remove { chooseSlotGamePanel.OnOpenChooseGamePanel_Action -= value; }
    }

    public event Action OnCloseChooseGamePanel
    {
        add { chooseGamePanel.OnClickBackButton += value; }
        remove { chooseGamePanel.OnClickBackButton -= value; }
    }

    #endregion
}
