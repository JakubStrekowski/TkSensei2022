using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] SongChecker songChecker;
    [SerializeField] SongCreator songCreator;
    [SerializeField] SongPresenter songPresenter;
    [SerializeField] AudioPlayer audioPlayer;
    public void OnHitLeftDrum(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("Left Drum Hit: " + Time.time);
            Note newNote = songCreator.AddNewNote(EDrumType.Left);
            songPresenter.InstantiateNote(newNote, EDrumType.Left);
            audioPlayer.PlayLeft();
        }

    }
    public void OnHitRightDrum(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("Right Drum Hit: " + Time.time);
            Note newNote = songCreator.AddNewNote(EDrumType.Right);
            songPresenter.InstantiateNote(newNote, EDrumType.Right);
            audioPlayer.PlayRight();
        }
    }
    public void OnCheckLeftDrum(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            songChecker.CheckDrumHit(EDrumType.Left);
            audioPlayer.PlayLeft();
        }

    }
    public void OnCheckRightDrum(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            songChecker.CheckDrumHit(EDrumType.Right);
            audioPlayer.PlayRight();
        }
    }
    public void OnSaveSong(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("Song Saved: " + Time.time);
            songCreator.SaveCurrentSong();
        }
    }
}
