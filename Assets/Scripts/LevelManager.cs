using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance { get; private set; }

	[Header("Level Settings")]
	[SerializeField] private int xpToNextLevel_Start = 10;
	[SerializeField] private float xpMultiplier = 1.5f;

	[Header("UI References")]
	[SerializeField] private LevelUpUI levelUpUI;

	[Header("Current Stiuation")]
	public int currentLevel = 1;
	public int currentXP = 0;
	public int xpToNextLevel;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			// DontDestroyOnLoad(gameObject); // (Gelecekte sahneler arası geçiş yaparsak diye aklımızda bulunsun)
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		xpToNextLevel = xpToNextLevel_Start;
		Debug.Log("Game started. Level 1. XP to Level 2: " + xpToNextLevel);
	}

	// Dışarıdan (XP taşından) çağrılacak fonksiyon
	public void AddXP(int amount)
	{
		currentXP += amount;
		Debug.Log("XP alındı: +" + amount + " | Toplam: " + currentXP + " / " + xpToNextLevel);

		while (currentXP >= xpToNextLevel)
		{
			currentLevel++;
			currentXP = currentXP - xpToNextLevel;
			xpToNextLevel = (int)(xpToNextLevel * xpMultiplier);
			levelUpUI.ShowOptions();
			Debug.LogWarning("LEVEL UP! Yeni Seviye: " + currentLevel + " | Bir sonraki seviye için gereken XP: " + xpToNextLevel);
		}
	}
}