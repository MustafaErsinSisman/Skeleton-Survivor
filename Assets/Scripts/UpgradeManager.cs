using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    [Header("Upgrade Database")]
    [SerializeField] private List<UpgradeData> weaponUpgrades;
    [SerializeField] private List<UpgradeData> passiveUpgrades;

    private List<UpgradeData> allUpgrades;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        allUpgrades = new List<UpgradeData>();
        allUpgrades.AddRange(weaponUpgrades);
        allUpgrades.AddRange(passiveUpgrades);
    }

    public List<UpgradeData> GetRandomUpgrades(int count)
    {
        List<UpgradeData> possibleUpgrades = new List<UpgradeData>();

        bool hasAnyWeapon = false;
        foreach (UpgradeData weapon in weaponUpgrades)
        {
            if (PlayerStats.Instance.GetLevel(weapon.upgradeType) > 0)
            {
                hasAnyWeapon = true;
                break;
            }
        }

        if (!hasAnyWeapon)
        {
            possibleUpgrades.AddRange(weaponUpgrades);
        }
        else
        {
            foreach (UpgradeData upgrade in allUpgrades)
            {
                int currentLevel = PlayerStats.Instance.GetLevel(upgrade.upgradeType);

                if (currentLevel < PlayerStats.MAX_LEVEL)
                {
                    possibleUpgrades.Add(upgrade);
                }
            }
        }

        List<UpgradeData> chosenUpgrades = new List<UpgradeData>();

        int numToChoose = Mathf.Min(count, possibleUpgrades.Count);

        for (int i = 0; i < numToChoose; i++)
        {
            int randomIndex = Random.Range(0, possibleUpgrades.Count);
            chosenUpgrades.Add(possibleUpgrades[randomIndex]);
            possibleUpgrades.RemoveAt(randomIndex);
        }
        return chosenUpgrades;
    }
}