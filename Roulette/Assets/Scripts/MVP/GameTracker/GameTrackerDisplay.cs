using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTrackerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textNameGame;
    [SerializeField] private Image imageGame;
    [SerializeField] private Sprite spriteGameZero;
    [SerializeField] private GameObject objectQuestionInImage;
    [SerializeField] private TextMeshProUGUI textDescription;
    [SerializeField] private GameObject objectDescription;
    [SerializeField] private GameObject objectButtonPlay;
    [SerializeField] private Button buttonPlay;

    private event Action OnClickToButton;

    public void Initialize()
    {
        buttonPlay.onClick.AddListener(HandlerClickToPlayButton);
    }

    public void Dispose()
    {
        buttonPlay.onClick.RemoveListener(HandlerClickToPlayButton);
    }

    public void VisibleLock(string description)
    {
        textNameGame.text = "?";
        imageGame.sprite = spriteGameZero;
        objectQuestionInImage.SetActive(true);
        objectDescription.SetActive(true);
        textDescription.text = description;
        objectButtonPlay.SetActive(false);
    }

    public void VisibleUnlock(string gameName, Sprite spriteGame)
    {
        textNameGame.text = gameName;
        imageGame.sprite = spriteGame;
        objectQuestionInImage.SetActive(false);
        objectDescription.SetActive(false);
        objectButtonPlay.SetActive(true);
    }

    #region Input

    private void HandlerClickToPlayButton()
    {
        OnClickToButton?.Invoke();
    }

    #endregion
}
