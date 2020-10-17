using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseCanvas : MonoBehaviour
{

    public void ContinueGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Settings()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChooseLevel()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
}
