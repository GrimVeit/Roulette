using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PseudoChipPresenter
{
    private PseudoChipModel pseudoChipModel;
    private PseudoChipView pseudoChipView;

    public PseudoChipPresenter(PseudoChipModel pseudoChipModel, PseudoChipView pseudoChipView)
    {
        this.pseudoChipModel = pseudoChipModel;
        this.pseudoChipView = pseudoChipView;
    }

    public void Initialize()
    {
        ActivateEvents();

        pseudoChipView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        pseudoChipView.Dispose();
    }

    private void ActivateEvents()
    {
        pseudoChipView.OnStartMove_Action += pseudoChipModel.StartMove;
        pseudoChipView.OnMove_Action += pseudoChipModel.Move;
        pseudoChipView.OnEndMove_Action += pseudoChipModel.EndMove;

        pseudoChipModel.OnStartMove += pseudoChipView.StartMove;
        pseudoChipModel.OnMove += pseudoChipView.Move;
        pseudoChipModel.OnEndMove += pseudoChipView.EndMove;
    }

    private void DeactivateEvents()
    {
        pseudoChipView.OnStartMove_Action -= pseudoChipModel.StartMove;
        pseudoChipView.OnMove_Action -= pseudoChipModel.Move;
        pseudoChipView.OnEndMove_Action -= pseudoChipModel.EndMove;

        pseudoChipModel.OnStartMove -= pseudoChipView.StartMove;
        pseudoChipModel.OnMove -= pseudoChipView.Move;
        pseudoChipModel.OnEndMove -= pseudoChipView.EndMove;
    }

    #region Input

    public event Action<PointerEventData> OnSpawnChip
    {
        add { pseudoChipModel.OnSpawnChip += value; }
        remove { pseudoChipModel.OnSpawnChip -= value; }
    }

    #endregion
}
