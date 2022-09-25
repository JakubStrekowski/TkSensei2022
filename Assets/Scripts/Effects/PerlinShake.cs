using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PerlinShake : MonoBehaviour
{
    public float Frequency;
    public Vector2 Amplitude;
    [Range(0f, 1f)] public float Force;

    private Vector3 _initPosition;

    public float Duration;
    public Ease Easing;
    public float Seed;

    private void Awake()
    {
        _initPosition = transform.position;
    }

    private void Update()
    {
        var noise = new Vector2(
            Mathf.PerlinNoise(Time.time * Frequency, 123124.2341f + Seed),
            Mathf.PerlinNoise(Time.time * Frequency, 146953.85371f + Seed));
        var offset = new Vector2(noise.x * Amplitude.x, noise.y * Amplitude.y) * Force;
        transform.position = _initPosition + (Vector3)offset;
    }

    public void Shake()
    {
        this.DOKill(false);
        Force = 1f;
        DOTween.To(() => Force, value => Force = value, 0f, Duration).SetEase(Easing).SetTarget(this);
    }
}
