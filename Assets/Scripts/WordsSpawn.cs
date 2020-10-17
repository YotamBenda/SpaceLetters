using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class WordsSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject wordImg;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private Sprite[] spritesToSpawn;
    
    [SerializeField]
    private GameObject[] allWords;

    private int randomSpawnPoint =0;
    private int lastSpawnPoint = 0;
    [SerializeField]
    private int waveNum = 0;

    [SerializeField]
    private float timeBetweenWaves = 3f;
    private float countDown = 3f;


    public static bool gameOver = false;

    private void Start()
    {

    }
    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWord());
            countDown = timeBetweenWaves;
        }

        if (waveNum < spritesToSpawn.Length)
        {
            countDown -= Time.deltaTime;
            countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        }      
    }
    

    IEnumerator SpawnWord()
    {
        //Setting the spawn point
        randomSpawnPoint = GenerateSpawnPoint();

        //Setting the correct Image
        wordImg.GetComponent<Image>().sprite = spritesToSpawn[waveNum];

        //instantiating into the game
        var createImg = Instantiate(wordImg, spawnPoints[randomSpawnPoint].position, Quaternion.identity, canvas.transform) as GameObject;

        if(waveNum < spritesToSpawn.Length)
        {
            waveNum++;
        }

        yield return new WaitForSeconds(3f);
    }

    public bool CheckGameOver()
    {
        bool hasEnded = false;
        if (waveNum < spritesToSpawn.Length)
        {
            hasEnded = false;
            return hasEnded;
        }
        else
        {
            //***TODO: Something is bugged here, for some reason, the 1st object in this array is missing. therefor "allWords.Length <= 1" - instead of "null"
            allWords = GameObject.FindGameObjectsWithTag("WordImg");

            //This checks if maximum stars has been collected. if so, deletes all the remaining words on screen and activates gameOver.
            if (ScoreManager.maxStarsCollected)
            {
                hasEnded = true;
                gameOver = true;
                for(int i = 0; i< allWords.Length; i++)
                {
                    allWords[i].SetActive(false);
                }
            }

            //If maximum stars hasnt been collected yet, checks if there are no more words on screen, if so, activates gameOver.
            for (int i = 0; i < allWords.Length; i++)
            {
                if (allWords.Length <= 1)
                {
                    hasEnded = true;
                    gameOver = true;
                }
            }
        }
        return hasEnded;
        
    }

    private int GenerateSpawnPoint()
    {
        int randomize = Random.Range(0, spawnPoints.Length);
        if (randomize == randomSpawnPoint)
        {
           return GenerateSpawnPoint();
        }
        return randomize;
    }
}
