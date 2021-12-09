using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionArea))]
public class ContractNPC : MonoBehaviour
{
    public GameObject prefab;
    public GameObject targetCanvas;
    bool isPlayerInside;
    public KeybindController keybind;
    public InteractionArea interaction;
    [HideInInspector]public bool disabled;
    // Start is called before the first frame update
    void Awake()
    {
        
         ContractCreator.onContractGenerated += prefab.GetComponent<ContractBoardController>().ContractCreator_onContractGenerated;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInside && !disabled && Input.GetButtonDown("Interaction"))
        {

            disabled = true;
            
     
            prefab.GetComponent<ContractBoardController>().contractNPC = this;
            prefab.SetActive(true);
            keybind.Show(false);
            
        }
    }

    public void OnEnterArea()
    {
        isPlayerInside = true;
        keybind.SetPosition(transform.position+interaction.uIKeyBindPosition);
        keybind.Show(true);
    }
    public void OnExitArea()
    {
        isPlayerInside = false;
        keybind.Show(false);
    }
    public void OnStayArea()
    {
        keybind.SetPosition(transform.position + interaction.uIKeyBindPosition);
    }
}
