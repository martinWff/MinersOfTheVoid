using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionArea))]
public class InteractionPromptBehaviour : MonoBehaviour
{
    public InteractionArea interactionArea;
    public KeybindController keybind;
    private bool isPlayerInside;
    
    public void OnEnterArea()
    {
        isPlayerInside = true;
        keybind.SetPosition(transform.position + interactionArea.uIKeyBindPosition);
        keybind.Show(true);
    }
    public void OnExitArea()
    {
        isPlayerInside = false;
        keybind.Show(false);
    }
    public void OnStayArea()
    {
        keybind.SetPosition(transform.position + interactionArea.uIKeyBindPosition);
    }
}
