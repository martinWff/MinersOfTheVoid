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
    private bool imageIsInSlot = false;

    //iron
    public GameObject ironOrePrefab;
    public GameObject ironNuggetPrefab;
    //copper
    public GameObject copperOrePrefab;
    public GameObject copperNuggetPrefab;
    //gold
    public GameObject goldOrePrefab;
    public GameObject goldNuggetPrefab;



    GameObject inputItem;
    GameObject outputItem;
    string ore;

    //public ContractGenerator contractGenerator;
    public Contract currentContract;

    //Refine
    Queue<string> myQueue;
    float timer = 0;
    GameObject inputRef;
    GameObject outputRef;
    private void Awake()
    {
        inventoryController = GetComponent<InventoryController>();
        Debug.Log(inventoryController.slotPrefab);
        inventory = new Inventory();
        InventoryController.onInventoryControllerCreated += InventoryController_onInventoryControllerCreated;
        myQueue = new Queue<string>();
        inputRef = GameObject.FindGameObjectWithTag("RefineryInput");
        outputRef = GameObject.FindGameObjectWithTag("RefineryOutput");
        
    }
    void Start()
    {
        inventory.AddOre(new OreStack("Iron", 6,ironOreSprite));
        inventory.AddOre(new OreStack("Gold", 3, goldOreSprite));
        inventory.AddOre(new OreStack("Copper", 5, copperOreSprite));
    }
    private void Update()
    {

        if (ore !=null)
        {
            
            if(timer <= 0)
            {
                Debug.Log("Entrou no if");
                if (ore == "Iron") inventory.AddOre(new OreStack("Iron Nugget", 1, ironNuggetSprite));
                else if (ore == "Copper") inventory.AddOre(new OreStack("Copper Nugget", 1, copperNuggetSprite));
                else if (ore == "Gold") inventory.AddOre(new OreStack("Gold Nugget", 1, goldNuggetSprite));
                imageIsInSlot = false;
                Debug.Log(imageIsInSlot);
                ore = null;
                Destroy(inputItem);
                Destroy(outputItem);
                timer = 5;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        if (!imageIsInSlot && !myQueue.IsEmpty())
        {
            ore = myQueue.Dequeue().Data;
            if (ore == "Iron") CreateRefineryItem(ironOrePrefab, ironNuggetPrefab);
            if (ore == "Copper") CreateRefineryItem(copperOrePrefab, copperNuggetPrefab);
            if (ore == "Gold") CreateRefineryItem(goldOrePrefab, goldNuggetPrefab);
            imageIsInSlot = true;
        }
        
    }

    public void CreateRefineryItem(GameObject prefabInput, GameObject prefabOutput)
    {
       
            inputItem = Instantiate(prefabInput, inputRef.transform);
            outputItem = Instantiate(prefabOutput, outputRef.transform);
        
        
    }

    public void RefineFunction(string oreInput, string oreOutput, GameObject prefabInput, GameObject prefabOutput,Sprite sprite, bool starting)
    {
        if (starting)
        {
            inputItem = Instantiate(prefabInput, inputRef.transform);
            outputItem = Instantiate(prefabOutput, outputRef.transform);
        }
        if (!starting)
        {
            Destroy(inputItem);
            Destroy(outputItem);
            inventory.AddOre(new OreStack(oreOutput, 1, sprite));
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
