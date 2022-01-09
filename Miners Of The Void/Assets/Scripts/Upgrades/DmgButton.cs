using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgButton : UpgradeButton
{
   

    public override Upgrade GetUpgrade(int level = 1)
    {
        if (!UpgradeTransporter.levels.ContainsKey("damage"))
            return new DamageUpgrade("damage", level) { sprite = spriteUpgrade };
        else
        {
            int temp = (int)UpgradeTransporter.levels["damage"];
            UpgradeTransporter.levels.Remove("damage");
            return new DamageUpgrade("damage", temp) { sprite = spriteUpgrade };
        }

    }
   
    public void OnClick()
    {

        if (upgradeControllerUI.controller != null)
        {
            upgradeControllerUI.costs = new string[] { "Iron Ore", "Diamond", "Copper Ingot" };
            costs.SetActive(true);
            upgradeControllerUI.upgrade = GetUpgrade();
            upgradeControllerUI.currentController = currentUpgradeController;
        }
        
    }

    public void OnRemove()
    {


        if (upgradeControllerUI.controller != null)
        {

            Debug.Log(GetUpgrade().upgradeName);
            upgradeControllerUI.controller.TakeOfUpgrade(GetUpgrade().upgradeName);
        }
    }
}
