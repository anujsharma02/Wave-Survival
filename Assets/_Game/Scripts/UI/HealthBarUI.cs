using UnityEngine;
using UnityEngine.UI;

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