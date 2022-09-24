using System;
using System.Collections.Generic;

namespace Points
{
    [Serializable]
    public class Leaderboard
    {
        public List<PlayerScore> Scores = new List<PlayerScore>();
    }

    [Serializable]
    public class PlayerScore
    {
        public string Name;
        public int Score;
        public string Progress;

        public PlayerScore(string name, int score, float progress)
        {
            Name = name;
            Score = score;
            Progress = String.Format("{0:0.00}%", progress * 100f);
        }
    }
}