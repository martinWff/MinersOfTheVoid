using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShieldButton : UpgradeButton
{
    

    public override Upgrade GetUpgrade(int level = 1)
    {

        if (!UpgradeTransporter.levels.ContainsKey("shield"))
            return new ShieldUpgrade("shield", level) { sprite = spriteUpgrade};
        else
        {
            int temp = (int)UpgradeTransporter.levels["shield"];
            UpgradeTransporter.levels.Remove("shield");
            return new ShieldUpgrade("shield", temp) { sprite = spriteUpgrade };
        }
    }
    public void OnClick()
    {

        if (upgradeControllerUI.controller != null)
        {
            upgradeControllerUI.costs = new string[] { "Gold Ingot", "Osmium Nugget", "Copper" };
            costs.SetActive(true);
            upgradeControllerUI.upgrade = GetUpgrade();
            upgradeControllerUI.currentController = currentUpgradeController;
        }

    }
}
