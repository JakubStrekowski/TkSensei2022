using System;
using DG.Tweening;
using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FlashSprite : MonoBehaviour
    {
        [Range(0f, 1f)]
        public float StartAlpha = 1f;
        public float Duration = .2f;
        public Ease Easing = Ease.Linear;
        
        private SpriteRenderer _renderer;
        private Tween _tween;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            var c = _renderer.color;
            c.a = 0f;
            _renderer.color = c;
        }

        public void Flash()
        {
            if (_tween != null && !_tween.IsComplete())
            {
                _tween.Kill();
            }

            var c = _renderer.color;
            c.a = StartAlpha;
            _renderer.color = c;

            _tween = _renderer.DOFade(0f, Duration).SetEase(Easing);
        }
    }
}