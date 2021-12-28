using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgButton : UpgradeButton
{
    
    public override Upgrade GetUpgrade(int level = 1)
    {
        return new DamageUpgrade("dmg", level);
    }
    public void OnClick()
    {
        if (upgradeControllerUI.controller != null)
        {
            upgradeControllerUI.controller.PlaceUpgrade(GetUpgrade());
        }
    }
}
