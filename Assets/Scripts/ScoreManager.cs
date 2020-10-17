using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] correctSprites;

    [SerializeField]
    private GameObject[] letters;
    private int letterToAnim;
    [SerializeField]
    private int[] timesCollected;

    [SerializeField] Animator[] starAnim;

    private int currStar = 0;
    private int maxStars = 3;
    public static bool maxStarsCollected = false;

    [Header("Sound")]
    [SerializeField]
    private SoundManager soundManager;

    void Start()
    {
        timesCollected = new int[letters.Length];
        for(int i = letters.Length; i<letters.Length; i++)
        {
            timesCollected[i] = 0;
        }
    }


    void Update()
    {
        
    }
    
    public bool CheckIfCorrect(Sprite sprite)
    {
        letterToAnim = -1;
        for(int i = 0; i< letters.Length; i++)
        {
            if (sprite.name == correctSprites[i].name)
            {
                letterToAnim = i;
                timesCollected[i]++;
                var starCheck = CheckCollectStar();
                if (starCheck)
                {
                    SpawnStar(starAnim[currStar]);
                    currStar++;
                    soundManager.PlayCoinCollected();
                    if(currStar == maxStars)
                    {
                        maxStarsCollected = true;
                    }
                }
            }
                
        }
        if(letterToAnim > -1)
        {
            AnimateLetter(letterToAnim);
            soundManager.PlayFeedback(true);
            return true;
        }
        else
        {
            soundManager.PlayFeedback(false);
            return false;
        }
    }

    private void AnimateLetter(int num)
    {
        var m_letter = letters[num].GetComponent<Animator>();
        m_letter.SetTrigger("isCorrect");
    }

    private void SpawnStar(Animator anim)
    {
        anim.SetBool("starEarned", true);
    }

    private bool CheckCollectStar()
    {
        bool isEarned = false;
        for(int i =0; i<timesCollected.Length; i++)
        {
            if(timesCollected[i] < currStar + 1)
            {
                return false;
            }
            else
            {
                isEarned = true;
            }
        }
        return isEarned;
    }
}
