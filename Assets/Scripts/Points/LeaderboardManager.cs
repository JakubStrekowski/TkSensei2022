using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Points
{
    public class LeaderboardManager : MonoBehaviour
    {
        private readonly int MAX_HIGHSCORE_LIMIT = 10;
        public static string Directory => Application.persistentDataPath + "/Scores/";

        public string FileName;

        public string Path => Directory + FileName;

        public Leaderboard CurrentLeaderboard;

        public TMP_Text[] UserNamesTxt;
        public TMP_Text[] ScoresTxt;
        public TMP_Text[] AccuraciesTxt;

        
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
            }
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public bool IsNewScore(PlayerScore score)
        {
            if (CurrentLeaderboard.Scores.Count < MAX_HIGHSCORE_LIMIT)
            {
                return true;
            }

            int lowestScore = CurrentLeaderboard.Scores.Min(x => x.Score);

            if (lowestScore < score.Score)
            {
                return true;
            }
            return false;
        }

        public void AddScore(PlayerScore score)
        {
            PlayerScore oldScore = CurrentLeaderboard.Scores.Find(x => x.Name == score.Name);
            if (oldScore != null)
            {
                if (oldScore.Score < score.Score)
                {
                    CurrentLeaderboard.Scores.Remove(oldScore);
                }
                else
                {
                    UpdateScores();
                    return;
                }
            }

            CurrentLeaderboard.Scores.Add(score);

            CurrentLeaderboard.Scores = CurrentLeaderboard.Scores.OrderByDescending(x=>x.Score).ToList();
            if (CurrentLeaderboard.Scores.Count > MAX_HIGHSCORE_LIMIT)
            {
                CurrentLeaderboard.Scores.Remove(CurrentLeaderboard.Scores.Last());
            }
            UpdateScores();
            File.WriteAllText(Path, JsonUtility.ToJson(CurrentLeaderboard));
        }

        public void UpdateScores()
        {
            for (int i = 0; i < MAX_HIGHSCORE_LIMIT; i++)
            {
                if (i == CurrentLeaderboard.Scores.Count) break;
                
                UserNamesTxt[i].text = CurrentLeaderboard.Scores[i].Name;
                ScoresTxt[i].text = CurrentLeaderboard.Scores[i].Score.ToString();
                AccuraciesTxt[i].text = CurrentLeaderboard.Scores[i].Progress.ToString();
            }
        }
    }
}