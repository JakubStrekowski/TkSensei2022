using UnityEngine;

namespace Points
{
    public class LeaderboardsTest : MonoBehaviour
    {
        public string myName;
        public int score;

        [ContextMenu("Test")]
        public void Test()
        {
            var score = new PlayerScore(myName, this.score);
            GetComponent<LeaderboardManager>().AddScore(score);
        }
    }
}