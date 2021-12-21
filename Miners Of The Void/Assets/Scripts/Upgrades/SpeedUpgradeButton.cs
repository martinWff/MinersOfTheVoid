using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgradeButton : UpgradeButton
{
    public override Upgrade GetUpgrade(int level = 1)
    {
        return new SpeedUpgrade("speed", level);
    }
    public void OnClick()
    {
        if (upgradeControllerUI.controller != null)
        {
            upgradeControllerUI.controller.PlaceUpgrade(GetUpgrade());
        }
    }
}
