using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events; 

public class UpgradeOptionDisplay : MonoBehaviour
{
	[SerializeField] private Image iconImage;
	[SerializeField] private TextMeshProUGUI titleText;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI descriptionText;
	[SerializeField] private Button selectButton;
	
	public void Setup(UpgradeData data)
	{
		int currentLevel = PlayerStats.Instance.GetLevel(data.upgradeType);

		if (data.icon != null)
		{
			iconImage.sprite = data.icon;
			iconImage.enabled = true;
		}
		else
		{
			iconImage.enabled = false;
		}

		titleText.text = data.skillName;

		if (currentLevel == 0)
		{
			levelText.text = "NEW!";
		}
		else
		{
			levelText.text = $"Lv. {currentLevel + 1}";
		}
		descriptionText.text = data.levels[currentLevel].levelDescription;
	}

	public void SetButtonAction(UnityAction action)
	{
		selectButton.onClick.RemoveAllListeners();
		selectButton.onClick.AddListener(action);
	}
}