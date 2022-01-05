using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMenus : MonoBehaviour
{
    private float distance;
    private GameObject player;
    private float interaction;
    public GameObject menuPrefab;
    public GameObject canvas;
    private GameObject menu;
    public bool openMenu = false;
    public bool inventoryCon = false;



    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.Find("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        interaction = Input.GetAxis("Interaction");
        distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.y - player.transform.position.y, 2));
        if (distance < 3 && Input.GetKeyDown("f") && openMenu == false)
        {
            menuPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
            player.GetComponent<CharacterMovement>().enabled = false;
           // player.GetComponent<PlayerMovement>().enabled = false;
            openMenu = true;
            if (inventoryCon) 
            {
            //    GameObject.Find("Managers").GetComponent<ContractTest>().enabled = true;
                GameObject.FindGameObjectWithTag("Panel").GetComponent<RectTransform>().anchoredPosition = new Vector3(-173.6333f, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && inventoryCon)
        {
            menuPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 500);
           // if (inventoryCon) GameObject.Find("Managers").GetComponent<ContractTest>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;
            GameObject.FindGameObjectWithTag("Panel").GetComponent<RectTransform>().anchoredPosition = new Vector3(2000,2000, 0);
            openMenu = false;
        }
        
    }
    
}
