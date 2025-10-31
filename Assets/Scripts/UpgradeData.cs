using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSkill", menuName = "SkeletonSurvivor/NewSkillData")]
public class UpgradeData : ScriptableObject
{
	[Header("Base Info")]
	public UpgradeType upgradeType;
	public string skillName;
	public Sprite icon;

	[System.Serializable]
	public struct LevelInfo
	{
		public string levelDescription;
		// Buraya gelecekte hasar, hız, alan gibi
      		// doğrudan sayısal verileri de ekleyebiliriz.
        	// public float damageIncrease;
       		// public float radiusIncrease;
	}

	[Header("Level Descriptions")]
	public LevelInfo[] levels;
}