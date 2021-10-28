using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlanetBehaviour : MonoBehaviour
{
    public string planetName;
    public bool hasBlockade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interaction"))
            {
                if (!hasBlockade)
                {
                    Debug.Log("Planet Interaction");
                    collision.gameObject.GetComponent<Animator>().SetBool("isEnteringPlanet",true);

                } else
                {
                    Debug.Log("PLANET IS UNDER A BLOCKADE");
                }
            }
        }
    }

    private void OnMouseOver()
    {
        
    }

}
