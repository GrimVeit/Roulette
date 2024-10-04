using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PseudoChipModel
{
    public event Action<ChipData, Vector2> OnSpawnChip;

    public event Action OnStartMove;
    public event Action<Vector2> OnMove;
    public event Action OnEndMove;
    public event Action OnTeleporting;

    private bool isActive = true;

    public PseudoChipModel()
    {

    }

    public void StartMove()
    {
        if (!isActive) return;

        OnStartMove?.Invoke();
    }

    public void Move(Vector2 vector)
    {
        if (!isActive) return;

        OnMove?.Invoke(vector);
    }

    public void EndMove(Transform transform, ChipData chipData)
    {
        if (!isActive) return;

        Collider2D collider = Physics2D.OverlapPoint(transform.position);

        if(collider != null)
        {
            Debug.Log(collider.gameObject.name);

            if(collider.gameObject.TryGetComponent(out ICell cell))
            {
                cell.ChooseBet(chipData.Nominal);
            }
        }

        OnSpawnChip?.Invoke(chipData, transform.localPosition);

        //OnEndMove?.Invoke();

        Teleport();
    }

    public void Teleport()
    {
        OnTeleporting?.Invoke();
    }

    public void Activate()
    {
        isActive = true;
    }


    public void Deactivate()
    {
        isActive = false;
    }
}
