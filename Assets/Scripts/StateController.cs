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

    public static void AddHighScore(string name, int score)
    {
        for (var i = 0; i < HighScore.Length; i++)
        {
            if (score <= HighScore[i].Score) continue;
            for (var j = HighScore.Length - 1; j > i; j--)
                HighScore[j] = HighScore[j - 1];
            HighScore[i] = new ScoreEntry(name.Substring(0, 4), score);
            break;
        }
    }

    public static void Pause()
    {
        GameObject.Find("Canvas").transform.Find("MainMenu(Clone)").gameObject.SetActive(true);
        IsPaused = true;
    }

    public static void GameOver()
    {
        throw new NotImplementedException();
    }

    public static void ArchiveHighScoreAs(string name)
    {
        AddHighScore(name, CurrentScore);
        CurrentScore = 0;
    }
}