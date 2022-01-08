using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSkins : MonoBehaviour
{
    public GameObject player;
    public GameObject prefab;
    private GameObject openedMenu;
    private bool menuIsOpen = false;
   

    // Update is called once per frame
    void Update()
    {
        if (Maths.Distance(player.transform.position, gameObject.transform.position) < 3 && Input.GetKeyDown(KeyCode.F) && !menuIsOpen)
        {
            openedMenu = Instantiate(prefab);
            player.GetComponent<CharacterMovement>().enabled = false;
            menuIsOpen = true;
        }
    }
    public void CloseMenu()
    {
        Destroy(openedMenu);
        player.GetComponent<CharacterMovement>().enabled = true;
        menuIsOpen = false;
    }
}
