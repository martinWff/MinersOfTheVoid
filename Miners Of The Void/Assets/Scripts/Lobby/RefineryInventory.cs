using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefineryInventory : MonoBehaviour
{
    


    //Sprites
    public Sprite goldOreSprite;
    public Sprite ironOreSprite;
    public Sprite copperOreSprite;
    public Sprite goldNuggetSprite;
    public Sprite ironNuggetSprite;
    public Sprite copperNuggetSprite;

    //Class related stuff
    public OreStack oreStack;
    public Inventory inventory;
    public Contract oreContract;
    InventoryController inventoryController;



    //Gameobjects to select
    public Image progress;
    public Image inputItem;
    public Image outputItem;


    //Refine
    Queue<MaterialID> myQueue;
    OreResourceObject ore;

    MaterialResourceObject next;
    MaterialResourceObject prev;


    //Unclassified variables
    float timer = 0;
    private bool imageIsInSlot = false;

    private void Awake()
    {
        inventoryController = GetComponent<InventoryController>();
        inventory = new Inventory();
        InventoryController.onInventoryControllerCreated += InventoryController_onInventoryControllerCreated;
        myQueue = new Queue<MaterialID>();
        
    }
    void Start()
    {
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Iron").GetOreStack(10));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Copper").GetOreStack(10));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Gold").GetOreStack(10));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Osmium").GetOreStack(10));
    }
    private void Update()
    {

        if (prev !=null)
        {
            
            if(timer <= 0)
            {

                inventory.AddOre(new OreStack(next.resourceName, 1, next.sprite));
                
                inputItem.color = new Color(255, 255, 255, 0);
                outputItem.color = new Color(255, 255, 255, 0);
                timer = 5;
                prev = null;
                progress.fillAmount = 0;
                imageIsInSlot = false;
            }
            else
            {
                timer -= Time.deltaTime;
                progress.fillAmount += Time.deltaTime * 0.2f;  

            }
            if (Input.GetKeyDown(KeyCode.P)) timer = 0;
        }
        if (!imageIsInSlot && !myQueue.IsEmpty())
        {
            MaterialID id = myQueue.Dequeue().Data;            
            prev = OreManager.instance.GetOreMaterialByMaterialName(id.name, out id.index);
            OreResourceObject oreResource = OreManager.instance.GetOreResourceFromMaterialName(id.name);
            next = oreResource.materialResourceObjects[id.index + 1];
            imageIsInSlot = true;
            inputItem.sprite = prev.sprite;
            outputItem.sprite = next.sprite;
            inputItem.color = new Color(255, 255, 255, 255);
            outputItem.color = new Color(255, 255, 255, 255);
            timer = 5;
            imageIsInSlot = true;
        }
        
        
    }

   /* public void CreateRefineryItem(GameObject prefabInput, GameObject prefabOutput)
    {
       
            inputItem = Instantiate(prefabInput, inputRef.transform);
            outputItem = Instantiate(prefabOutput, outputRef.transform);
        
        
    }*/

            public void Refine(string name,int quantity)
    {
        if (quantity >= 3)
        {
            int index = 0;
            Debug.Log("Dentro da Queue: " + name);
            if (myQueue.IsEmpty()) timer = 5;
            Debug.Log(name + index);
            MaterialResourceObject mat = OreManager.instance.GetOreMaterialByMaterialName(name, out index);
            myQueue.Enqueue(new MaterialID(name,index));
            inventory.RetrieveAmount(name, 3);
        }
        else Debug.Log("You don't have enough "+name);

    }
    
    private void InventoryController_onInventoryControllerCreated(InventoryController inventoryController)
    {
        inventoryController.AttachInventory(inventory);
    }

}
public class MaterialID
{
    public string name;
    public int index;

    public MaterialID(string name,int index)
    {
        this.name = name;
        this.index = index;
    }
}
