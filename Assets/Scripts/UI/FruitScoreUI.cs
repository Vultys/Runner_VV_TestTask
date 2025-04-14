using TMPro;
using UnityEngine;
using Zenject;

public class FruitScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _redFruitScoreText;
    [SerializeField] private TextMeshProUGUI _greenFruitScoreText;
    [SerializeField] private TextMeshProUGUI _blueFruitScoreText;
    [SerializeField] private TextMeshProUGUI _yellowFruitScoreText;
    [SerializeField] private TextMeshProUGUI _totalScoreText;

    private IFruitScoreSystem _scoreSystem;

    [Inject]
    public void Construct(IFruitScoreSystem scoreSystem)
    {
        _scoreSystem = scoreSystem;
        UpdateUIText();
    }

    private void OnEnable() => _scoreSystem.OnScoreChanged += UpdateUIText;

    private void OnDisable() => _scoreSystem.OnScoreChanged -= UpdateUIText;

    private void UpdateUIText()
    {
        _redFruitScoreText.text = "Carrots: " + _scoreSystem.GetCollectedCount(FruitsType.Carrot).ToString();
        _greenFruitScoreText.text = "Kiwi: " + _scoreSystem.GetCollectedCount(FruitsType.Kiwi).ToString();
        _blueFruitScoreText.text = "Blue Pie: " + _scoreSystem.GetCollectedCount(FruitsType.BluePie).ToString();
        _yellowFruitScoreText.text = "Banana: " + _scoreSystem.GetCollectedCount(FruitsType.Banana).ToString();
        _totalScoreText.text = "Total: " + _scoreSystem.TotalScore.ToString();
    }
}
