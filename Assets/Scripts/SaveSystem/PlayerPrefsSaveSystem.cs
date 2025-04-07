using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaveSystem : ISaveSystem
{
    private const string SaveKey = "GameResults";

    public void SaveResult(List<GameResult> results)
    {
        string json = JsonUtility.ToJson(new GameResultsWrapper { Results = results });
        PlayerPrefs.SetString(SaveKey, json);
    }

    public List<GameResult> LoadResult()
    {
        if(!PlayerPrefs.HasKey(SaveKey)) return new();

        string json = PlayerPrefs.GetString(SaveKey);

        return JsonUtility.FromJson<GameResultsWrapper>(json).Results;
    }

    [Serializable]
    private class GameResultsWrapper
    {
        public List<GameResult> Results;
    }
}
