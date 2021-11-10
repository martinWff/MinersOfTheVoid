using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform inventoryPanelTransform;

    public Dictionary<string,GameObject> slotList = new Dictionary<string, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        Inventory.onInventoryChanged += SpawnSlot;
    }

    public void SpawnSlot(Inventory inv,string oreName,int amount,bool opt)
    {
        if (opt) return;
        if (inv.GetOreAmount(oreName) > 0 && !slotList.ContainsKey(oreName)) {

          GameObject obj = Instantiate(slotPrefab, inventoryPanelTransform);
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
