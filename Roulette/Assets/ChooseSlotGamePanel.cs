using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSlotGamePanel : MovePanel
{
    public bool IsOpenPanel => isOpenPanel;
    private bool isOpenPanel;

    [SerializeField] private List<Button> slotGame_Buttons;

    private ISoundProvider soundProvider;

    public override void Initialize()
    {
        base.Initialize();

        for (int i = 0; i < slotGame_Buttons.Count; i++)
        {
            slotGame_Buttons[i].onClick.AddListener(HandleGoToRouletteGame_ButtonClick);
        }
    }

    public override void Dispose()
    {
        base.Dispose();

        for (int i = 0; i < slotGame_Buttons.Count; i++)
        {
            slotGame_Buttons[i].onClick.RemoveListener(HandleGoToRouletteGame_ButtonClick);
        }
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        isOpenPanel = true;
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        isOpenPanel = false;
    }

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    #region Input

    public event Action OnOpenChooseGamePanel_Action;

    private void HandleGoToRouletteGame_ButtonClick()
    {
        soundProvider.PlayOneShot("Click");
        OnOpenChooseGamePanel_Action?.Invoke();
    }

    #endregion
}
