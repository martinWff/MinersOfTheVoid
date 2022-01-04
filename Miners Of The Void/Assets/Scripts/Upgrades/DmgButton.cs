using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgButton : UpgradeButton
{
    public bool isClicked = false;
    public Text text;
    public GameObject costs;
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
        
        return new DamageUpgrade("dmg", level);
      
    }
    public void OnClick()
    {

        if (!isClicked)
        {
            costs.SetActive(true);
            isClicked = true;
            text.text = "Bips:200\nOre:1";
            return;
        }
        if (upgradeControllerUI.controller != null && isClicked)
        {
            costs.SetActive(false);
            
            upgradeControllerUI.controller.PlaceUpgrade(GetUpgrade());
            isClicked = false;
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
