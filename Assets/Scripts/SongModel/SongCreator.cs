using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SongCreator : MonoBehaviour
{
    [SerializeField] private PointCounter pointCounter;
    private Note[] currentNotes = new Note[(int)EDrumType.Count];

    public Song song;

    public Note AddNewNote(EDrumType drumType)
    {
        Note note;
        switch(drumType)
        {
            default:
            case EDrumType.Left:
            {
                note = new Note(Mathf.Round(Time.timeSinceLevelLoad * 16) / 16);
                song.leftNotes.Add(note);
                break;
            }
            case EDrumType.Right:
            {
                note = new Note(Mathf.Round(Time.timeSinceLevelLoad * 16) / 16);
                song.rightNotes.Add(note);
                break;
            }
        }
        return note;
    }

    public void SaveCurrentSong()
    {
        song.duration = Time.timeSinceLevelLoad;
        song.Save();
    }

    private void Awake() 
    {
        song = new Song();
    }
}
