using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InteractionArea))]
public class SpacePlanetBehaviour : MonoBehaviour
{
    public string planetName;
    public bool hasBlockade;
    public int sceneId;
    public InteractionArea interaction;
   [SerializeField] bool isPlayerInside;
    GameObject spaceship;
    public KeybindController keybind;
    // Start is called before the first frame update
    void Awake()
    {
        interaction = GetComponent<InteractionArea>();
    }

    /*  private void OnTriggerStay2D(Collider2D collision)
      {
          if (collision.gameObject.CompareTag("Spaceship"))
          {
              if (Input.GetButtonDown("Interaction"))
              {
                  if (!hasBlockade)
                  {
                      Debug.Log("Planet Interaction");
                      collision.gameObject.GetComponent<Animator>().SetBool("isEnteringPlanet",true);
                      StartCoroutine(GoToScene());

                  } else
                  {
                      Debug.Log("PLANET IS UNDER A BLOCKADE");
                  }
              }
          }
      }*/
    private void Update()
    {
        if (isPlayerInside)
        {
            if (Input.GetButtonDown("Interaction"))
            {
                if (!hasBlockade)
                {
                    Debug.Log("Planet Interaction");
                    Animator animator = spaceship.GetComponent<Animator>();
                    animator.SetInteger("sceneId", sceneId);
                    animator.SetTrigger("isEnteringPlanet");

                }
                else
                {
                    Debug.Log("PLANET IS UNDER A BLOCKADE");
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spaceship"))
        {
            isPlayerInside = true;
            spaceship = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spaceship"))
        {
            isPlayerInside = false;
            spaceship = null;
        }
    }
    public void PromptKeybind()
    {
        if (keybind != null) {
            keybind.SetDetail("Enter " + planetName);
            keybind.SetPosition(transform.position + new Vector3(0.5f, 0.5f));
            keybind.Show(true);
        }
    }
    public void ClearPromptKeybind()
    {
        if (keybind != null)
        {
            keybind.Show(false);
        }
    }

}
