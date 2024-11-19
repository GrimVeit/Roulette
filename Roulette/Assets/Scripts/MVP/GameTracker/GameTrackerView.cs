using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTrackerView : View
{
    public event Action OnGoToRouletteGame;
    public event Action OnGoSlots1Game;
    public event Action OnGoSlots2Game;
    public event Action OnGoSlots3Game;


    [SerializeField] private List<GameVisibleData> gameVisibleData = new List<GameVisibleData>();

    private List<GameData> gameData = new List<GameData>();

    [SerializeField] private GameTrackerDisplay gameTrackerDisplay;

    private Action actionToPlay;

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

        gameTrackerDisplay.Initialize();
    }

    public void Dispose()
    {
        for (int i = 0; i < gameVisibleData.Count; i++)
        {
            gameVisibleData[i].OnClickToButton -= HandlerClickToChooseButton;
            gameVisibleData[i].Dispose();
        }

        gameTrackerDisplay.Dispose();
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
                    if (gameData[i].Type == GameType.Roulette)
                    {
                        actionToPlay = HandlerGoToRouletteGame;
                    }
                    else
                    {
                        switch (gameData[i].Number)
                        {
                            case 0:
                                actionToPlay = HandlerGoToSlots1Game;
                                break;
                            case 1:
                                actionToPlay = HandlerGoToSlots2Game;
                                break;
                            case 2:
                                actionToPlay = HandlerGoToSlots3Game;
                                break;
                        }
                    }

                    gameTrackerDisplay.VisibleUnlock(gameVisibleData[i].NameGame, gameVisibleData[i].SpriteGame, actionToPlay);
                }
                else
                {
                    //????????????????????????????????
                    gameTrackerDisplay.VisibleLock(gameVisibleData[i].Description);
                }
            }
        }
    }


    #region Input

    private void HandlerGoToRouletteGame()
    {
        Debug.Log("Load roulette game");
        OnGoToRouletteGame?.Invoke();
    }

    private void HandlerGoToSlots1Game()
    {
        Debug.Log("Load slot 1 game");
        OnGoSlots1Game?.Invoke();
    }

    private void HandlerGoToSlots2Game()
    {
        Debug.Log("Load slot 2 game");
        OnGoSlots2Game?.Invoke();
    }

    private void HandlerGoToSlots3Game()
    {
        Debug.Log("Load slot 3 game");
        OnGoSlots3Game?.Invoke();
    }

    #endregion
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
