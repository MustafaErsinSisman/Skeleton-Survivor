using UnityEngine;
using System.Collections.Generic;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] private UpgradeOptionDisplay optionDisplay1;
    [SerializeField] private UpgradeOptionDisplay optionDisplay2;
    [SerializeField] private UpgradeOptionDisplay optionDisplay3;

    private List<UpgradeData> currentOptions;
    public void ShowOptions()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;

        currentOptions = UpgradeManager.Instance.GetRandomUpgrades(3);

        if (currentOptions.Count > 0)
        {
            optionDisplay1.gameObject.SetActive(true);
            optionDisplay1.Setup(currentOptions[0]);
            optionDisplay1.SetButtonAction(() => { SelectOption(0); });
        }
        else
        {
            optionDisplay1.gameObject.SetActive(false);
        }

        if (currentOptions.Count > 1)
        {
            optionDisplay2.gameObject.SetActive(true);
            optionDisplay2.Setup(currentOptions[1]);
            optionDisplay2.SetButtonAction(() => { SelectOption(1); });
        }
        else
        {
            optionDisplay2.gameObject.SetActive(false);
        }

        if (currentOptions.Count > 2)
        {
            optionDisplay3.gameObject.SetActive(true);
            optionDisplay3.Setup(currentOptions[2]);
            optionDisplay3.SetButtonAction(() => { SelectOption(2); });
        }
        else
        {
            optionDisplay3.gameObject.SetActive(false);
        }
    }
    private void SelectOption(int optionIndex)
    {
        UpgradeData chosenUpgrade = currentOptions[optionIndex];
	PlayerStats.Instance.UpgradeLevel(chosenUpgrade.upgradeType);
	WeaponController.Instance.ApplyUpgrade(chosenUpgrade.upgradeType);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        
        Debug.Log($"Seçenek {chosenUpgrade.skillName} ({chosenUpgrade.upgradeType}) seçildi.");
    }
}