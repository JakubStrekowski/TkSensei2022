using System.Collections;
using System.Collections.Generic;
using SongModel;
using UnityEngine;

public enum EScrollDirection
{
    Left = -1,
    Right = 1
}

public class SongPresenter : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public EScrollDirection direction;
    public GameObject notesAnchor;
    public Transform leftNotesParent;
    public Transform rightNotesParent;

    public GameObject leftNotePrefab;
    public GameObject rightNotePrefab;

    float anchorStartPos;

    private void Awake() 
    {
        anchorStartPos = notesAnchor.transform.position.x;
    }
    public void InstantiateNotes(Song song, float timeBeforeStart)
    {
        GameObject newObj;
        foreach (Note note in song.leftNotes)
        {
            note.time += timeBeforeStart;
            newObj = Instantiate(leftNotePrefab, 
                new Vector3(
                    (notesAnchor.transform.position.x - (float)direction * moveSpeed * note.time),
                    leftNotesParent.position.y,
                    leftNotesParent.position.z), 
                Quaternion.identity, 
                leftNotesParent);
            note.DrumType = EDrumType.Left;
            note.presenterReference = newObj.GetComponent<SpriteRenderer>();
            note.noteData = newObj.GetComponent<NoteData>();
        }
        foreach (Note note in song.rightNotes)
        {
            note.time += timeBeforeStart;
            newObj = Instantiate(rightNotePrefab, 
                new Vector3(
                    (notesAnchor.transform.position.x - (float)direction * moveSpeed * note.time),
                    rightNotesParent.position.y,
                    rightNotesParent.position.z), 
                Quaternion.identity, 
                rightNotesParent);
            note.DrumType = EDrumType.Right;
            note.presenterReference = newObj.GetComponent<SpriteRenderer>();
            note.noteData = newObj.GetComponent<NoteData>();
        }
    }

    public void InstantiateNote(Note note, EDrumType input)
    {
        GameObject newObj;
        switch(input)
        {
            case EDrumType.Left:
                newObj = Instantiate(leftNotePrefab, 
                    new Vector3(
                        (notesAnchor.transform.position.x - (float)direction * moveSpeed * note.time),
                        leftNotesParent.position.y,
                        leftNotesParent.position.z), 
                    Quaternion.identity, 
                    leftNotesParent);
                note.DrumType = EDrumType.Left;
                note.presenterReference = newObj.GetComponent<SpriteRenderer>();
                note.noteData = newObj.GetComponent<NoteData>();
                break;
            case EDrumType.Right:
                newObj = Instantiate(rightNotePrefab, 
                    new Vector3(
                        (notesAnchor.transform.position.x - (float)direction * moveSpeed * note.time),
                        rightNotesParent.position.y,
                        rightNotesParent.position.z), 
                    Quaternion.identity, 
                    rightNotesParent);
                note.DrumType = EDrumType.Right;
                note.presenterReference = newObj.GetComponent<SpriteRenderer>();
                note.noteData = newObj.GetComponent<NoteData>();
                break;
        }
    }

    private void FixedUpdate() 
    {
        notesAnchor.transform.position = new Vector3(
            anchorStartPos + ((float)direction * moveSpeed * Time.timeSinceLevelLoad),
            notesAnchor.transform.position.y,
            notesAnchor.transform.position.z);
    }
}
