using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChestEnding : MonoBehaviour
{
    [SerializeField]
    private Animator chestAnim;

    public void PlayNext()
    {
        chestAnim.SetTrigger("isOpened");
    }

    private void OnMouseDown()
    {
        PlayNext();
    }


}
