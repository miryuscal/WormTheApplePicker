using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    
    public int toplamElma = 0; // Toplanan elma sayýsýný saklayacak deðiþken
    public Text elmaSayisiText; // UI üzerinde toplam elma sayýsýný gösterecek metin öðesi
    
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
            // Burada toplamElma deðiþkeninin deðerini güncelliyoruz.
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