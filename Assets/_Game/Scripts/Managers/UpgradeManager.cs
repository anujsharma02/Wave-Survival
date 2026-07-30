using UnityEngine;
using TMPro;

namespace WaveSurvival.Managers
{
    /*
 * Controls player upgrade system.
 *
 * Responsibilities:
 * - Shows upgrade choices.
 * - Applies selected upgrades.
 * - Improves player abilities.
 * - Manages upgrade progression.
 */
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField] private GameObject upgradePanel;
        [SerializeField] private TMP_Text levelText;

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
            levelText.text = "Level: " + GameManager.Instance.LevelSystem.Level;
            upgradePanel.SetActive(false);

            Time.timeScale = 1f;
        }
    }
}