using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    
    public int toplamElma = 0; // Toplanan elma say�s�n� saklayacak de�i�ken
    public Text elmaSayisiText; // UI �zerinde toplam elma say�s�n� g�sterecek metin ��esi
    
    private void Start()
    {
        GuncelleElmaSayisi();
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

            Score.sayi++;
            // Burada toplamElma de�i�keninin de�erini g�ncelliyoruz.
            GuncelleElmaSayisi();
            
            // gameObject nesnesini yok et
            Destroy(gameObject);

        }
    }



    public void GuncelleElmaSayisi()
    {
        elmaSayisiText.text = ": " + Score.sayi.ToString();
    }


}