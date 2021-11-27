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
    
    public void AddUpgradeVisual(string upgradeName, Sprite sprite)
    {
        inventory.AddOre(new OreStack(upgradeName, 1, sprite));
    }
    public void OnStart(InventoryController inv)
    {
        inv.AttachInventory(inventory);
    }
}