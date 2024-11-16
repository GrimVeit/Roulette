using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlots3SceneRoot : MonoBehaviour
{
    [SerializeField] private MainPanel_Slots1Scene mainPanel;
    [SerializeField] private BetPanel_Slots1Scene betPanel;

    private ISoundProvider soundProvider;

    private Panel currentPanel;

    public void Initialize()
    {
        mainPanel.Initialize();
        betPanel.Initialize();
    }

    public void Activate()
    {
        OpenMainPanel();
    }

    public void Deactivate()
    {

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

    #region Input Actions

    public event Action OnGoToMainMenu
    {
        add { mainPanel.GoToMainMenu_Action += value; }
        remove { mainPanel.GoToMainMenu_Action -= value; }
    }

    #endregion
}
