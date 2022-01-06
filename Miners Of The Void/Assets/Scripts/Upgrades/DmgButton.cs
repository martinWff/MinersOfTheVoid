using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgButton : UpgradeButton
{
   

    public override Upgrade GetUpgrade(int level = 1)
    {
        if (!UpgradeTransporter.levels.ContainsKey("dmg"))
            return new DamageUpgrade("dmg", level) { sprite = spriteUpgrade };
        else
        {
            int temp = (int)UpgradeTransporter.levels["dmg"];
            UpgradeTransporter.levels.Remove("dmg");
            return new DamageUpgrade("dmg", temp) { sprite = spriteUpgrade };
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

    public void OnRemove()
    {


        if (upgradeControllerUI.controller != null)
        {

            Debug.Log(GetUpgrade().upgradeName);
            upgradeControllerUI.controller.TakeOfUpgrade(GetUpgrade().upgradeName);
        }
    }
}
