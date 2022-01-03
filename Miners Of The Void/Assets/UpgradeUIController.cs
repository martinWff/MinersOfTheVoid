using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIController : MonoBehaviour
{
    public List<GameObject> upgradeUI = new List<GameObject>(4);
    public UpgradeController controller;

    private void Start()
    {
        if (controller != null)
        {
            if (controller.upgradeHolder != null)
            {
                for (int i = 0; i < controller.upgradeHolder.Length; i++)
                {
                    if (controller.upgradeHolder[i] != null)
                    {
                        OnUpgradePut(controller.upgradeHolder[i], i);
                    }
                }
            }
        }
    }

    public void OnUpgradePut(Upgrade upg,int slot)
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

    public void OnUpgradeRemoved(Upgrade upg,int slot)
    {
        GameObject upgObject = upgradeUI[slot];

        if (slot >= 0)
        {
            Image img = upgObject.transform.Find("Button").GetComponent<Image>();
            img.sprite = null;
            img.color = new Color(0,0,0,0);
            upgObject.GetComponentInChildren<Text>().text = string.Empty;
        }
    }
}
