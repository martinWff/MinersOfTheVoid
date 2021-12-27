using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionArea))]
public class UpgradeNPC : MonoBehaviour
{
    public GameObject panel;
    public Transform canvas;
    public InteractionArea interactionArea;
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
        UpgradeController controller = player.GetComponent<UpgradeController>();
        Debug.Log(controller);
        controller.onUpgradePut.AddListener(uiController.OnUpgradePut);
    }
}
