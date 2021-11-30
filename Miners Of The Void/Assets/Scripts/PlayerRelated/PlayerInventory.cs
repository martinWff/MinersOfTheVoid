using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public static Inventory staticInventory;
    public Inventory inventory;
    // Start is called before the first frame update
    void Awake()
    {
        if (staticInventory == null)
        {
            staticInventory = new Inventory();
        }
        inventory = staticInventory;
    }

    public void OnInventoryControllerInitialized(InventoryController ic)
    {
        ic.AttachInventory(inventory);
    }


}
