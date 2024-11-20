using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private MenuController menuOpen;

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
                DeactivatePanel();
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
        if (menuOpen)
            return;

        menuOpen = element.GetComponent<MenuController>();
        element.SetActive(true);

        movementController.disableMovement = true;
    }

    public void DeactivatePanel()
    {
        if (menuOpen != null)
        {
            menuOpen.gameObject.SetActive(false);

            movementController.disableMovement = false;

            menuOpen = null;
        }
    }

    public bool IsMenuOpen()
    {
        return menuOpen != null;
    }
}