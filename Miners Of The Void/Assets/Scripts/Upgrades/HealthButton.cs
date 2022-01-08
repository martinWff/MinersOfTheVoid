using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthButton : UpgradeButton
{

    public override Upgrade GetUpgrade(int level = 1)
    {
        if (!UpgradeTransporter.levels.ContainsKey("health"))
        return new HealthUpgrade("health", level) { sprite = spriteUpgrade };
        else
        {
            int temp = (int)UpgradeTransporter.levels["health"];
            UpgradeTransporter.levels.Remove("health");
            return new HealthUpgrade("health", temp ) { sprite = spriteUpgrade };
        }


    }

    public void OnClick()
    {

        if (upgradeControllerUI.controller != null)
        {
            costs.SetActive(true);
            upgradeControllerUI.upgrade = GetUpgrade();
            upgradeControllerUI.currentController = currentUpgradeController;
        }

    }

   
}
