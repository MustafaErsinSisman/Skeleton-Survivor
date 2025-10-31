using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    public const int MAX_LEVEL = 5;
    public Dictionary<UpgradeType, int> upgradeLevels;

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
        InitializeLevels();
    }

    private void InitializeLevels()
    {
        upgradeLevels = new Dictionary<UpgradeType, int>();
        foreach (UpgradeType type in Enum.GetValues(typeof(UpgradeType)))
        {
            upgradeLevels.Add(type, 0);
        }
    }

    public int GetLevel(UpgradeType type)
    {
        if (upgradeLevels.ContainsKey(type))
        {
            return upgradeLevels[type];
        }
        return 0;
    }

    public void UpgradeLevel(UpgradeType type)
    {
        if (upgradeLevels.ContainsKey(type))
        {
            upgradeLevels[type]++;
            Debug.Log($"UPGRADE: {type} seviyesi {upgradeLevels[type]}'a yükseldi.");
        }
    }
}