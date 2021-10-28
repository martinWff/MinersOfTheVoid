using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    GameObject NPC;
    static GameObject player;
    public GameObject imagem;
    public bool upgradeplaced;
    private static int a = 0;
    GameObject slot1;
    static PlayerMovement player2;
    
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        NPC = GameObject.Find("UpgradeNPC");
        player2 = player.GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    public void CloseMenu()
    {
        
        player.GetComponent<PlayerMovement>().enabled = true;
        NPC.GetComponent<NPCMenus>().openMenu = false;
        Destroy(gameObject); 
        
    }


}
