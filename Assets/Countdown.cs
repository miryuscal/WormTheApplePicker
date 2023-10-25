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
    private float countdownTime;
    public int score = Score.sayi;
    public GameObject pauseMenuPanel;
    public Text scoreText;
    public GameObject firstSelected;
    public List<GameObject> buttons;

    void Start()
    {
        Time.timeScale = 1f;
        countdownTime = initialCountdownTime;
        UpdateCountdownText();
    }

    void Update()
    {
    
        
        if (countdownTime > 0)
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
        }
    }

    void UpdateCountdownText()
    {
        countdownText.text = ": " + Mathf.Ceil(countdownTime).ToString();
    }


    public void RestartGame()
    {
        Time.timeScale = 1f; // Zamaný tekrar baþlat
        Score.sayi = 0;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
