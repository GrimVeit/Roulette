using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PseudoChipView : View
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private List<PseudoChip> pseudoChips = new List<PseudoChip>();

    [SerializeField] private PseudoChip currentPseudoChip;

    public void Initialize()
    {
        for (int i = 0; i < pseudoChips.Count; i++)
        {
            pseudoChips[i].OnGrabbing += SetCurrentChip; 
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < pseudoChips.Count; i++)
        {
            pseudoChips[i].OnGrabbing -= SetCurrentChip;
        }
    }

    private void SetCurrentChip(PseudoChip chip)
    {
        if (currentPseudoChip != null)
        {
            currentPseudoChip.OnStartMove -= OnStartMove;
            currentPseudoChip.OnMove -= OnMove;
            currentPseudoChip.OnEndMove -= OnEndMove;
        }
        currentPseudoChip = chip;

        currentPseudoChip.OnStartMove += OnStartMove;
        currentPseudoChip.OnMove += OnMove;
        currentPseudoChip.OnEndMove += OnEndMove;

        currentPseudoChip.Initialize();
    }

    public void Teleport()
    {
        currentPseudoChip.Teleport();
    }

    public void StartMove()
    {
        currentPseudoChip.StartMove();
    }

    public void EndMove()
    {
        currentPseudoChip.EndMove();
    }

    public void Move(Vector2 vector)
    {
        currentPseudoChip.Move(vector);
    }

    #region Input

    private void OnMove(Vector2 vector)
    {
        OnMove_Action?.Invoke(vector / canvas.scaleFactor);
    }

    private void OnStartMove()
    {
        OnStartMove_Action?.Invoke();
    }

    private void OnEndMove(Transform transform)
    {
        OnEndMove_Action?.Invoke(transform, currentPseudoChip.ChipData);
    }

    public event Action<Vector2> OnMove_Action;

    public event Action OnStartMove_Action;

    public event Action<Transform, ChipData> OnEndMove_Action;

    #endregion
}
