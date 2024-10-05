using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour
{
    public event Action<Chip> OnRetracted;

    [SerializeField] private Image image;
    private ICell cell;
    private ChipData chipData;

    public void Initialize(ChipData chipData, ICell cell)
    {
        this.chipData = chipData;
        this.cell = cell;

        image.sprite = this.chipData.Sprite;
        this.cell.ChooseBet(chipData);
    }

    public void Retract()
    {
        cell.ResetBet(chipData);
        transform.DOLocalMove(Vector2.zero, 0.3f).OnComplete(() => OnRetracted?.Invoke(this));
    }
}
