using UnityEngine;
using UnityEngine.SceneManagement; // Sahne değiştirmek için bu satır MUTLAKA gerekli!

public class MainMenuManager : MonoBehaviour
{
    // Buraya oyununun sahne adını yazacaksın.
    // Tırnak işaretlerinin arasını değiştir.
    public string oyunSahnesiAdi = "SampleScene"; 

    // Bu fonksiyon, butona tıkladığımızda çalışacak
    public void OyunuBaslat()
    {
        // Belirttiğin isimdeki sahneyi yükler
        SceneManager.LoadScene(oyunSahnesiAdi);
    }
}