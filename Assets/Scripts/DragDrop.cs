using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTrans;

    private Sprite collSprite;
    private Animator collAnim;
    [SerializeField]
    ScoreManager scoreManager;
    [SerializeField]
    WordsSpawn wordsSpawner;

    [Range(-50,-605)]
    private float Y_RANGE;

    [Range(330,-330)]
    private float X_RANGE;

    private float Y_MIN = -605f;
    private float Y_MAX = -50f;
    private float X_MIN = -330f;
    private float X_MAX = 330f;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "WordImg")
        {
            collSprite = collision.GetComponent<Image>().sprite;
            collAnim = collision.GetComponent<Animator>();

            if (scoreManager.CheckIfCorrect(collSprite) == true)
            {
                Destroy(collision.gameObject);
                wordsSpawner.CheckGameOver();
            }
            else
            {
                collAnim.SetTrigger("Incorrect");
            }
        }
        
    }
    
}
