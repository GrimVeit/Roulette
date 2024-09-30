using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRouletteRoot : MonoBehaviour
{

    private ISoundProvider soundProvider;
    //private IParticleEffectProvider particleEffectProvider;

    private Panel currentPanel;

    public void Initialize()
    {

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
        //OpenPanel(mainPanel);
    }
}
