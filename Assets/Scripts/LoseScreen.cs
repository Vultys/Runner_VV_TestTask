using System;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private Action _onClose;

    public void Show(Action onClose)
    {
        _panel.SetActive(true);
        _onClose = onClose;
    }

    public void Close()
    {
        _onClose?.Invoke();
        _panel.SetActive(false);
    }
}
