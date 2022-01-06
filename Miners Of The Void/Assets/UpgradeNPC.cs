using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionArea))]
public class UpgradeNPC : MonoBehaviour
{
    public GameObject panel;
    public Transform canvas;
    public InteractionArea interactionArea;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (interactionArea.playerInside && Input.GetButtonDown("Interaction"))
        {
            Interact(interactionArea.playerInside);
        }
    }


    private void Interact(GameObject player)
    {
        GameObject tab = Instantiate(panel, canvas);
        UpgradeUIController uiController = tab.GetComponentInChildren<UpgradeUIController>();
        uiController.humanoidController = player.GetComponent<UpgradeController>();
        //  GameObject.FindGameObjectsWithTag("Spaceship");
        //  UpgradeController controller = GameObject.FindGameObjectWithTag("Spaceship").GetComponent<UpgradeController>();
        player.GetComponent<CharacterMovement>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        UpgradeController.onUpgradePut += uiController.OnUpgradePut;
        UpgradeController.onUpgradeRemoved += uiController.OnUpgradeRemoved;        
    }
}
