using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using Zenject;

public class LobbyRankUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rankText;

    private ISaveSystem _saveSystem;

    [Inject]
    public void Construct(ISaveSystem saveSystem)
    {
        _saveSystem = saveSystem;
    }

    private void OnEnable()
    {
        var results = _saveSystem.LoadResults()
            .OrderByDescending(r => r.TotalScore)
            .Take(10)
            .ToList();
        
        if(results.Count == 0) return;

        StringBuilder stringBuilder = new();
        for(int i = 0; i < results.Count; i++)
        {
            stringBuilder.AppendLine($"{i + 1}. {results[i].TotalScore} pts - {results[i].Date}");
        }

        _rankText.text = stringBuilder.ToString();
    }

    /// <summary>
    /// Shows the rank UI
    /// </summary>
    public void Show() => gameObject.SetActive(true);

    /// <summary>
    /// Invokes by the UI button to hide the rank UI
    /// </summary>
    public void Hide() => gameObject.SetActive(false);
}
