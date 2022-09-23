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

        public PlayerScore(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}