using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour
{
    public event Action<Chip> OnRetracted;

    [SerializeField] private Image image;

    public void Initialize(ChipData chipData)
    {
        image.sprite = chipData.Sprite;
    }

    public void Retract()
    {
        transform.DOLocalMove(Vector2.zero, 0.3f).OnComplete(() => OnRetracted?.Invoke(this));
    }
}
