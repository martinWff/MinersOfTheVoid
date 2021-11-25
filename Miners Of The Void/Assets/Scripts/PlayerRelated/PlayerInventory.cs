using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    public GameObject inventoryTab;
    // Start is called before the first frame update
    void Awake()
    {

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        inventory = new Inventory();
      
           
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryTab.SetActive(!inventoryTab.activeSelf);
        }
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        inventoryTab = GameObject.FindGameObjectWithTag("InventoryPanel");
       
    }

    public void OnInventoryControllerInitialized(InventoryController ic)
    {
        ic.AttachInventory(inventory);
    }


}
