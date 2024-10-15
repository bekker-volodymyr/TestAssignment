using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private RectTransform _healthBarRectTransform;

    private float _animationDuration = 0.2f;
    private float _shakeDuration = 0.2f;
    private float _shakeStrength = 0.5f;
    private int _shakeVibrato = 10;

    public void SetValue(float current, float max)
    {
        float targetFillAmount = current / max;

        _fillImage.DOFillAmount(targetFillAmount, _animationDuration).SetEase(Ease.OutSine);

        _healthBarRectTransform.DOShakeAnchorPos(_shakeDuration, _shakeStrength, _shakeVibrato);
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
