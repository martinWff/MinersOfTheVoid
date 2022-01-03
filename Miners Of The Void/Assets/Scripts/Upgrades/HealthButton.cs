using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthButton : UpgradeButton
{
    private void Start()
    {
        isHumanoid = true;
        if (upgradeControllerUI.controller == null)
        {
            if (isHumanoid) upgradeControllerUI.controller = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeController>();
            else upgradeControllerUI.controller = GameObject.FindGameObjectWithTag("Spaceship").GetComponent<UpgradeController>();
        }




    }

    public override Upgrade GetUpgrade(int level = 1)
    {
        Debug.Log("Preciso de café");
        if (!UpgradeTransporter.levels.ContainsKey("hp"))
        return new HealthUpgrade("hp", level);
        else return new HealthUpgrade("hp", (int)UpgradeTransporter.levels["hp"]);


    }
    public void OnClick()
    {


        if (upgradeControllerUI.controller != null)
        {
            
            upgradeControllerUI.controller.PlaceUpgrade(GetUpgrade());
            
        }
    }
}
