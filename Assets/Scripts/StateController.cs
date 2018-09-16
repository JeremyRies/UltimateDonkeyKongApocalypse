using System;
using System.Collections;
using UnityEngine;

public static class StateController
{
    public static bool IsPaused = false;
    public static int CurrentVolume = 13;
    public static int CurrentScore = 0;

    public static ScoreEntry[] HighScore = 
    {
        new ScoreEntry("AAAA", 0),
        new ScoreEntry("AAAA", 0),
        new ScoreEntry("AAAA", 0),
        new ScoreEntry("AAAA", 0),
        new ScoreEntry("AAAA", 0),
        new ScoreEntry("AAAA", 0),
        new ScoreEntry("AAAA", 0)
    };

    public static void GameOver()
    {
        IsPaused = true;
        GameObject.Find("Canvas").GetComponent<StateControllerMono>().InstantiateGameOverPanel();
    }

    public static void ArchiveHighScoreAs(string name)
    {
        for (var i = 0; i < HighScore.Length; i++)
        {
            if (CurrentScore <= HighScore[i].Score) continue;
            for (var j = HighScore.Length - 1; j > i; j--)
                HighScore[j] = HighScore[j - 1];
            HighScore[i] = new ScoreEntry(name.Substring(0, 4), CurrentScore);
            break;
        }
        CurrentScore = 0;
    }
}