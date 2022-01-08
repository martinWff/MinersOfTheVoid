using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSkins : MonoBehaviour
{
    public GameObject player;
    public GameObject prefab;
    private GameObject openedMenu;
    public GameObject canvas;
    public bool menuIsOpen = false;
   

    // Update is called once per frame
    void Update()
    {
        if (Maths.Distance(player.transform.position, gameObject.transform.position) < 3 && Input.GetKeyDown(KeyCode.F) && !menuIsOpen)
        {
            openedMenu = Instantiate(prefab, canvas.transform);
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<CharacterMovement>().enabled = false;
            menuIsOpen = true;
        }
    }
    
}
