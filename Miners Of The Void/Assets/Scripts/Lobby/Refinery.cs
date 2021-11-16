using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refinery : MonoBehaviour
{
    GameObject player;
    GameObject NPC;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        NPC = GameObject.Find("RefineryNPC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseMenu()
    {
        NPC.GetComponent<NPCMenus>().openMenu = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        menu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 500);
    }
}
