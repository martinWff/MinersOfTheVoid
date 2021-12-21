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
            upgObject.GetComponentInChildren<Image>().sprite = upg.sprite;
            upgObject.GetComponentInChildren<Text>().text = upg.level.ToString();
        }
    }
}
