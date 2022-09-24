using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public PointCountingConfig Config;

    public int PerfectNotes;
    public int GoodNotes;
    public int MissedNotes;
    public int SkippedNotes;

    public int NumberOfNotes;
    public int MaxScore;
    public float RatioScore => CurrentScore / (float) MaxScore;

    public int CurrentScore;

    public void StartCounter(int numberOfNotes)
    {
        PerfectNotes = 0;
        GoodNotes = 0;
        MissedNotes = 0;
        SkippedNotes = 0;
        NumberOfNotes = numberOfNotes;
        MaxScore = NumberOfNotes * Config.PerfectNoteScore;
    }

    public void RegisterPerfectNote()
    {
        PerfectNotes++;
        CurrentScore += Config.PerfectNoteScore;
    }

    public void RegisterGoodNote()
    {
        GoodNotes++;
        CurrentScore += Config.GoodNoteScore;
    }

    public void RegisterMissedNote()
    {
        MissedNotes++;
        CurrentScore += Config.MissedNoteScore;
    }

    public void RegisterSkippedNote()
    {
        SkippedNotes++;
        CurrentScore += Config.SkippedNoteScore;
    }
}