using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    public int auraLevel = 0;
    public int swordLevel = 0;
    public int arrowLevel = 0;
    public int meteorLevel = 0;

    public int magnetLevel = 0;
    public int radiusLevel = 0;
    public int projectileCountLevel = 0;
    public int weaponSpeedLevel = 0;

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
    }
}