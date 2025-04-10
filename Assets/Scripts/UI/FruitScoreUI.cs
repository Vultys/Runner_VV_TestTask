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
    }

    private void Update()
    {
        _redFruitScoreText.text = "Carrots: " + _scoreSystem.GetCollectedCount("carrot").ToString();
        _greenFruitScoreText.text = "Kiwi: " + _scoreSystem.GetCollectedCount("kiwi").ToString();
        _blueFruitScoreText.text = "Blue Pie: " + _scoreSystem.GetCollectedCount("bluePie").ToString();
        _yellowFruitScoreText.text = "Banana: " + _scoreSystem.GetCollectedCount("banana").ToString();
        _totalScoreText.text = "Total: " + _scoreSystem.TotalScore.ToString();
    }
}
