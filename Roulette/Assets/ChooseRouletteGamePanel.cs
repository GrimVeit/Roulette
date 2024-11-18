using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRouletteGamePanel : MovePanel
{
    [SerializeField] private List<Button> rouletteGame_Buttons;

    private ISoundProvider soundProvider;

    public override void Initialize()
    {
        base.Initialize();

        for (int i = 0; i < rouletteGame_Buttons.Count; i++)
        {
            rouletteGame_Buttons[i].onClick.AddListener(HandleGoToRouletteGame_ButtonClick);
        }
    }

    public override void Dispose()
    {
        base.Dispose();

        for (int i = 0; i < rouletteGame_Buttons.Count; i++)
        {
            rouletteGame_Buttons[i].onClick.RemoveListener(HandleGoToRouletteGame_ButtonClick);
        }
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
