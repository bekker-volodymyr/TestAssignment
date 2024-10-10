using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillImage;

    public void SetValue(float current, float max)
    {
        // TODO: ADD DOTWEEN ANIMATIONS
        _fillImage.fillAmount = current / max;
    }
}
