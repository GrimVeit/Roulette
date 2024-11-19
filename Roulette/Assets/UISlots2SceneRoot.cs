using System;
using UnityEngine;

public class UISlots2SceneRoot : MonoBehaviour
{
    [SerializeField] private MainPanel_Slots1Scene mainPanel;
    [SerializeField] private BetPanel_Slots1Scene betPanel;
    [SerializeField] private WinPanel winPanel;

    private ISoundProvider soundProvider;

    private Panel currentPanel;

    public void Initialize()
    {
        mainPanel.Initialize();
        betPanel.Initialize();
        winPanel.Initialize();
    }

    public void Activate()
    {
        OpenMainPanel();
    }

    public void Deactivate()
    {
        currentPanel.DeactivatePanel();
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
        betPanel.Dispose();
        winPanel.Dispose();
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

    public void OpenBetPanel()
    {
        OpenOtherPanel(betPanel);
    }

    public void CloseBetPanel()
    {
        CloseOtherPanel(betPanel);
    }

    public void OpenWinPanel()
    {
        OpenOtherPanel(winPanel);
    }

    public void CloseWinPanel()
    {
        CloseOtherPanel(winPanel);
    }

    #region Input Actions

    public event Action OnGoToMainMenu
    {
        add { mainPanel.GoToMainMenu_Action += value; }
        remove { mainPanel.GoToMainMenu_Action -= value; }
    }

    public event Action OnCloseWinPanel
    {
        add { winPanel.OnCloseWinPanel += value; }
        remove { winPanel.OnCloseWinPanel -= value; }
    }

    #endregion
}
