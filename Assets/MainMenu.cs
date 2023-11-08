using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        Application.targetFrameRate = -1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Market()
    {
        SceneManager.LoadSceneAsync(2);
    }

}
