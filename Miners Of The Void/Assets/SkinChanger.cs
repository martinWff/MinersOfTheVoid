using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkinChanger : MonoBehaviour
{
    public Sprite skin;
    public Sprite fire;
    private Sprite cache;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer fireSpriteRenderer;

    public bool fireIsHidden;
    void Start()
    {
        if (SavePlayerStats.currentSkin != null)
        {
            skin = SavePlayerStats.currentSkin;
            spriteRenderer.sprite = skin;

            fireSpriteRenderer.sprite = fire;
        }
    }

    void Update()
    {
        if (fire != cache)
        {
            fireSpriteRenderer.sprite = fire;
            cache = skin;
        }
    }
}
