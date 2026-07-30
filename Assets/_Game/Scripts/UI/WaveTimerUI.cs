using TMPro;
using UnityEngine;
using WaveSurvival.Managers;

namespace WaveSurvival.UI
{
    /*
 * Displays current wave information.
 *
 * Responsibilities:
 * - Shows countdown before the next wave.
 */
    public class WaveTimerUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text timerText;

        private void OnEnable()
        {
            EventManager.OnWaveTimerChanged += UpdateTimer;
        }

        private void OnDisable()
        {
            EventManager.OnWaveTimerChanged -= UpdateTimer;
        }

        private void UpdateTimer(float seconds)
        {
            timerText.text = "Wave Timer: " + Mathf.CeilToInt(seconds).ToString();
        }
    }
}