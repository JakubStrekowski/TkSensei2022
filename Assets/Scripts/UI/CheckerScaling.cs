using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerScaling : MonoBehaviour
{
    [SerializeField] private SongDifficultySO songDifficulty;

    [SerializeField] private Transform perfectBar;
    [SerializeField] private Transform eagerBar;
    [SerializeField] private Transform missBar;
    

    void Start()
    {
        perfectBar.localScale = new Vector3(
            songDifficulty.perfectTreshold * 2 * songDifficulty.moveSpeed,
            1,
            1);

        eagerBar.localScale = new Vector3(
            songDifficulty.eagerThreshold * songDifficulty.moveSpeed,
            1,
            1);

        missBar.localScale = new Vector3(
            songDifficulty.missThreshold * songDifficulty.moveSpeed,
            1,
            1);
    }
}
