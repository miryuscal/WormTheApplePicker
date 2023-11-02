using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class Green : MonoBehaviour
{
    public Countdown objects;
    public Collider ustCollider;
    public TMP_Text informative;
    public GameObject player;
    public Camera mainCamera;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        informative.text = "+1 sec";
    }
 
 
 
 
    private void OnCollisionEnter(Collision collision)
    {
 
        if (collision.collider == ustCollider && collision.gameObject.CompareTag("Player")) // Kurtun etiketini kullanabilirsiniz.
        {
            audioSource.PlayOneShot(audioClip);
            informative.transform.position = player.transform.position + new Vector3(0, 20, 0);
            Vector3 position = informative.transform.position;
            position = mainCamera.WorldToScreenPoint(position) + new Vector3(0, -1960, 0);
            informative.transform.position = position;
            StartCoroutine(ShowMessage());
            Score.sayi++;
            objects.GetComponent<Countdown>().countdownTime += 1;
            gameObject.transform.position += new Vector3(0, 0, -9f); 
        }
    }
 
   
 
    private IEnumerator ShowMessage()
    {
        informative.gameObject.SetActive(true);
        

        yield return new WaitForSecondsRealtime(1);
        
        informative.gameObject.SetActive(false);
        Debug.Log("Zaman gecti");
    }
 
 
 
}
 