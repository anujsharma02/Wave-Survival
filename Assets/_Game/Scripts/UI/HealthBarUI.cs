using UnityEngine;
using UnityEngine.UI;
using WaveSurvival.Managers;

namespace WaveSurvival.UI
{
    /*
 * Displays the player's current health.
 *
 * Responsibilities:
 * - Updates the health slider.
 * - Displays current and maximum health.
 * - Refreshes when the player's health changes.
 */
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;

        private void OnEnable()
        {
            EventManager.OnHealthChanged += UpdateBar;
        }

        private void OnDisable()
        {
            EventManager.OnHealthChanged -= UpdateBar;
        }

        private void UpdateBar(float current, float max)
        {
            slider.value = current / max;
        }
    }
}
