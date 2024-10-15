using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

namespace TestAssignment.UI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textTMP;

        private const string _startText = "TAP TO START";
        private const string _winText = "YOU WON!";
        private const string _looseText = "YOU LOST!";

        private float _fadeDuration = 0.7f;

        private float _scaleMin = 0.8f;
        private float _scaleMax = 1.2f;
        private float _pulseDuration = 0.5f;

        public event Action TapEvent;

        public void SetStartingState()
        {
            _textTMP.text = _startText;
            _textTMP.color = Color.white;

            DoAppear();
        }

        internal void SetFinishedState(bool isWin)
        {
            _textTMP.text = isWin ? _winText : _looseText;
            _textTMP.color = isWin ? Color.green : Color.red;

            DoAppear();
        }

        void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                TapEvent?.Invoke();
            }
        }

        public void DoAppear()
        {
            _textTMP.alpha = 0f;
            _textTMP.transform.localScale = Vector3.one;
            _textTMP.DOFade(1f, _fadeDuration)
                .SetUpdate(true)
                .SetEase(Ease.OutSine)
                .OnComplete(() =>
                {
                    _textTMP.transform.DOScale(_scaleMax, _pulseDuration)
                    .SetEase(Ease.InOutSine)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetUpdate(true);
                }
        );
        }
    }
}
