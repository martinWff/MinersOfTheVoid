using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    GameObject NPC;
    static GameObject player;
    public GameObject imagem;
    public bool upgradeplaced;
    public GameObject menu;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        NPC = GameObject.Find("UpgradeNPC");

    }
}
