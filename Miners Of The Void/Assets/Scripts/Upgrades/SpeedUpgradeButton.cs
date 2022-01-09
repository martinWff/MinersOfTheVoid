using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgradeButton : UpgradeButton
{
    public override Upgrade GetUpgrade(int level = 1)
    {
        if (!UpgradeTransporter.levels.ContainsKey("speed"))
            return new SpeedUpgrade("speed", level) { sprite = spriteUpgrade };
        else
        {
            int temp = (int)UpgradeTransporter.levels["speed"];
            UpgradeTransporter.levels.Remove("speed");
            return new SpeedUpgrade("speed", temp) { sprite = spriteUpgrade };
        }
    }
    public void OnClick()
    {
        if (upgradeControllerUI.controller != null)
        {
            upgradeControllerUI.costs = new string[] { "Osmium", "Copper Nugget", "Cutted Diamond" };
            costs.SetActive(true);
            upgradeControllerUI.upgrade = GetUpgrade();
            upgradeControllerUI.currentController = currentUpgradeController;
            upgradeControllerUI.ApplyData();
        }

    }
}
