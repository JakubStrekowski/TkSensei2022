using UnityEngine;

[CreateAssetMenu]
public class PointCountingConfig : ScriptableObject
{
    public int PerfectNoteScore;
    public int GoodNoteScore;
    public int MissedNoteScore;
    public int SkippedNoteScore;
}