using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTester : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory inventory = new Inventory();
    public Sprite ironSprite;
    public Contract c;
    void Start()
    {
        FindObjectOfType<InventoryManager>().inventory = inventory;
        inventory.AddOre(new OreStack("Iron",5,ironSprite));
        
        Debug.Log(inventory.GetOreAmount("Iron"));
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
