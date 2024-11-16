using System;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_Slots1Scene : MovePanel
{
    [SerializeField] private Button back_Button;

    public event Action GoToMainMenu_Action;

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        back_Button.onClick.AddListener(HandleGoToMainMenu_ButtonClick);
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        back_Button.onClick.RemoveListener(HandleGoToMainMenu_ButtonClick);
    }

    private void HandleGoToMainMenu_ButtonClick()
    {
        GoToMainMenu_Action?.Invoke();
    }
}
