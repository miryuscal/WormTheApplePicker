using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collect : MonoBehaviour
{
    
    public int toplamElma = 0; // Toplanan elma sayýsýný saklayacak deðiþken
    public Text elmaSayisiText; // UI üzerinde toplam elma sayýsýný gösterecek metin öðesi
    public TMP_Text informative;
    public Camera mainCamera;
    public GameObject player;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        GuncelleElmaSayisi();
        informative.text = "+0.2 sec";
    }


    private void Update()
    {
        GuncelleElmaSayisi();
    }


    public Collider ustCollider;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider == ustCollider && collision.gameObject.CompareTag("Player")) // Kurtun etiketini kullanabilirsiniz.
        {
            audioSource.PlayOneShot(audioClip);
            Score.sayi++;
            // Burada toplamElma deðiþkeninin deðerini güncelliyoruz.
            GuncelleElmaSayisi();

            
            informative.transform.position = player.transform.position + new Vector3(0, 20, 0);
            Vector3 position = informative.transform.position;
            position = mainCamera.WorldToScreenPoint(position) + new Vector3(0, -1960, 0);
            informative.transform.position = position;
            StartCoroutine(ShowMessage());
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


    public void GuncelleElmaSayisi()
    {
        elmaSayisiText.text = ": " + Score.sayi.ToString();
    }


}