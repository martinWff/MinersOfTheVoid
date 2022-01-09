using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public bool isHumanoid;
    public bool isClicked = false;
    public Text text;
    public GameObject costs;
    public Sprite spriteUpgrade;
    public UpgradeUIController upgradeControllerUI;
    protected UpgradeController currentUpgradeController;
    public virtual Upgrade GetUpgrade(int level)
    {
        return null;
    }

    private void Start()
    {

        if (isHumanoid)
        {
            currentUpgradeController = upgradeControllerUI.humanoidController;
        } else
        {
            currentUpgradeController = upgradeControllerUI.controller;
        }
    }

}
