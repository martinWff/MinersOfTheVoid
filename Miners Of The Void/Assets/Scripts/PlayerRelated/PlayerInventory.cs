using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    public static Inventory staticInventory;
    // Start is called before the first frame update
    void Awake()
    {
        if (staticInventory == null)
        {
            staticInventory = new Inventory();

            SaveManager.saveStarted += OnSaved;
            SaveManager.saveLoaded += OnLoaded;
        }
      //  inventory = staticInventory;



        
    }


    public void OnInventoryControllerInitialized(InventoryController ic)
    {
        ic.AttachInventory(staticInventory);
    }

    public void OnSaved(SavedData saveData)
    {

       Dictionary<string,OreStack> inventoryTable = staticInventory.GetOres();
        saveData.inventory = new Dictionary<string, int>();
       foreach (KeyValuePair<string,OreStack> ores in inventoryTable)
        {
            saveData.inventory.Add(ores.Key,ores.Value.amount);
        }
     
    }
    public void OnLoaded(SavedData saveData)
    {
        Dictionary<string, int> inventoryTable = saveData.inventory;
        staticInventory.Reset();

        foreach (KeyValuePair<string,int> inv in inventoryTable)
        {
           staticInventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName(inv.Key).GetOreStack(inv.Value));
        }

    }





}
