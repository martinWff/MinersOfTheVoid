using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavePlayerStats 
{
  

    //cheats
    public static bool immortality = false;
    public static int level = 1;
    public static int rp = 0;
    public static int requireRp;


    //Money
    public static int bips = 
        0;
    
    public static float GetWorldLevelValue(float baseValue,int worldLevel)
    {
        return baseValue * (Mathf.Pow(1.4f,worldLevel));
    }
    public static int GetWorldLevelValueINT(float baseValue, int worldLevel)
    {
        return Mathf.CeilToInt(GetWorldLevelValue(baseValue, worldLevel));
    }
}
