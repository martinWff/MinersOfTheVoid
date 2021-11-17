using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefineryInventory : MonoBehaviour
{
    public Inventory inventory;


    public Contract oreContract;

    public Sprite goldSprite;
    public Sprite ironSprite;
    public Sprite copperSprite;

    public ContractGenerator contractGenerator;
    public Contract currentContract;
    private void Awake()
    {
        inventory = new Inventory();
        InventoryController.onInventoryControllerCreated += InventoryController_onInventoryControllerCreated;
    }
    void Start()
    {
        
        inventory.AddOre(new OreStack("Iron", 1,ironSprite));
        inventory.AddOre(new OreStack("Gold", 1, goldSprite));
        inventory.AddOre(new OreStack("Copper", 1, copperSprite));
    }
    public void Refine()
    {

    }
    
    private void InventoryController_onInventoryControllerCreated(InventoryController inventoryController)
    {
        inventoryController.AttachInventory(inventory);
    }

}
