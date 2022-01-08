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
    public Text purchaseText;
    public Inventory invPlayer;

    private void Start()
    {
        invPlayer = PlayerInventory.staticInventory;
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
        //Em vez de colocar assim, pode ter 1 parametro no upgrade com 1 string[] costs ou assim. Depois é só inserir aq
        string[] materials = new string[3];
        materials.SetValue("material1", 0);
        materials.SetValue("material2", 1);
        materials.SetValue("material3", 2);
        if (currentController != null && upgrade != null && AddCost(materials))
        {
            
            currentController.PlaceUpgrade(upgrade);
            currentController = null;
            upgrade = null;
            ClosePurchaseWindow();

        }
    }

    public void ApplyData()
    {
        if (currentController != null && upgrade != null)
        {
            string ptext = purchaseText.text;

            purchaseText.text = ptext.Replace("{upgrade}", upgrade.upgradeName).Replace("{cost}", "(undefined)");

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
    public bool AddCost(string[] materials)      
    {
        int level = upgrade.level;
        if (invPlayer.GetOreAmount(materials[0]) >= level && invPlayer.GetOreAmount(materials[1]) >= level  && invPlayer.GetOreAmount(materials[3]) >= level && SavePlayerStats.bips >= (200 * Mathf.Pow(1.3f, level)))
        {

            invPlayer.RetrieveAmount(materials[0], level);
            invPlayer.RetrieveAmount(materials[1], level);
            invPlayer.RetrieveAmount(materials[3], level);
            SavePlayerStats.bips -= (int)(200 * Mathf.Pow(1.3f, level));
            //notices.text = "Aquiered!";
            return true;
        }
        else
        {
            //notices.text = "Not enough ore: " + material1 + ":" + invPlayer.inventory.GetOreAmount(material1) + "; " + material2 + ":" + invPlayer.inventory.GetOreAmount(material2) + material3 + ":" + invPlayer.inventory.GetOreAmount(material3) + ", you need at least " + level + 1 + " of each and " + 200 * (level + 1) + "bips";
            return false;
        }
    }
}
