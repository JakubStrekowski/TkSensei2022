using System.Collections.Generic;
using UnityEngine;

namespace Points
{
    public class LeaderboardUI : MonoBehaviour
    {
        public LeaderboardRecordUI RecordPrefab;
        public Transform ContentParent;

        private List<LeaderboardRecordUI> _spawned = new List<LeaderboardRecordUI>();

        public void Init(Leaderboard leaderboard)
        {
            foreach (var recordUI in _spawned)
            {
                Destroy(recordUI.gameObject);
            }

            foreach (var score in leaderboard.Scores)
            {
                var record = Instantiate(RecordPrefab, ContentParent);
                record.Init(score);
                _spawned.Add(record);
            }
        }
    }
}