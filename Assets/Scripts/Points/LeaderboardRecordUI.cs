using TMPro;
using UnityEngine;

namespace Points
{
    public class LeaderboardRecordUI : MonoBehaviour
    {
        public TMP_Text Name;
        public TMP_Text Score;
        
        public void Init(PlayerScore score)
        {
            Name.text = score.Name;
            Score.text = $"{score.Score} ({score.Progress})";
        }
    }
}