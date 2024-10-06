using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipView : View
{
    public event Action<List<Chip>> OnRecallAllChips;
    public event Action<Chip> OnRetractLastChip;

    [SerializeField] private Canvas canvas;
    [SerializeField] private Transform parentSpawn;
    [SerializeField] private Chip chipPrefab;
    [SerializeField] private List<Chip> chips = new List<Chip>();

    [SerializeField] private Button recallAllChips;
    [SerializeField] private Button retractLastChip;

    public void Initialize()
    {
        recallAllChips.onClick.AddListener(HandlerClickToRecallAllChips);
        retractLastChip.onClick.AddListener(HandlerClickToRetractLastChip);
    }

    public void Dispose()
    {
        recallAllChips.onClick.RemoveListener(HandlerClickToRecallAllChips);
        retractLastChip.onClick.RemoveListener(HandlerClickToRetractLastChip);
    }

    public void SpawnChip(ChipData chipData, ICell cell, Vector2 vector)
    {
        Chip chip = Instantiate(chipPrefab, chipData.Parent);
        chip.transform.SetLocalPositionAndRotation(vector, chipPrefab.transform.rotation);
        chip.OnRetracted += OnRetractChip;
        chip.Initialize(chipData, cell);

        chips.Add(chip);
    }

    public void RecallAllChips(List<Chip> chips)
    {
        for (int i = 0; i < chips.Count; i++)
        {
            chips[i].Retract();
        }
    }

    public void RetractLastChip(Chip chip)
    {
        chip.Retract();
    }

    public void NoneRetractChip(Chip chip)
    {
        chip.NoneRetract();
    }

    public void DestroyChip(Chip chip)
    {
        chip.OnRetracted -= OnRetractChip;
        chips.Remove(chip);
        Destroy(chip.gameObject);
    }

    #region Input

    private void OnRetractChip(Chip chip)
    {
        chip.OnRetracted -= OnRetractChip;
        chip.OnNoneRetracted -= OnNoneRetracted;
        chips.Remove(chip);
        Destroy(chip.gameObject);
    }

    private void OnNoneRetracted(Chip chip)
    {
        chip.OnRetracted -= OnRetractChip;
        chip.OnNoneRetracted -= OnNoneRetracted;
        chips.Remove(chip);
        Destroy(chip.gameObject);
    }

    private void HandlerClickToRecallAllChips()
    {
        OnRecallAllChips?.Invoke(chips);
    }

    private void HandlerClickToRetractLastChip()
    {
        if (chips.Count == 0) return;
        OnRetractLastChip?.Invoke(chips[chips.Count - 1]);
    }

    #endregion
}
