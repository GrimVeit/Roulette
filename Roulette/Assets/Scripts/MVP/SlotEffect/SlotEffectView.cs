using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlotEffectView : View
{
    [SerializeField] private List<Transform> contents = new List<Transform>();

    public void VisualSlotGrid(SlotGrid slotGrid, List<SlotValue> slotValues)
    {
        Debug.Log($"Slot values length - {slotValues.Count}");

        for (int i = 0; i < slotGrid.slotPositions.Count; i++)
        {

            int column = slotGrid.slotPositions[i].Col;
            int row = slotValues[column].Index + slotGrid.slotPositions[i].Row;

            Debug.Log($"{column} // {row} //slot values length - {slotValues.Count}");

            Transform element = contents[column].GetChild(row);

            element.DOKill(complete: false);
            DOTween.Kill(element, "ScaleSize");

            element.DOScale(Vector3.one * 1.3f, 0.4f)
                .SetEase(Ease.OutBack)
                .SetId("ScaleSize")
                .OnComplete(() =>
                {
                    element.DOScale(Vector3.one, 0.2f)
                    .SetEase(Ease.InBack)
                    .SetId("ScaleSize");
                });
        }
    }
}
