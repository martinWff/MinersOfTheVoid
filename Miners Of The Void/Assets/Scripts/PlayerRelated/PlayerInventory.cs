using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    // Start is called before the first frame update
    void Awake()
    {
        inventory = new Inventory();

    }

    public void OnInventoryControllerInitialized(InventoryController ic)
    {
        ic.AttachInventory(inventory);
    }


}
