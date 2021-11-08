using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//DEPRECATED
public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform inventoryPanelTransform;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.onInventoryChanged += SpawnSlot;
    }

    // Update is called once per frame
    void Update()
    {

    }

   

    public void SpawnSlot(Inventory inv, string oreName, int amount,bool addedOnContract)
    {
        if (amount > 0)
        {
            Instantiate(slotPrefab, inventoryPanelTransform);
        }
    }
}
