using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPersistent : MonoBehaviour
{
    public InventoryBehaviour inventoryBehaviour;
    public PersistentData persistentData;
    // Start is called before the first frame update
    void Start()
    {
        inventoryBehaviour.inventory = persistentData.inventory;
    }

    private void OnDestroy()
    {
        persistentData.inventory = inventoryBehaviour.inventory;
    }
}
