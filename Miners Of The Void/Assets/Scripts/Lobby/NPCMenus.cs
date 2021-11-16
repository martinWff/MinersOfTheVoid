using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMenus : MonoBehaviour
{
    private float distance;
    private Transform player;
    private float interaction;
    public GameObject menuPrefab;
    public GameObject canvas;
    private GameObject menu;
    public bool openMenu = false;



    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canvas = GameObject.Find("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        interaction = Input.GetAxis("Interaction");
        distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.position.x, 2) + Mathf.Pow(transform.position.y - player.position.y, 2));
        if (distance < 3 && Input.GetKeyDown("f") && openMenu == false)
        {
            
            menuPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
            player.GetComponent<PlayerMovement>().enabled = false;
            openMenu = true;
        }
        
        
    }
    
}
