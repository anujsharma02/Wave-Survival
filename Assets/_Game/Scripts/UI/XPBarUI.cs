using UnityEngine;
using UnityEngine.UI;

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