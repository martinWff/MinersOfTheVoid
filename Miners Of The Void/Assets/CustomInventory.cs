using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInventory : MonoBehaviour
{
    public Inventory inventory;
    private bool once;
    // Start is called before the first frame update
    private void Awake()
    {
        inventory = new Inventory();
    }


    void Start()
    {
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Iron").GetOreStack(8));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Gold").GetOreStack(8));

    }


    public void OnInventoryControllerInitialized(InventoryController ic)
    {
        ic.AttachInventory(inventory);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
