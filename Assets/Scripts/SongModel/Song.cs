using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Song
{
    public static string Directory => Application.persistentDataPath + "/Songs/";
    [System.NonSerialized] public string FileName = "CreatedSong.json";
    public string Path => Directory + FileName;

    public List<Note> leftNotes;
    public List<Note> rightNotes;
    public float duration;

    public Song()
    {
        leftNotes = new List<Note>();
        rightNotes = new List<Note>();
    }
    
    public void Save()
    {
        System.IO.Directory.CreateDirectory(Directory);
        File.WriteAllText(Path, JsonUtility.ToJson(this, true));
    }
}
