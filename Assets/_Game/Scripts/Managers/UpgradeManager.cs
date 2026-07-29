using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradePanel;

    private void OnEnable()
    {
        EventManager.OnLevelChanged += OpenUpgradePanel;
    }

    private void OnDisable()
    {
        EventManager.OnLevelChanged -= OpenUpgradePanel;
    }

    private void OpenUpgradePanel(int level)
    {
        Time.timeScale = 0f;

        upgradePanel.SetActive(true);
    }

    public void ClosePanel()
    {
        upgradePanel.SetActive(false);

        Time.timeScale = 1f;
    }
}