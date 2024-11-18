using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTrackerView : View
{
    [SerializeField] private List<GameVisibleData> gameVisibleData = new List<GameVisibleData>();

    private List<GameData> gameData = new List<GameData>();

    [SerializeField] private GameTrackerDisplay gameTrackerDisplay;

    public void SetGameData(List<GameData> gameDatas)
    {
        gameData = gameDatas;

        Debug.Log(gameData.Count + " - rftvgybhunjmikol");

        for (int i = 0; i < gameData.Count; i++)
        {
            Debug.Log($"Type game - {gameData[i].Type}, NumberGame - {gameData[i].Number}, Unlocked - {gameData[i].IsOpen}");
        }
    }

    public void Initialize()
    {
        for (int i = 0;i < gameVisibleData.Count; i++)
        {
            gameVisibleData[i].OnClickToButton += HandlerClickToChooseButton;
            gameVisibleData[i].Initialize();
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < gameVisibleData.Count; i++)
        {
            gameVisibleData[i].OnClickToButton -= HandlerClickToChooseButton;
            gameVisibleData[i].Dispose();
        }
    }

    private void HandlerClickToChooseButton(GameType type, int index)
    {
        Debug.Log($"{type} // {index}");

        for (int i = 0; i < gameData.Count; i++)
        {
            if (gameData[i].Type == type && gameData[i].Number == index)
            {
                if (gameData[i].IsOpen)
                {
                    //????????????????????????????????
                    gameTrackerDisplay.VisibleUnlock(gameVisibleData[index].NameGame, gameVisibleData[index].SpriteGame);
                }
                else
                {
                    //????????????????????????????????
                    gameTrackerDisplay.VisibleLock(gameVisibleData[index].Description);
                }
            }
        }
    }
}

[System.Serializable]
public class GameVisibleData
{
    [SerializeField] private GameType gameType;
    [SerializeField] private int number;
    [SerializeField] private Button buttonChoose;
    [SerializeField] private string nameGame;
    [SerializeField] private Sprite spriteGame;
    [SerializeField] private string description;

    public event Action<GameType, int> OnClickToButton;

    public Button ButtonChoose => buttonChoose;
    public string NameGame => nameGame;
    public Sprite SpriteGame => spriteGame;
    public string Description => description;

    public void Initialize()
    {
        buttonChoose.onClick.AddListener(HandleClickToButton);
    }

    public void Dispose()
    {
        buttonChoose.onClick.RemoveListener(HandleClickToButton);
    }

    private void HandleClickToButton()
    {
        OnClickToButton?.Invoke(gameType, number);
    }
}
