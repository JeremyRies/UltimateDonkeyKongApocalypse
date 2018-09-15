using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;

public static class StateController
{
    public static bool IsPaused = false;
    public static int CurrentVolume = 13;

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
            if (score > HighScore[i].Score)
            {
                for (var j = HighScore.Length - 1; j > i; j--)
                    HighScore[j] = HighScore[j - 1];
                HighScore[i] = new ScoreEntry(name.Substring(0, 4), score);
                break;
            }
        }
    }
}