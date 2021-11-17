using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefineryInventory : MonoBehaviour
{
    public Inventory inventory;


    public Contract oreContract;
    InventoryController inventoryController;
    public Sprite goldSprite;
    public Sprite ironSprite;
    public Sprite copperSprite;

    //public ContractGenerator contractGenerator;
    public Contract currentContract;

    //Refine
    Queue<string> myQueue;
    float timer = 0;
    private void Awake()
    {
        inventoryController = GetComponent<InventoryController>();
        Debug.Log(inventoryController.slotPrefab);
        inventory = new Inventory();
        
        myQueue = new Queue<string>();
    }
    void Start()
    {
        inventory.AddOre(new OreStack("Iron", 1,ironSprite));
        inventory.AddOre(new OreStack("Gold", 1, goldSprite));
        inventory.AddOre(new OreStack("Copper", 1, copperSprite));
    }
    private void Update()
    {
        
        if (!myQueue.IsEmpty())
        {
            if(timer <= 0)
            {
                timer = 5;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }


    public void Refine(string name)
    {
        myQueue.Enqueue(name);
        
    }
   
}
