using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RouletteColor
{
    public bool IsActiveButton => isActiveButton;
    public event Action<int> OnChooseColorIndex;

    [SerializeField] private Button buttonChoose;

    private int currentIndex;
    private bool isActiveButton;

    public void Initialize(int index)
    {
        currentIndex = index;

        buttonChoose.onClick.AddListener(HandlerClickToChooseButton);
    }

    public void Dispose()
    {
        buttonChoose.onClick.RemoveListener(HandlerClickToChooseButton);
    }

    public void ActivateButton()
    {
        buttonChoose.gameObject.SetActive(true);
        isActiveButton = true;
    }

    public void DeactivateButton()
    {
        buttonChoose.gameObject.SetActive(false);
        isActiveButton = false;
    }

    private void HandlerClickToChooseButton()
    {
        OnChooseColorIndex?.Invoke(currentIndex);
    }
}
