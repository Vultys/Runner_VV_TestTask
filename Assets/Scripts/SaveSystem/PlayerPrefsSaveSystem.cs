using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaveSystem : ISaveSystem
{
    private const string SaveKey = "GameResults";

    /// <summary>
    /// Saves the result to the player prefs
    /// </summary>
    /// <param name="result"> The result to save </param>
    public void SaveResult(GameResult result)
    {
        var list = LoadResults();
        list.Add(result);
        string json = JsonUtility.ToJson(new GameResultsWrapper(list));
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Loads the results from the player prefs
    /// </summary>
    /// <returns> The results </returns>
    public List<GameResult> LoadResults()
    {
        if(!PlayerPrefs.HasKey(SaveKey)) return new();

        string json = PlayerPrefs.GetString(SaveKey);

        return JsonUtility.FromJson<GameResultsWrapper>(json)?.results ?? new();
    }

    [Serializable]
    private class GameResultsWrapper
    {
        public List<GameResult> results;

        public GameResultsWrapper(List<GameResult> list)
        {
            results = list;
        }
    }
}
