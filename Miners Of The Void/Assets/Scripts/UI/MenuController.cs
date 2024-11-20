using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuController : MonoBehaviour
{
    public UnityEvent onClose;
    public UnityEvent onOpen;

    private void OnEnable()
    {
        onOpen?.Invoke();
    }

    public void Close()
    {
        MenuManager.instance.DeactivateSubPanel();
    }

    private void OnDisable()
    {
        onClose?.Invoke();
    }
}
