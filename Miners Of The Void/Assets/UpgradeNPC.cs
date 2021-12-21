using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionArea))]
public class UpgradeNPC : MonoBehaviour
{
    public GameObject panel;
    public Transform canvas;
    // Start is called before the first frame update
    void Start()
    {

    }

   
    private void Interact(GameObject player)
    {
        GameObject tab = Instantiate(panel, canvas);
        UpgradeUIController uiController = tab.GetComponentInChildren<UpgradeUIController>();
        UpgradeController controller = player.GetComponent<UpgradeController>();
        Debug.Log(controller);
        controller.onUpgradePut.AddListener(uiController.OnUpgradePut);
    }

   

    // Update is called once per frame
    public void OnInteractionAreaStay(GameObject player)
    {
        if (Input.GetButtonDown("Interaction"))
        {
            Interact(player);
        }
    }
/*    private void OnTriggerStay2D(Collider2D player)
    {
        Debug.Log("staying");
        if (Input.GetButtonDown("Interaction"))
        {
            Interact(player.gameObject);
        }
    }*/
}
