using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        private PointCounter _pointCounter;
        private AudioSource _audioSource;

        [Range(0f, 1f)] public float MaxVolume = 1f;
        public float InterpolationTime = .2f;

        [Header("Time")]
        public float TimeStart = 0f;
        public float TimeEnd = 10000f;
        [Header("Score")]
        [Range(0f, 1f)] public float ScoreRationMin = 0f;
        [Range(0f, 1f)] public float ScoreRatioMax = 1f;

        private void Awake()
        {
            _pointCounter = FindObjectOfType<PointCounter>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            var motion = MaxVolume / InterpolationTime * Time.deltaTime;
            if (!ConditionsMet(Time.timeSinceLevelLoad)) motion *= -1f;

            _audioSource.volume = Mathf.Clamp(_audioSource.volume + motion, 0f, MaxVolume);
        }

        public bool ConditionsMet(float currentTime)
        {
            var scoreRatio = _pointCounter.RatioScore;
            return currentTime >= TimeStart && currentTime <= TimeEnd && scoreRatio >= ScoreRationMin &&
                   scoreRatio <= ScoreRatioMax;
        }
    }
}