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
        Debug.Log("Preciso de café");
        return new ShieldUpgrade("shield", level);

    }
    public void OnClick()
    {


        if (upgradeControllerUI.controller != null)
        {
            Debug.Log("Preciso mesmo de café");
            upgradeControllerUI.controller.PlaceUpgrade(GetUpgrade());
        }
    }
}
