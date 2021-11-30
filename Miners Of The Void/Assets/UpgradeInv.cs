using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInv : MonoBehaviour
{
    
    Inventory inventory;
    // Start is called before the first frame update
    void Awake()
    {
        inventory = new UpgradeInventory();
    }
    
    public void AddUpgradeVisual(string upgradeName, float level ,Sprite sprite)
    {
        if (!inventory.ContainsOre(upgradeName) || inventory.GetOreAmount(upgradeName) <= 0)
           inventory.AddOre(new OreStack(upgradeName, (int)level + 1, sprite));
        else
        {
            inventory.AddOre(new OreStack(upgradeName, 1, sprite));
        }
    }
    public void RemoveUpgrade(string upgradeName, float level)
    {
        inventory.RetrieveAmount(upgradeName, (int)level);
        
    }
    public bool ContainsOre(string upgradeName)
    {
        if (inventory.ContainsOre(upgradeName)) return true;
        else return false;
    }
    public void RemoveUpgrade(string UpgradeName) 
    {
        inventory.RetrieveAmount(UpgradeName, 6);
    } 
    public void OnStart(InventoryController inv)
    {
        inv.AttachInventory(inventory);
    }
}
