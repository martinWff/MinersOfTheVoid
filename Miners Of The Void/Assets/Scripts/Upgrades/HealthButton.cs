using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthButton : UpgradeButton
{

    public override Upgrade GetUpgrade(int level = 1)
    {
        if (!UpgradeTransporter.levels.ContainsKey("hp"))
        return new HealthUpgrade("hp", level) { sprite = spriteUpgrade };
        else
        {
            int temp = (int)UpgradeTransporter.levels["hp"];
            UpgradeTransporter.levels.Remove("hp");
            return new HealthUpgrade("hp",temp ) { sprite = spriteUpgrade };
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
