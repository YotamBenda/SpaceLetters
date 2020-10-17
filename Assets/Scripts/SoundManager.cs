using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [Header("Feedbacks")]
    [SerializeField]
    private AudioClip[] posFeedback;
    [SerializeField]
    private AudioClip[] negFeedback;
    [SerializeField]
    private AudioClip coinCollected;

    private int tempFeedback = 0;

    [Header("Start Tutorial")]
    [SerializeField]
    private AudioClip[] startTutorial;
    [SerializeField]
    private StartCanvas startCanvas;

    [Header("2nd phase")]
    private AudioClip TutPhase2;

    [Header("ClickSound")]
    [SerializeField]
    private AudioClip clickBubble;

    AudioClip PositiveFeedback()
    {
        int randomize = Random.Range(0, posFeedback.Length);
        if (randomize == tempFeedback)
        {
            return PositiveFeedback();
        }
        tempFeedback = randomize;
        return posFeedback[randomize];
    }
    AudioClip NegativeFeedback()
    {
        int randomize = Random.Range(0, negFeedback.Length);
        if (randomize == tempFeedback)
        {
            return NegativeFeedback();
        }
        tempFeedback = randomize;
        return negFeedback[randomize];
    }

    public void PlayFeedback(bool feedback)
    {
        if (feedback)
        {
            audioSource.PlayOneShot(PositiveFeedback());
        }
        else
        {
            audioSource.PlayOneShot(NegativeFeedback());
        }
    }

    public void PlayTutorial(int tutNum)
    {
        //the Invoke makes the "next" button to wait until the audio tutorial is finished.
        startCanvas.Invoke("NextButtonApear", startTutorial[tutNum].length);
        audioSource.PlayOneShot(startTutorial[tutNum]);
    }

    public void PlayCoinCollected()
    {
        audioSource.PlayOneShot(coinCollected);
    }

    public void PlayTutPhase2()
    {
        audioSource.PlayOneShot(TutPhase2);
    }

    public void PlayClickBubble()
    {
        audioSource.PlayOneShot(clickBubble);
    }

    public void StopPlayingClip()
    {
        audioSource.Stop();
    }
}
