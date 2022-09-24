using System.Collections;
using System.Collections.Generic;
using System.IO;
using Points;
using TMPro;
using UnityEngine;

public class SongChecker : MonoBehaviour
{
    public float timeBeforeStart = 3.0f;
    public SongPresenter songPresenter;
    public static string Directory => Application.persistentDataPath + "/Songs/";
    public string FileName = "CreatedSong.json";
    public string Path => Directory + FileName;

    public SongDifficultySO difficultySO;
    public Song song;

    [SerializeField] private PointCounter pointCounter;
    private Note[] currentNotes = new Note[(int)EDrumType.Count];
    private int currentLeftId;
    private int currentRightId;
    private bool hasFinished = false;
    
    public LeaderboardManager leaderboardManager;
    public TMP_Text finalScore;
    public TMP_InputField nameInput;
    public GameObject submitPanel;
    public GameObject highScorePanel;

    private void Awake() 
    {
        var json = File.ReadAllText(Path);
        song = JsonUtility.FromJson<Song>(json);

        currentNotes[(int)EDrumType.Left] = song.leftNotes[0];
        currentNotes[(int)EDrumType.Right] = song.rightNotes[0];
    }

    private void Start() 
    {
        songPresenter.InstantiateNotes(song, timeBeforeStart);
        pointCounter.StartCounter(song.leftNotes.Count + song.rightNotes.Count);
    }

    public void Submit()
    {
        PlayerScore newScore = new PlayerScore(nameInput.text, pointCounter.CurrentScore, pointCounter.RatioScore);
        leaderboardManager.AddScore(newScore);
        submitPanel.SetActive(false);
        highScorePanel.SetActive(true);
    }

    public void CheckDrumHit(EDrumType drumType)
    {
        // no more notes in this drum line
        if (currentNotes[(int)drumType] == null)
        {
            Debug.Log("Missed: " + Time.time + " vs. " + "no more notes");
            pointCounter.RegisterMissedNote();
            return;
        }

        if (Time.time < currentNotes[(int)drumType].time + difficultySO.perfectTreshold &&
            Time.time > currentNotes[(int)drumType].time - difficultySO.perfectTreshold)
            {
                pointCounter.RegisterPerfectNote();
                currentNotes[(int)drumType].isHit = true;
                Debug.Log("Perfect: " + Time.time + " vs. " + currentNotes[(int)drumType].time);
                currentNotes[(int)drumType].OnCorrect();
                FindNextNote(drumType);
            }
        else 
        {
            if (Time.time < currentNotes[(int)drumType].time + difficultySO.eagerThreshold &&
                Time.time > currentNotes[(int)drumType].time - difficultySO.missThreshold)
            {
                pointCounter.RegisterGoodNote();
                currentNotes[(int)drumType].isHit = true;
                Debug.Log("Good: " + Time.time + " vs. " + currentNotes[(int)drumType].time);
                currentNotes[(int)drumType].OnCorrect();
                FindNextNote(drumType);
            }
            else if (!(Time.time < currentNotes[(int)drumType].time + difficultySO.eagerThreshold))
            {
                pointCounter.RegisterMissedNote();
                Debug.Log("Missed: " + Time.time + " vs. " + currentNotes[(int)drumType].time);
                currentNotes[(int)drumType].OnIncorrect();
                FindNextNote(drumType);
            }
            else
            {
                pointCounter.RegisterMissedNote();
                Debug.Log("Missed: " + Time.time + " vs. " + currentNotes[(int)drumType].time);
            }
        }
    }

    public void FindNextNote(EDrumType drumType)
    {
        switch (drumType)
        {
            case EDrumType.Left:
                currentLeftId++;
                currentNotes[(int)drumType] = song.leftNotes.Count > currentLeftId ? song.leftNotes[currentLeftId] : null;
                break;
            case EDrumType.Right:
                currentRightId++;
                currentNotes[(int)drumType] = song.rightNotes.Count > currentRightId ? song.rightNotes[currentRightId] : null;
                break;
        }
    }

    private void Update() 
    {
        for(int drumType = 0; drumType < (int)EDrumType.Count; drumType++)
        {
            if (currentNotes[drumType] == null) continue;

            if (Time.time > currentNotes[drumType].time + difficultySO.eagerThreshold)
            {
                pointCounter.RegisterSkippedNote();
                Debug.Log("Skipped: " + Time.time + " vs. " + currentNotes[(int)drumType].time);
                currentNotes[(int)drumType].OnIncorrect();
                FindNextNote((EDrumType)drumType);
            }
        }

        if (currentNotes[(int)EDrumType.Left] == null && 
            currentNotes[(int)EDrumType.Right] == null &&
            !hasFinished)
        {
            hasFinished = true;
            StartCoroutine(nameof(WaitBeforeFinish));
        }
    }

    private IEnumerator WaitBeforeFinish()
    {
        yield return new WaitForSeconds(2);
        finalScore.text = pointCounter.CurrentScore.ToString();
        PlayerScore newScore = new PlayerScore("Name", pointCounter.CurrentScore, pointCounter.RatioScore);
        if (leaderboardManager.IsNewScore(newScore))
        {
            submitPanel.SetActive(true);
        }
        else
        {
            highScorePanel.SetActive(false);
        }
    }
}
