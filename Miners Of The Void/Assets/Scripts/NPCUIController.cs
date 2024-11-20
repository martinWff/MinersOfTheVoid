using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCUIController : MonoBehaviour, IInteractable
{
    public GameObject panel;
    
    public void Interact(GameObject player)
    {
        MenuManager.instance.ActivatePanel(panel);
    }
}
