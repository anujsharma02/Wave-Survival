using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private TMP_Text title;

    private UpgradeData data;

    private UpgradeManager manager;

    public void Setup(UpgradeData upgrade, UpgradeManager upgradeManager)
    {
        data = upgrade;
        manager = upgradeManager;

        title.text = upgrade.upgradeName;
    }

    public void SelectUpgrade()
    {
        ApplyUpgrade();

        manager.ClosePanel();
    }

    private void ApplyUpgrade()
    {
        PlayerStats stats = GameManager.Instance.PlayerStats;

        if (stats == null)
        {
            Debug.LogError("PlayerStats not found in GameManager.");
            return;
        }

        switch (data.upgradeType)
        {
            case UpgradeType.Damage:
                stats.DamageMultiplier += data.value;
                break;

            case UpgradeType.AttackSpeed:
                stats.AttackSpeedMultiplier += data.value;
                break;

            case UpgradeType.MoveSpeed:
                stats.MoveSpeedMultiplier += data.value;
                break;

            case UpgradeType.MaxHealth:
                stats.MaxHealth += (int)data.value;
                break;
        }
    }
}