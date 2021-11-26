using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInv : MonoBehaviour
{
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new UpgradeInventory();
    }
    
    public void AddUpgradeVisual(string upgradeName, Sprite sprite)
    {
        inventory.AddOre(new OreStack(upgradeName, 1, sprite));
    }
}
