using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryBehaviour : MonoBehaviour
{
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {

        //   SaveManager.saveStarted += OnSaved;
        //  SaveManager.saveLoaded += OnLoaded;

        if (inventory == null)
        {
            inventory = new Inventory();
        }

    }

  /*  public void OnSaved(SavedData saveData)
    {

       Dictionary<string,OreStack> inventoryTable = inventory.GetOres();
        saveData.inventory = new Dictionary<string, int>();
       foreach (KeyValuePair<string,OreStack> ores in inventoryTable)
        {
            saveData.inventory.Add(ores.Key,ores.Value.amount);
        }
     
    }
    public void OnLoaded(SavedData saveData)
    {
        Dictionary<string, int> inventoryTable = saveData.inventory;
        inventory.Reset();

        foreach (KeyValuePair<string,int> inv in inventoryTable)
        {
           inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName(inv.Key).GetOreStack(inv.Value));
        }

    }*/

    public bool AddOre(OreStack stack)
    {
        return inventory.AddOre(stack);
    }


}
