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
        saveData.inventory = staticInventory;
    }
    public void OnLoaded(SavedData saveData)
    {
        staticInventory = saveData.inventory;
    }

}
