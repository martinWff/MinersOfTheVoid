using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryObserver : MonoBehaviour
{
    private PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
 
    }

    public void InventoryControllerInitialized(InventoryController ic)
    {

        ic.AttachInventory(playerInventory.inventory);
    }
}
