using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelUpUI levelUpUI;

    void Start()
    { 
        levelUpUI.ShowOptions();
    }
}