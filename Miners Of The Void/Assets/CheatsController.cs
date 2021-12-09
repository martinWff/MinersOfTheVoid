using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatsController : MonoBehaviour
{
    public bool human = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
        
    }

    /*public void OnImortalityToggled(bool immortality)
    {
        
        Debug.Log(immortality);
        SavePlayerStats.immortality = immortality;
        if (human)
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().immortality = immortality; 
        else
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().immortality = immortality;

    }*/

    
    public void OnClickOres()
    {
        foreach (OreResourceObject oreResourceObject in OreManager.instance.ores)
        {
            foreach (MaterialResourceObject material in oreResourceObject.materialResourceObjects)
            {
                PlayerInventory.staticInventory.AddOre(material.GetOreStack(100));
            }
        }
    }

    public void OnBipsInputSubmited(string bips)
    {
        int money;
        int.TryParse(bips, out money);
        SavePlayerStats.bips = money;
        Debug.Log(SavePlayerStats.bips);
    }
}
