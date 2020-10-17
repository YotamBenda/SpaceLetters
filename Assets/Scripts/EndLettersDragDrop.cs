using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndLettersDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private SoundManager soundManager;

    private RectTransform rectTrans;
    private CanvasGroup canvasGroup;

    private bool isMoveable = true;


    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        soundManager.PlayClickBubble();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isMoveable)
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        soundManager.PlayClickBubble();
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    
    public void CheckIfCorretSlot(bool isCorrect)
    {
        if (isCorrect)
        {
            isMoveable = false;
        }
    }
}
