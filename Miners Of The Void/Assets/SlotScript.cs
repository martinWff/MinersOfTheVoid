using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public int slotIndex;
    public UpgradeUIController upgradeUIController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RemoveUpgrade() 
    {
        Debug.Log("Marvel é melhor que Dc");
       
        upgradeUIController.controller.TakeOfUpgrade(slotIndex);
    }
        
}
