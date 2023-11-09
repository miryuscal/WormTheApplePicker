using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Market : MonoBehaviour
{
    public TMP_Text marketAppleNumber;
    int totalAppless; 

    void Start()
    {
        totalAppless = PlayerPrefs.GetInt("totalApples");
        marketAppleNumber.text = ": " + totalAppless.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToLevel()
    {
        Score.sayi = 0;
        SceneManager.LoadScene("Level");
    }
}
