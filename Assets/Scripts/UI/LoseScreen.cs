using System;
using TMPro;
using UnityEngine;
using Zenject;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private IFruitScoreSystem _scoreSystem;

    [Inject]
    public void Construct(IFruitScoreSystem scoreSystem)
    {
        _scoreSystem = scoreSystem;        
        _panel.SetActive(false);
    }

    private Action _onClose;

    public void Show(Action onClose)
    {
        _panel.SetActive(true);
        _scoreText.text = $"Your Score: {_scoreSystem.TotalScore}";
        _onClose = onClose;
    }

    public void Close()
    {
        _onClose?.Invoke();
    }
}
