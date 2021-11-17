using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public delegate void InventoryControllerCreated(InventoryController inventoryController);
    public static event InventoryControllerCreated onInventoryControllerCreated;

    public Dictionary<string, GameObject> slotList = new Dictionary<string, GameObject>();




    // Start is called before the first frame update
    void Start()
    {
        Inventory.onInventoryChanged += SpawnSlot;
        if (inventory != null)
        {
            Populate();
        }
        onInventoryControllerCreated?.Invoke(this);
    }

    public void AttachInventory(Inventory inv)
    {
        inventory = inv;
        Populate();
    }

  /*  private void OnEnable()
    {
        
        

        

    }*/

    public void Populate()
    {
        
        foreach (KeyValuePair<string, OreStack> o in inventory.GetOres()) {
            if (inventory.GetOreAmount(o.Key) > 0 && !slotList.ContainsKey(o.Key))
            {

                GameObject obj = Instantiate(slotPrefab, transform);
                OreStack oreStack = inventory.GetOreStack(o.Key);

                SlotController slotController = obj.GetComponent<SlotController>();
                slotController.SetContent(oreStack);
                slotList.Add(o.Key, obj);

            }
            if (inventory.GetOreAmount(o.Key) <= 0 && slotList.ContainsKey(o.Key))
            {
                Destroy(slotList[o.Key]);
                slotList.Remove(o.Key);
            }
        }
   

}


    private void OnDisable()
    {
        Inventory.onInventoryChanged -= SpawnSlot;
    }
    private void OnDestroy()
    {
        Inventory.onInventoryChanged -= SpawnSlot;
    }


    public void SpawnSlot(Inventory inv,string oreName,int amount)
    {
        if (inv.GetOreAmount(oreName) > 0 && !slotList.ContainsKey(oreName)) {

          GameObject obj = Instantiate(slotPrefab, transform);
          Transform btn = obj.transform.Find("Button");
            
           OreStack oreStack = inv.GetOreStack(oreName);

          SlotController slotController = obj.GetComponent<SlotController>();
          slotController.SetContent(oreStack);
         //     .oreStack = oreStack
          btn.GetComponent<Image>().sprite = oreStack.sprite;
          slotList.Add(oreName,obj);

        }
        if (inv.GetOreAmount(oreName) <= 0 && slotList.ContainsKey(oreName))
        {
            Destroy(slotList[oreName]);
            slotList.Remove(oreName);
        }
        
    }
}
