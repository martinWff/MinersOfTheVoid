using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeNPC : MonoBehaviour, IInteractable
{
    public GameObject panel;
    public Transform canvas;
    public InteractionArea interactionArea;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Interact(GameObject player)
    {
        MenuManager.instance.ActivatePanel(panel);
        
    }
}
