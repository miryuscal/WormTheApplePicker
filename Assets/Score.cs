using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] public static int totalApples;
    [SerializeField] public static int sayi;
    // Start is called before the first frame update
    void Start()
    {
        totalApples = PlayerPrefs.GetInt("totalApples");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetSayi()
    {
        return sayi;
    }

    
}
