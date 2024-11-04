using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject instigator);
}

public interface IInteractableInfoHandler
{
    string GetTitle();
}