using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsKillZone : MonoBehaviour
{
    [SerializeField]
    WordsSpawn wordsSpawn;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        wordsSpawn.CheckGameOver();
    }
    
}
