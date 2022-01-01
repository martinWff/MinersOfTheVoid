using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryObserver : MonoBehaviour
{

   

    public void InventoryControllerInitialized(InventoryController ic)
    {
        Debug.Log("inventory controller initialized");
        ic.AttachInventory(PlayerInventory.staticInventory);
    }

}
