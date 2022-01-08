using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavePlayerStats
{
    //Skin
    public static Sprite currentSkin;

    //cheats
    public static bool immortality = false;
    public static int level = 1;
    public static int rp = 0;


    //used to cache the required rp for level up
    private static int requiredRp;
    private static int dirtyLevel;

    public static int GetRequiredRP()
    {
        if (dirtyLevel == level)
        {
            return requiredRp;
        }
        else
        {
            requiredRp = GetWorldLevelValueINT(150, level);
            dirtyLevel = level;
            return requiredRp;
        }
    }

    //Money
    public static int coins = 0;
    public static int bips =200;

    public static float GetWorldLevelValue(float baseValue, int worldLevel)
    {
        return baseValue * (Mathf.Pow(1.4f, worldLevel));
    }
    public static int GetWorldLevelValueINT(float baseValue, int worldLevel)
    {
        return Mathf.CeilToInt(GetWorldLevelValue(baseValue, worldLevel));
    }
}