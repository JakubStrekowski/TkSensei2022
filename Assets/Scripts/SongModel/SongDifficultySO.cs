using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SongDifficultySO : ScriptableObject
{
    public float perfectTreshold = 0.05f;
    public float missThreshold = 0.10f;
    public float eagerThreshold = 0.10f;

    public float moveSpeed = 5.0f;
}
