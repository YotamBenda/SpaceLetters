using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ChestEnding : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Animator chestAnim;

    public void PlayNext()
    {
        chestAnim.SetTrigger("isOpened");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        chestAnim.SetTrigger("isOpened");
    }

}
