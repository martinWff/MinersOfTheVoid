using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIController : MonoBehaviour
{
    public List<GameObject> upgradeUI = new List<GameObject>(4);
    public UpgradeController controller;
   
    public void OnUpgradePut(Upgrade upg,int slot)
    {
        GameObject upgObject = upgradeUI[slot];
        if (slot >= 0)
        {
            Image img = upgObject.GetComponentInChildren<Image>();
            img.sprite = upg.sprite;
            img.color = Color.white;
            upgObject.GetComponentInChildren<Text>().text = upg.level.ToString();
        }
    }
}
