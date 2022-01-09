using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkinChanger : MonoBehaviour
{
    public Sprite skin;
    private Sprite cache;
    public SpriteRenderer spriteRenderer;

    public bool fireIsHidden;
    void Start()
    {
        if (SavePlayerStats.currentSkin != null)
        {
            skin = SavePlayerStats.currentSkin;
            spriteRenderer.sprite = skin;
        }
    }

    void Update()
    {
        if (skin != cache)
        {
            spriteRenderer.sprite = skin;
            cache = skin;
        }
    }
}
