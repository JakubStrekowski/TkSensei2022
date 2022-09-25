using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSpirit : MonoBehaviour
{
    public Sprite[] sprites;
    [SerializeField] PointCounter pointCounter;

    private SpriteRenderer sr;
    private Vector3 originalPos;
    private int currentState = 0;

    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        originalPos = transform.position;
    }

    public void Update()
    {
        if (currentState == 0)
        {
            if (pointCounter.RatioScore > 0.5f)
            {
                SetState(1);
            }
        }

        if (currentState == 1)
        {
            if (pointCounter.RatioScore > 0.75f)
            {
                SetState(2);
            }
        }

        sr.color = new Color(1, 1, 1, 
        (float)Mathf.Sin(Time.time) / 4 + 0.55f);

        transform.position = new Vector3(
            originalPos.x,
            originalPos.y + Mathf.Sin(Time.time) / 3,
            originalPos.z
        );
    }

    public void SetState(int id)
    {
        StopCoroutine(nameof(ChangeState));
        StartCoroutine(nameof(ChangeState), id);
    }

    private IEnumerator ChangeState(int id)
    {
        float elapsedTime = 0f;
        Color transparent = new Color(1, 1, 1, 0);
        Color lastColor = sr.color;
        currentState = id;

        while(elapsedTime < 0.75f)
        {
            elapsedTime += Time.deltaTime;
            sr.color = Color.Lerp(lastColor, transparent, elapsedTime / 0.75f);
            yield return null;
        }

        sr.sprite = sprites[id];
        
        while(elapsedTime < 1.5f)
        {
            elapsedTime += Time.deltaTime;
            sr.color = Color.Lerp(transparent, lastColor, elapsedTime / 1.5f);
            yield return null;
        }
    }
}
