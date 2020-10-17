using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player_boundries : MonoBehaviour
{
    [SerializeField]
    private RectTransform currPos;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenBounds = new Vector2(Screen.width, Screen.height);
        objectWidth = transform.GetComponent<Image>().sprite.bounds.size.x / 2;
        objectHeight = transform.GetComponent<Image>().sprite.bounds.size.y / 2;
        Debug.Log(screenBounds);
    }

    private void LateUpdate()
    {
        Vector2 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * -1);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1);
        
        transform.position = viewPos;
    }
}
