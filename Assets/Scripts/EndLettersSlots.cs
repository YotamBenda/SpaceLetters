using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndLettersSlots : MonoBehaviour, IDropHandler
{
    private RectTransform rectTrans;
    [SerializeField]
    private SoundManager soundManager;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform letterRect = eventData.pointerDrag.GetComponent<RectTransform>();

        if (eventData.pointerDrag.name == this.name)
        {
            letterRect.anchoredPosition = rectTrans.anchoredPosition;
            eventData.pointerDrag.GetComponent<EndLettersDragDrop>().CheckIfCorretSlot(true);
            Debug.Log("This is the correct slot!");
            UIManager.lettersPlaced++;
            soundManager.PlayFeedback(true);
        }
        else
        {
            Debug.Log("Not the correct spot!");
            soundManager.PlayFeedback(false);
        }
    }
}
