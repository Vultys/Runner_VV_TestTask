using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaveSystem : ISaveSystem
{
    private const string SaveKey = "GameResults";

    public void SaveResult(GameResult result)
    {
        var list = LoadResults();
        list.Add(result);
        string json = JsonUtility.ToJson(new GameResultsWrapper(list));
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

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
