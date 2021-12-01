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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInside && !disabled && Input.GetButtonDown("Interaction"))
        {

            disabled = true;
            
     
            prefab.GetComponent<ContractBoardController>().contractNPC = this;
            prefab.SetActive(true);
            
        }
    }

    public void OnEnterArea()
    {
        isPlayerInside = true;
        keybind.SetPosition(interaction.uIKeyBindPosition);
        keybind.Show(true);
    }
    public void OnExitArea()
    {
        isPlayerInside = false;
        keybind.Show(false);
    }
}
