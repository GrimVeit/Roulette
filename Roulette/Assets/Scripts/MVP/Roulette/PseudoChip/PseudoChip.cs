using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PseudoChip : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<PseudoChip> OnGrabbing;

    public event Action OnStartMove;
    public event Action<PointerEventData> OnEndMove;
    public event Action<Vector2> OnMove;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Tween moveTween;

    public void Initialize()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Dispose()
    {

    }

    #region Methods

    public void Teleport(Vector3 vector)
    {
        rectTransform.localPosition = vector;
    }

    public void StartMove()
    {
        if (moveTween != null)
            moveTween.Kill();

        canvasGroup.blocksRaycasts = false;
    }

    public void EndMove()
    {
        canvasGroup.blocksRaycasts = true;
    }


    public void Move(Vector2 vector)
    {
        rectTransform.anchoredPosition += vector;
    }

    #endregion

    #region Input

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnGrabbing?.Invoke(this);
        OnStartMove?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnMove?.Invoke(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndMove?.Invoke(eventData);
    }

    #endregion
}
