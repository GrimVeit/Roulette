using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipView : View
{
    public event Action OnRecallAllBets;
    public event Action OnRetractLastBet;

    [SerializeField] private Canvas canvas;
    [SerializeField] private Transform parentSpawn;
    [SerializeField] private Chip chipPrefab;
    [SerializeField] private List<Chip> chips = new List<Chip>();

    [SerializeField] private Button recallAllBets;
    [SerializeField] private Button retractLastBet;

    public void Initialize()
    {
        recallAllBets.onClick.AddListener(HandlerClickToRecallAllBets);
        retractLastBet.onClick.AddListener(HandlerClickToRetractLastBet);
    }

    public void Dispose()
    {
        recallAllBets.onClick.RemoveListener(HandlerClickToRecallAllBets);
        retractLastBet.onClick.RemoveListener(HandlerClickToRetractLastBet);
    }

    public void SpawnChip(ChipData chipData, Vector2 vector)
    {
        Chip chip = Instantiate(chipPrefab, chipData.Parent);
        chip.transform.SetLocalPositionAndRotation(vector, chipPrefab.transform.rotation);
        chip.OnRetracted += RetractChip;
        chip.Initialize(chipData);

        chips.Add(chip);
    }

    public void RecallAllBets()
    {
        for (int i = 0; i < chips.Count; i++)
        {
            chips[i].Retract();
        }
    }

    public void RetractLastBet()
    {
        if(chips.Count != 0)
        chips[chips.Count - 1].Retract();
    }

    private void RetractChip(Chip chip)
    {
        chip.OnRetracted -= RetractChip;
        chips.Remove(chip);
        Destroy(chip.gameObject);
    }

    #region Input

    private void HandlerClickToRecallAllBets()
    {
        OnRecallAllBets?.Invoke();
    }

    private void HandlerClickToRetractLastBet()
    {
        OnRetractLastBet?.Invoke();
    }

    #endregion
}
