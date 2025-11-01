using UnityEngine;
public class WeaponController : MonoBehaviour
{
	public static WeaponController Instance { get; private set; }

	[Header("Weapon GameObjects References")]
	[SerializeField] private GameObject arrowWeaponObject;
	[SerializeField] private GameObject auraWeaponObject;
	[SerializeField] private GameObject swordWeaponObject;
	[SerializeField] private GameObject meteorWeaponObject;
	

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

	public void ApplyUpgrade(UpgradeType upgradeType)
	{
		if (upgradeType == UpgradeType.Aura)
		{
			ApplyAuraUpgrade();
		}
		// else if (upgradeType == UpgradeType.Sword)
		// {
		//	 ApplySwordUpgrade();
		// }
	}

	private void ApplyAuraUpgrade()
	{
		int currentAuraLevel = PlayerStats.Instance.GetLevel(UpgradeType.Aura);

		if (currentAuraLevel == 1)
		{
			auraWeaponObject.SetActive(true);
		}
		else if (currentAuraLevel == 2)
		{
			Debug.Log("Aura alanı genişletiliyor (Seviye 2)...");
			// Buraya gelecekte 'auraWeaponObject.transform.localScale *= 1.2f;'
			// veya 'auraWeaponObject.GetComponent<WeaponAura>().radius *= 1.2f;'
			// gibi gerçek kodlar gelecek.
		}
		else if (currentAuraLevel == 3)
		{
			// Senin kuralın: "Hasarı artar"
			Debug.Log("Aura hasarı artırılıyor (Seviye 3)...");
			// Buraya gelecekte 'auraWeaponObject.GetComponent<WeaponAura>().damage *= 1.5f;'
			// gibi gerçek kodlar gelecek.
		}
		// (Diğer seviyeler (4 ve 5) için else if... blokları buraya eklenecek)
	}
}