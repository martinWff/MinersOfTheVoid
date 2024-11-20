using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Stack<MenuController> menuStack = new Stack<MenuController>();

    public static MenuManager instance;

    public PlayerMovementController movementController;


    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject inventoryPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsMenuOpen())
            {
                DeactivateSubPanel();
            } else
            {
                ActivatePanel(pausePanel);
            }
        }


        if (inventoryPanel != null && Input.GetKeyDown(KeyCode.E) && !IsMenuOpen())
        {
            ActivatePanel(inventoryPanel);
        }
    }

    public void ActivatePanel(GameObject element)
    {
        if (menuStack.Count > 0)
            return;

        ActivateSubPanel(element);

    }

    public void DeactivatePanel()
    {
        while (menuStack.Count > 0)
        {
            MenuController mc = menuStack.Pop();
            mc.gameObject.SetActive(false);
        }

        movementController.disableMovement = false;

    }

    public void ActivateSubPanel(GameObject element)
    {
        MenuController mc = element.GetComponent<MenuController>();
        mc.gameObject.SetActive(true);
        menuStack.Push(mc);

        movementController.disableMovement = true;

    }

    public void DeactivateSubPanel()
    {
        if (menuStack.Count > 0)
        {
            MenuController mc = menuStack.Pop();
            mc.gameObject.SetActive(false);
            
        }

        if (menuStack.Count == 0)
        {
            movementController.disableMovement = false;
        }
    }

    public bool IsMenuOpen()
    {
        return menuStack.Count > 0;
    }
}