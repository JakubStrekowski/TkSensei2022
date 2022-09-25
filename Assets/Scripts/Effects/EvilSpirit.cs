using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSpirit : MonoBehaviour
{
    public Sprite[] sprites;
    [SerializeField] PointCounter pointCounter;

    private SpriteRenderer sr;
    private Vector3 originalPos;

    private void SetSprite(int id)
    {
        sr.sprite = sprites[id];
    }
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
        if (pointCounter.RatioScore < 0.5)
        {
            SetSprite(0);
        }
        else if (pointCounter.RatioScore < 0.75)
        {
            SetSprite(1);
        }
        else
        {
            SetSprite(2);
        }

        sr.color = new Color(1, 1, 1, 
        (float)Mathf.Sin(Time.time) / 4 + 0.55f);

        transform.position = new Vector3(
            originalPos.x,
            originalPos.y + Mathf.Sin(Time.time) / 3,
            originalPos.z
        );
    }

}
