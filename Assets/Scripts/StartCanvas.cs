using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    [SerializeField]
    private Sprite[] explanations;
    [SerializeField]
    private Image currExplainImage;
    private int currExplain = 0;
    [SerializeField]
    private Button nextButton;

    [Header("References")]
    [SerializeField]
    private Canvas playCanvas;
    [SerializeField]
    private Animator explainAnim;
    [SerializeField]
    private GameObject spawnManager;
    [SerializeField]
    private SoundManager soundManager;


    private void Start()
    {
        soundManager.PlayTutorial(currExplain);
    }
    public void PlayNext()
    {
        if (currExplain == explanations.Length - 1)
        {
            StartSpawning();
            return;
        }
        currExplain++;
        //explainAnim.SetTrigger("ApearAgain"); - currently not working - TODO
        soundManager.PlayTutorial(currExplain);
        currExplainImage.sprite = explanations[currExplain];
        nextButton.gameObject.SetActive(false);
    }

    public void StartSpawning()
    {
        this.gameObject.SetActive(false);
        playCanvas.gameObject.SetActive(true);
        spawnManager.gameObject.SetActive(true);
    }

    public void NextButtonApear()
    {
        nextButton.gameObject.SetActive(true);
    }
}
