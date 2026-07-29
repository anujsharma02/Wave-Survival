using TMPro;
using UnityEngine;

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
        timerText.text = Mathf.CeilToInt(seconds).ToString();
    }
}