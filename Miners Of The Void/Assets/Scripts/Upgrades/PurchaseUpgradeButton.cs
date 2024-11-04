using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseUpgradeButton : MonoBehaviour
{
    public Text text;
    public GameObject costs;
    public Sprite spriteUpgrade;
    public UpgradeUIController upgradeControllerUI;

    protected UpgradeController currentUpgradeController;

    public UpgradeStorage upgradeStorage;

    public UpgradeBuilder upgradeBuiler;

    public UpgradeController upgradeController;

    private void Start()
    {

       
    }

    public void OnPress()
    {
        Upgrade upgrade = upgradeBuiler.Build(1);
        upgradeControllerUI.costs = upgradeBuiler.GetUpgradeCosts(1);
        upgradeControllerUI.upgrade = upgrade;
        upgradeControllerUI.currentController = upgradeController;
        upgradeControllerUI.storage = upgradeStorage;
        upgradeControllerUI.ApplyData();

        costs.SetActive(true);
    }

}
