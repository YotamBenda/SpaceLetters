using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChestEnding : MonoBehaviour
{
    [SerializeField]
    private Animator chestAnim;
    [SerializeField]
    private Animator mainGoalAnim;

    public void PlayNext()
    {
        mainGoalAnim.SetTrigger("isOpened");
    }

}
