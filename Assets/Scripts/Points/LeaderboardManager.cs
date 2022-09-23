using System;
using System.IO;
using UnityEngine;

namespace Points
{
    public class LeaderboardManager : MonoBehaviour
    {
        public static string Directory => Application.persistentDataPath + "/Scores/";

        public string FileName;

        public string Path => Directory + FileName;

        public Leaderboard CurrentLeaderboard;
        
        private void Awake()
        {
            if (File.Exists(Path))
            {
                var json = File.ReadAllText(Path);
                CurrentLeaderboard = JsonUtility.FromJson<Leaderboard>(json);
            }
            else
            {
                CurrentLeaderboard = new Leaderboard();
                System.IO.Directory.CreateDirectory(Directory);
                File.WriteAllText(Path, JsonUtility.ToJson(CurrentLeaderboard));
            }
        }

        public void AddScore(PlayerScore score)
        {
            CurrentLeaderboard.Scores.Add(score);
            File.WriteAllText(Path, JsonUtility.ToJson(CurrentLeaderboard));
        }
    }
}