using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refinery : MonoBehaviour
{
    public GameObject player;
    public GameObject NPC;
    public GameObject menu;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseMenu()
    {
        
        MenuManager.instance.DeactivatePanel();

    }
}
