using UnityEngine;
using UnityEngine.Video;

namespace Effects
{
    [RequireComponent(typeof(VideoPlayer))]
    public class VideoEffect : MonoBehaviour
    {
        private VideoPlayer _videoPlayer;
    }
}