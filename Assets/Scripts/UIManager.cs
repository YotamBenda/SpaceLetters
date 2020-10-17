using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Animator mainGoal;
    [SerializeField]
    private Animator starsHolder;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject lettersHolder;
    [SerializeField]
    private GameObject endLetterHolder;
    [SerializeField]
    private GameObject endLetterSlots;

    [SerializeField]
    private Canvas playCanvas;
    [SerializeField]
    private Canvas endCanvas;
    [SerializeField]
    private Canvas pauseCanvas;

    [SerializeField]
    public GameObject soundManager;
    private AudioSource audio;

    [SerializeField]
    private WordsSpawn spawnManager;


    public static int lettersPlaced = 0;

    void Start()
    {
        audio = soundManager.GetComponent<AudioSource>();   
    }

    void Update()
    {
        ActivateEnding();
        ActivateAstro();
    }

    void ActivateEnding()
    {
        if(WordsSpawn.gameOver == true)
        {
            //TODO: change all to animators 
            mainGoal.SetBool("gameEnded", true);
            starsHolder.SetBool("gameEnded", true);
            endLetterHolder.SetActive(true);
            endLetterSlots.SetActive(true);

            player.SetActive(false);
            lettersHolder.SetActive(false);
            
        }
    }

    void ActivateAstro()
    {
        if(lettersPlaced == 4)
        {
            playCanvas.gameObject.SetActive(false);
            endCanvas.gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        lettersPlaced = 0;
        ScoreManager.maxStarsCollected = false;
        WordsSpawn.gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Mute()
    {
        audio.mute = !audio.mute;
    }


    public void Pause()
    {
        pauseCanvas.gameObject.SetActive(true);
        GameObject[] liveLetters = GameObject.FindGameObjectsWithTag("WordImg");
        for(int i =0; i < liveLetters.Length; i++)
        {
            liveLetters[i].GetComponent<Words>().enabled = false;
        }
        spawnManager.gameObject.SetActive(false);

    }

    public void UnPause()
    {
        pauseCanvas.gameObject.SetActive(false);
        GameObject[] liveLetters = GameObject.FindGameObjectsWithTag("WordImg");
        for (int i = 0; i < liveLetters.Length; i++)
        {
            liveLetters[i].GetComponent<Words>().enabled = true;
        }
        spawnManager.gameObject.SetActive(true);
    }
}
