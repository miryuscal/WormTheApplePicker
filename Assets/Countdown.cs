using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Countdown : MonoBehaviour
{
    public Text countdownText;
    public float initialCountdownTime = 30.0f; // Baþlangýç geri sayým süresi
    public float countdownTime;
    public int score = Score.sayi;
    public GameObject pauseMenuPanel;
    public Text scoreText;
    public GameObject firstSelected;
    public List<GameObject> buttons;
    public Collider Example;
    Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt("totalApples", Score.totalApples);
        Time.timeScale = 1f;
        countdownTime = initialCountdownTime;
        UpdateCountdownText();
    }


    void Update()
    {
        PlayerPrefs.SetInt("totalApples", Score.totalApples);

        if (countdownTime > 0 && scene.name == "Level")
        {
            countdownTime -= Time.deltaTime;
            UpdateCountdownText();
            if(score != Score.sayi)
            {
                countdownTime += 0.5f;
                score = Score.sayi;
            }
        }

        
        else
        {
            // Oyunu durdur veya oyun sonlandýr.
            Time.timeScale = 0f; // Oyunu durdur
            pauseMenuPanel.SetActive(true);
            scoreText.text = "=  " + score.ToString();
            PlayerPrefs.Save();
        }
    }

    public void UpdateCountdownText()
    {
        countdownText.text = ": " + Mathf.Ceil(countdownTime).ToString();
    }


    public void RestartGame()
    {
        Time.timeScale = 1f; // Zamaný tekrar baþlat
        SceneManager.LoadScene(1);
        Score.sayi = 0;
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("totalApples", Score.totalApples);
        PlayerPrefs.Save();
    }
    /*
    public float GetTime()
    {
        return countdownTime;
    }

    public void SetTime(float temp)
    {
        countdownTime += temp;
        UpdateCountdownText();
    }
    */
}
