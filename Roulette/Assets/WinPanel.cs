using System;
using System.Collections;
using UnityEngine;

public class WinPanel : MovePanel
{
    public event Action OnCloseWinPanel;

    private IEnumerator timerCoroutine;

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        ActivateTimer();
    }

    private void ActivateTimer()
    {
        if (timerCoroutine != null)
            Coroutines.Stop(timerCoroutine);

        timerCoroutine = TimerCoroutine();
        Coroutines.Start(timerCoroutine);
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(2f);

        OnCloseWinPanel?.Invoke();
    }
}
