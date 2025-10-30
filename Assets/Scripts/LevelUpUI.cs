using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] private UpgradeOptionDisplay optionDisplay1;
    [SerializeField] private UpgradeOptionDisplay optionDisplay2;
    [SerializeField] private UpgradeOptionDisplay optionDisplay3;

    public void ShowOptions()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;

        // --- GELECEKTEKİ GÖREV ---
        // 1. PlayerStats'tan 3 rastgele yetenek seç (örn: Aura, Magnet, Sword)
        // 2. Kartları bu bilgilere göre ayarla
        //    optionDisplay1.Setup("Aura", "Level 2", "Alan genişler", auraIcon);
        //    optionDisplay2.Setup("Magnet", "Level 1", "Yeni yetenek!", magnetIcon);
        //    optionDisplay3.Setup("Sword", "Level 4", "Hasar artar", swordIcon);
        // (Şimdilik bu 'Setup' fonksiyonunu yazmadık, o yüzden kartlar boş görünecek)

        optionDisplay1.SetButtonAction(() => { SelectOption(1); });
        optionDisplay2.SetButtonAction(() => { SelectOption(2); });
        optionDisplay3.SetButtonAction(() => { SelectOption(3); });
    }

    private void SelectOption(int optionID)
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);

        // --- GELECEKTEKİ GÖREV ---
        // if (optionID == 1) { PlayerStats.Instance.AuraSeviyesiniArtir(); }
        // else if (optionID == 2) { PlayerStats.Instance.MagnetSeviyesiniArtir(); }
        // ...
        
        Debug.Log($"Seçenek {optionID} seçildi ve oyun devam ediyor.");
    }
}