using System;
using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTMP;

    private string _startText = "TAP TO START";
    private string _winText = "YOU WON!";
    private string _looseText = "YOU LOST!";

    public event Action TapEvent;

    public void SetStartingState()
    {
        _textTMP.text = _startText;
        _textTMP.color = Color.white;
    }

    internal void SetFinishedState(bool isWin)
    {
        _textTMP.text = isWin ? _winText : _looseText;
        _textTMP.color = isWin ? Color.green : Color.red;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TapEvent?.Invoke();
        }
    }
}
