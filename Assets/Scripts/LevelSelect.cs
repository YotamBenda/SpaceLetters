using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private Button[] levels;

    public void SelectLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
