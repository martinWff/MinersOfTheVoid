using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to store upgrade data across scenes
public static class UpgradePersistentData
{
    //public static Upgrade[] spaceship = new Upgrade[4];
    //public static Upgrade[] humanPlayer = new Upgrade[4];

    public static Dictionary<string, Upgrade[]> upgrades = new Dictionary<string, Upgrade[]>();

    public static Dictionary<string,int> levels = new Dictionary<string, int>(240);

    public static void StoreUpgrade(string upname, int level)
    {
        if(levels.ContainsKey(upname))
        {
            levels[upname] = level;
        }
        else levels.Add(upname, level);

    }

    public static Upgrade[] GetUpgrades(string id)
    {
        Upgrade[] arr;
        if (!upgrades.TryGetValue(id,out arr))
        {
            arr = new Upgrade[0];
        }

        return arr;
    }
}
