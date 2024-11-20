using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerClickHandler
{
    public int slotIndex;
    public UpgradeEquipUIController upgradeUIController;
    void Start()
    {
        
    }

    public void RemoveUpgrade() 
    {
        upgradeUIController.controller.RemoveUpgradeAt(slotIndex);
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RemoveUpgrade();
    }
}
