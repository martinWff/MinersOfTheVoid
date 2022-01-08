using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkinChanger : MonoBehaviour
{
    public Sprite skin;
    void Start()
    {
        if (SavePlayerStats.currentSkin != null)
        {
            skin = SavePlayerStats.currentSkin;
            gameObject.GetComponent<SpriteRenderer>().sprite = skin;
        }
    }
}
