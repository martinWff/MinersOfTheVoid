using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgButton : UpgradeButton
{
    private void Start()
    {
        if(upgradeControllerUI.controller == null)
        {
            if (isHumanoid) upgradeControllerUI.controller = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeController>();
            else upgradeControllerUI.controller = GameObject.FindGameObjectWithTag("Spaceship").GetComponent<UpgradeController>();
        } 
        



    }

    public override Upgrade GetUpgrade(int level = 1)
    {
        Debug.Log("Preciso de caf�"); 
        return new DamageUpgrade("dmg", level);
      
    }
    public void OnClick()
    {
       
        
        if (upgradeControllerUI.controller != null)
        {
            Debug.Log("Preciso mesmo de caf�");
            upgradeControllerUI.controller.PlaceUpgrade(GetUpgrade());
        }
    }
}
