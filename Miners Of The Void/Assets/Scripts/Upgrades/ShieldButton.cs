using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldButton : UpgradeButton
{
    private void Start()
    {
        
        if (upgradeControllerUI.controller == null)
        {
            if (isHumanoid)upgradeControllerUI.controller = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeController>();
            else upgradeControllerUI.controller = GameObject.FindGameObjectWithTag("Spaceship").GetComponent<UpgradeController>();
        }
        



    }

    public override Upgrade GetUpgrade(int level = 1)
    {

        if (!UpgradeTransporter.levels.ContainsKey("shield"))
            return new ShieldUpgrade("shield", level);
        else
        {
            int temp = (int)UpgradeTransporter.levels["shield"];
            UpgradeTransporter.levels.Remove("shield");
            return new ShieldUpgrade("shield", temp);
        }
    }
    public void OnClick()
    {


        if (upgradeControllerUI.controller != null)
        {
            
            upgradeControllerUI.controller.PlaceUpgrade(GetUpgrade());
        }
    }
}
