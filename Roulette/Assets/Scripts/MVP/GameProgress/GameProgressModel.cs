using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameProgressModel
{
    public event Action<List<GameData>> OnGetData;

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "GameDatas.json");

    [SerializeField] private List<GameData> Datas = new List<GameData>();

    public void Initialize()
    {
        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            GameDatas gameDatas = JsonUtility.FromJson<GameDatas>(loadedJson);

            Datas = gameDatas.Datas.ToList();
        }
        else
        {
            Datas = new List<GameData>
            {
                new GameData(GameType.Roulette, 0, true),
                new GameData(GameType.Roulette, 1, true),
                new GameData(GameType.Roulette, 2, false),
                new GameData(GameType.Roulette, 3, false),
                new GameData(GameType.Roulette, 4, false),
                new GameData(GameType.Roulette, 5, false),
                new GameData(GameType.Slot, 0, true),
                new GameData(GameType.Slot, 1, false),
                new GameData(GameType.Slot, 2, false),
                new GameData(GameType.Slot, 3, false)
            };
        }

        OnGetData?.Invoke(Datas);

        for (int i = 0; i < Datas.Count; i++)
        {
            Debug.Log($"Type game - {Datas[i].Type}, NumberGame - {Datas[i].Number}, Unlocked - {Datas[i].IsOpen}");
        }
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new GameDatas(Datas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void UnlockGame(GameType type, int number)
    {
        var gameData = Datas.FirstOrDefault(gd => gd.Type == type && gd.Number == number);

        if(gameData != null && !gameData.IsOpen)
        {
            gameData.IsOpen = true;
            OnGetData?.Invoke(Datas);
            return;
        }
    }
}

public enum GameType
{
    Roulette,
    Slot
}

[System.Serializable]
public class GameData
{
    public GameType Type;
    public int Number;
    public bool IsOpen;

    public GameData(GameType type, int number, bool isOpen)
    {
        Type = type;
        Number = number;
        IsOpen = isOpen;
    }
}

[System.Serializable]
public class GameDatas
{
    public GameData[] Datas;

    public GameDatas(GameData[] datas)
    {
        Datas = datas;
    }
}
