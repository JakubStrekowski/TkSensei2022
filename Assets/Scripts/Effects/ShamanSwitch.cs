using System.Collections;
using System.Collections.Generic;
using Effects;
using UnityEngine;

public class ShamanSwitch : MonoBehaviour
{
    public Sprite[] sprites;
    public FlashSprite[] flashSprites;

    public int currentId = 0;

    private SpriteRenderer sr;

    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void SwitchSprite()
    {
        currentId = (currentId + 1) % sprites.Length;
        sr.sprite = sprites[currentId];
        flashSprites[currentId].Flash();
        GetComponent<PerlinShake>().Shake();
    }
}
