using System;

public class RouletteResultModel
{
    public event Action OnStartShowResult;
    public event Action OnFinishShowResult;
    public event Action OnStartHideResult;
    public event Action OnFinishHideResult;

    public event Action<RouletteSlotValue> OnShowResult;
    public event Action OnHideResult;

    public void ShowResult(RouletteSlotValue rouletteSlotValue)
    {
        OnShowResult?.Invoke(rouletteSlotValue);
    }

    public void HideResult()
    {
        OnHideResult?.Invoke();
    }

    public void StartShowResult()
    {
        OnStartShowResult?.Invoke();
    }

    public void FinishShowResult()
    {
        OnFinishShowResult?.Invoke();
    }

    public void StartHideResult()
    {
        OnStartHideResult?.Invoke();
    }

    public void FinishHideResult()
    {
        OnFinishHideResult?.Invoke();
    }
}
