using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatsController : MonoBehaviour
{
    public bool human = true;

    public GameObject target;

    public PersistentData persistentData;

    [SerializeField] Toggle immortalityToggle;

    // Start is called before the first frame update
    void Start()
    {
        immortalityToggle.isOn = persistentData.immortality;
    }

    public void OnImortalityToggled(bool immortality)
    {
        Health health = target.GetComponent<Health>();

        health.immortality = immortality;

        persistentData.immortality = immortality;

    }

    
    public void OnClickOres()
    {
        InventoryBehaviour inventory = target.GetComponent<InventoryBehaviour>();

        foreach (OreResourceObject oreResourceObject in OreManager.instance.ores)
        {
            foreach (MaterialResourceObject material in oreResourceObject.materialResourceObjects)
            {
                inventory.AddOre(material.GetOreStack(100));
            }
        }
    }

    public void OnBipsInputSubmited(string bips)
    {
        int money;
        int.TryParse(bips, out money);
        persistentData.bips = money;

    }
}
