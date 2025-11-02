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
		if (upgradeType == UpgradeType.Aura) { ApplyAuraUpgrade(); }
		else if (upgradeType == UpgradeType.Sword) { ApplySwordUpgrade(); }
		else if (upgradeType == UpgradeType.Arrow) { ApplyArrowUpgrade(); }
		else if (upgradeType == UpgradeType.Meteor) { ApplyMeteorUpgrade(); }
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

	private void ApplySwordUpgrade()
	{
		int currentSwordLevel = PlayerStats.Instance.GetLevel(UpgradeType.Sword);

		if (currentSwordLevel == 1) // Eğer seviye 1 ise (YENİ ALINDI)
		{
			swordWeaponObject.SetActive(true);
		}
		else
		{
			// (Seviye 2, 3, 4, 5 için 'else if' blokları buraya gelecek)
			// Örn: Seviye 2'de 2. bir kılıç yaratır (açısı 180 derece farklı)
			// veya hızı artar (GetComponent<SwordWeapon>().speed *= 1.2f)
		}
	}

	private void ApplyArrowUpgrade()
	{
		int currentArrowLevel = PlayerStats.Instance.GetLevel(UpgradeType.Arrow);

		if (currentArrowLevel == 1)
		{
			arrowWeaponObject.SetActive(true);
		}
		else
		{
			// Seviye 2'de: Ok sayısını artır (ProjectileCountLevel'a bağlanabilir)
			// Seviye 3'de: Atış hızını artır (GetComponent<ArrowController>().fireRate *= 0.8f)
		}
	}
	
	private void ApplyMeteorUpgrade()
	{
		int currentMeteorLevel = PlayerStats.Instance.GetLevel(UpgradeType.Meteor);

		if (currentMeteorLevel == 1)
		{
			meteorWeaponObject.SetActive(true);
		}
		else
		{
			// Seviye 2'de: Düşen meteor sayısı artar (birden fazla Instantiate)
			// Seviye 3'de: Atış hızı artar (fireRate)
		}
	}
}