using UnityEngine;

public enum UpgradeType
{
    Damage,
    AttackSpeed,
    MoveSpeed,
    MaxHealth,
    UnlockArrow,
    UnlockLightning
}

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Wave Survival/Upgrade Data")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;

    [TextArea]
    public string description;

    public UpgradeType upgradeType;

    public float value;
}