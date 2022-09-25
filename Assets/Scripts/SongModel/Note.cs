using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using SongModel;
using UnityEngine;

public enum EDrumType
{
    Left,
    Right,

    Count
}

[Serializable]
public class Note
{
    public float time;
    public EDrumType DrumType;

    [System.NonSerialized] public bool isHit;
    [System.NonSerialized] public SpriteRenderer presenterReference;
    [NonSerialized] public NoteData noteData;

    public Note(float time, EDrumType drumType)
    {
        this.time = time;
        DrumType = drumType;
    }

    public void OnCorrect()
    {
        presenterReference.sprite = noteData.PerfectSprite;
        FadeOut();
    }

    public void OnGood()
    {
        presenterReference.sprite = noteData.GoodSprite;
        FadeOut();
    }

    public void OnIncorrect()
    {
        presenterReference.sprite = noteData.SkippedSprite;
        FadeOut();
    }

    public void FadeOut()
    {
        presenterReference.DOFade(0f, .4f);
    }
}
