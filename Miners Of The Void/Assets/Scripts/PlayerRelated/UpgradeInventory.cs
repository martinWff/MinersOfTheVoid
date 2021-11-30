using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInventory : Inventory
{
    public override bool AddOre(OreStack ore)
    {
        if (CountDifferent < 4)
        {
            if (GetOreAmount(ore.oreName) < 6)
                return base.AddOre(ore);
            else return false;
        } else return false;
        
    }
 
}
