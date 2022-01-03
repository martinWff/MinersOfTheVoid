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
        levels.Add(upname, level);
    }
}
