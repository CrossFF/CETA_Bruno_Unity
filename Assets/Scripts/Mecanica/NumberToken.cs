using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberToken : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int value = 1;

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private Vector2 startPos;
    private bool copy = false;

    public bool IsCopy { get { return copy; } }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!copy)
        {
            rectTransform.anchoredPosition = startPos;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
        }
        else
        {
            GameObject.Find("Number Holder").GetComponent<NumberHolder>().RemoveNumberToken(this);
            Destroy(gameObject);
        }
    }

    public void IsACopy()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        copy = true;
    }
}
