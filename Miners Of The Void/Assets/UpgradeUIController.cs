using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIController : MonoBehaviour
{
    public List<GameObject> upgradeUI = new List<GameObject>(4);
    public UpgradeController controller;
    public UpgradeController humanoidController;

    public UpgradeController currentController;
    public Upgrade upgrade;

    public GameObject purchaseWindow;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Spaceship").GetComponent<UpgradeController>();
        
        if (controller != null)
        {
            if (controller.upgradeHolder != null)
            {
                for (int i = 0; i < controller.upgradeHolder.Length; i++)
                {
                    if (controller.upgradeHolder[i] != null)
                    {
                        OnUpgradePut(controller,controller.upgradeHolder[i], i);
                    }
                }
            }
        }
    }

    public void OnUpgradePut(UpgradeController uc,Upgrade upg,int slot)
    {
        if (uc.gameObject.CompareTag("Spaceship"))
        {
            GameObject upgObject = upgradeUI[slot];

            if (slot >= 0)
            {

                Image img = upgObject.transform.Find("Button").GetComponent<Image>();
                img.sprite = upg.sprite;
                img.color = Color.white;
                upgObject.GetComponentInChildren<Text>().text = upg.level.ToString();

            }
        }
    }

    public void OnUpgradeRemoved(UpgradeController uc,Upgrade upg,int slot)
    {
        if (uc.gameObject.CompareTag("Spaceship"))
        {
            GameObject upgObject = upgradeUI[slot];

            if (slot >= 0)
            {
                Image img = upgObject.transform.Find("Button").GetComponent<Image>();
                img.sprite = null;
                img.color = new Color(0, 0, 0, 0);
                upgObject.GetComponentInChildren<Text>().text = string.Empty;
            }
        }
    }

    public void ApplyPurchase()
    {

        if (currentController != null && upgrade != null)
        {
            currentController.PlaceUpgrade(upgrade);
            currentController = null;
            upgrade = null;
            ClosePurchaseWindow();

        }
    }
    public void ClosePurchaseWindow()
    {
        purchaseWindow.SetActive(false);
    }

    private void OnDisable()
    {
        UpgradeController.onUpgradePut -= OnUpgradePut;
        UpgradeController.onUpgradeRemoved -= OnUpgradeRemoved;

    }
}
