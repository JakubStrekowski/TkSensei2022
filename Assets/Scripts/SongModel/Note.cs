using System;
using System.Collections;
using System.Collections.Generic;
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

    [System.NonSerialized] public bool isHit;

    public Note(float time)
    {
        this.time = time;
    }
}
