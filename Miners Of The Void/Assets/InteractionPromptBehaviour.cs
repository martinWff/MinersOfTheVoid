using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionArea))]
public class InteractionPromptBehaviour : MonoBehaviour
{
    [SerializeField]private InteractionArea interactionArea;
    public KeybindController keybind;


    private void Awake()
    {
        interactionArea = GetComponent<InteractionArea>();
    }

    public void OnEnterArea(GameObject player)
    {
        keybind.SetPosition(transform.position + interactionArea.uIKeyBindPosition);
        keybind.Show(true);
    }
    public void OnExitArea(GameObject player)
    {
        keybind.Show(false);
    }
    public void OnStayArea(GameObject player)
    {
        keybind.SetPosition(transform.position + interactionArea.uIKeyBindPosition);
    }
}
