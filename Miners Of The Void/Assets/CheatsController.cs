using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatsController : MonoBehaviour
{

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

    public void OnImortalityToggled(bool imortality)
    {

    }

    public void OnFastRefineryToggled(bool fastRefinery)
    {

    }
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

    }
}
