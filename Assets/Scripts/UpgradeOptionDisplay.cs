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
    
    public void SetButtonAction(UnityAction action)
    {
        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(action);
    }
}