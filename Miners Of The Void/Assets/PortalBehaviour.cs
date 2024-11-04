using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour, IInteractable
{
    public int sceneId;

    public void Interact(GameObject instigator)
    {
        SceneManager.LoadScene(sceneId);
    }
}
