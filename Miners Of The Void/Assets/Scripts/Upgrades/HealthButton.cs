using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthButton : UpgradeButton
{

    
    private void Start()
    {
        
        if (upgradeControllerUI.controller == null)
        {
            if (isHumanoid) upgradeControllerUI.controller = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeController>();
            else upgradeControllerUI.controller = GameObject.FindGameObjectWithTag("Spaceship").GetComponent<UpgradeController>();
        }




    }

  /*  private IEnumerator LateEnable()
    {
        yield return new WaitForEndOfFrame(2),
    }*/

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
}
