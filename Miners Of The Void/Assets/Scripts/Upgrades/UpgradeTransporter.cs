using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradeTransporter
{
    public static Upgrade[] spaceship = new Upgrade[4];
    public static Upgrade[] humanPlayer = new Upgrade[4];

    public static Dictionary<string,int> levels = new Dictionary<string, int>(240);

    public static void upgradeSaver(string upname, int level)
    {
        if(levels.ContainsKey(upname))
        {
            levels.Remove(upname);
            levels.Add(upname, level);
        }
        else levels.Add(upname, level);

    }
}
