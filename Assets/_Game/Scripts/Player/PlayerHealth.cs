using UnityEngine;
using WaveSurvival.Managers;
using WaveSurvival.UI;

namespace WaveSurvival.Player
{
    /*
 * Handles the player's health system.
 *
 * Responsibilities:
 * - Stores current and maximum health.
 * - Applies damage and healing.
 * - Detects player death.
 * - Notifies other systems when health changes.
 */
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        private float maxHealth = 100;

        private float currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;

            EventManager.OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            currentHealth = Mathf.Max(currentHealth, 0);

            EventManager.OnHealthChanged?.Invoke(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            float survivalTime = GameManager.Instance.GameTime;
            int level = GameManager.Instance.LevelSystem.Level;
            SaveManager.SaveGame(level, survivalTime);
            PauseMenuUI.Instance.ShowGameOver(survivalTime, level);
        }
    }
}