using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefineryInventory : MonoBehaviour
{
    public Inventory inventory;


    public Contract oreContract;
    InventoryController inventoryController;
    public Sprite goldOreSprite;
    public Sprite ironOreSprite;
    public Sprite copperOreSprite;
    public Sprite goldNuggetSprite;
    public Sprite ironNuggetSprite;
    public Sprite copperNuggetSprite;

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
        InventoryController.onInventoryControllerCreated += InventoryController_onInventoryControllerCreated;
        myQueue = new Queue<string>();
    }
    void Start()
    {
        inventory.AddOre(new OreStack("Iron", 3,ironOreSprite));
        inventory.AddOre(new OreStack("Gold", 2, goldOreSprite));
        inventory.AddOre(new OreStack("Copper", 5, copperOreSprite));
    }
    private void Update()
    {
        
        if (!myQueue.IsEmpty())
        {
            
            if(timer <= 0)
            {
                Debug.Log("Entrou no if");
                string ore = myQueue.Dequeue().Data;

                if (ore == "Iron") inventory.AddOre(new OreStack("Iron Nugget", 1, ironNuggetSprite));
                else if (ore == "Copper") inventory.AddOre(new OreStack("Copper Nugget", 1, copperNuggetSprite));
                else if (ore == "Gold") inventory.AddOre(new OreStack("Gold Nugget", 1, goldNuggetSprite));
                timer = 5;
            }
            else
            {
                timer -= Time.deltaTime;
            }

        }
    }


    public void Refine(string name, int quantity)
    {
        if (quantity >= 3)
        {
            Debug.Log("Dentro da Queue: " + name);
            if (myQueue.IsEmpty()) timer = 5;
            myQueue.Enqueue(name);
            inventory.RetrieveAmount(name, 3);
        }
        else Debug.Log("You don't have enough "+name);

    }
    
    private void InventoryController_onInventoryControllerCreated(InventoryController inventoryController)
    {
        inventoryController.AttachInventory(inventory);
        
    }

}
