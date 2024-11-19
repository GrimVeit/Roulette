using System;
using System.Collections;
using UnityEngine;

public class TimeRealtimeModel
{
    private const string firstLaunchKey = "FIRST_LAUNCH_KEY";

    private DateTime firstLaunchData;
    private TimeSpan elapsedTime;

    private IEnumerator coroutineTimer;

    public IGameUnlocker gameUnlocker;

    public TimeRealtimeModel(IGameUnlocker gameUnlocker)
    {
        this.gameUnlocker = gameUnlocker;
    }

    public void Initialize()
    {
        if (!PlayerPrefs.HasKey(firstLaunchKey))
        {
            firstLaunchData = DateTime.UtcNow;
            PlayerPrefs.SetString(firstLaunchKey, firstLaunchData.ToString());
        }
        else
        {
            string savedDate = PlayerPrefs.GetString(firstLaunchKey);
            firstLaunchData = DateTime.Parse(savedDate);
        }

        elapsedTime = DateTime.UtcNow - firstLaunchData;

        if (elapsedTime.TotalSeconds >= 20)
        {
            gameUnlocker.UnlockGame(GameType.Roulette, 4);
        }
        else
        {
            if (coroutineTimer != null)
                Coroutines.Stop(coroutineTimer);

            coroutineTimer = TimerCoroutine();
            Coroutines.Start(coroutineTimer);
        }
    }

    public void Dispose()
    {
        if (coroutineTimer != null)
            Coroutines.Stop(coroutineTimer);
    }

    private IEnumerator TimerCoroutine()
    {
        while (elapsedTime.TotalSeconds < 20)
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));

            Debug.Log($"Time after first activate - " +
                $"{elapsedTime.TotalHours} hours, " +
                $"{elapsedTime.TotalMinutes} minutes, " +
                $"{elapsedTime.TotalSeconds} second");

            yield return new WaitForSeconds(1);
        }

        gameUnlocker.UnlockGame(GameType.Roulette, 4);
    }
}
