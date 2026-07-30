using UnityEngine;
using UnityEngine.UI;
using WaveSurvival.Managers;

namespace WaveSurvival.UI
{
    /*
 * Displays the player's experience progress.
 *
 * Responsibilities:
 * - Updates the experience bar.
 * - Shows current XP progress.
 * - Refreshes after collecting XP.
 * - Resets after leveling up.
 */
    public class XPBarUI : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;

        private void OnEnable()
        {
            EventManager.OnXPChanged += UpdateXP;
        }

        private void OnDisable()
        {
            EventManager.OnXPChanged -= UpdateXP;
        }

        private void UpdateXP(float current, float max)
        {
            slider.value = current / max;
        }
    }
}