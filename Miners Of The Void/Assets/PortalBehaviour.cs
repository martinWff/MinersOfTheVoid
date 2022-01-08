using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InteractionArea))]
public class PortalBehaviour : MonoBehaviour
{
    public string action;
    public int sceneId;
    public InteractionArea interaction;
    [SerializeField] bool isPlayerInside;
    GameObject spaceship;
    // Start is called before the first frame update
    void Awake()
    {
        interaction = GetComponent<InteractionArea>();
    }

   
    private void Update()
    {
        if (isPlayerInside)
        {
            if (Input.GetButtonDown("Interaction"))
            {
                SceneManager.LoadScene(sceneId);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
            spaceship = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
            spaceship = null;
        }
    }
   

}
