using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class SavePlayerStats
{
    //Skin
    public static Sprite currentSkin;
    public static int skinId;
    

    //cheats
    public static bool immortality = false;
    public static int level = 1;
    public static int rp = 0;
    public static int requieredRp = 200;
    


    //used to cache the required rp for level up


    //Money
    public static int coins = 50;
    public static int bips = 0;
    public static int id = 0;
    
    public static bool UpgradeLevel()
    {
        requieredRp = (int)GetWorldLevelValue(200, level - 1);
        if (rp >= GetWorldLevelValue(200,level-1))
        {
            rp = rp - (int)GetWorldLevelValue(200, level - 1);
            level++;
            
            return true;
        }
        return false;
    }

    
    






    /*private static int dirtyLevel;

    public static int GetRequiredRP()
    {
        if (dirtyLevel == level)
        {
            return requiredRprequiredRp;
        }
        else
        {
            requiredRp = GetWorldLevelValueINT(150, level);
            dirtyLevel = level;
            return requiredRp;
        }
    }*/





    public static float GetWorldLevelValue(float baseValue, int worldLevel)
    {
        return baseValue * (Mathf.Pow(1.4f, worldLevel));
    }
    public static int GetWorldLevelValueINT(float baseValue, int worldLevel)
    {
        return Mathf.CeilToInt(GetWorldLevelValue(baseValue, worldLevel));
    }
}