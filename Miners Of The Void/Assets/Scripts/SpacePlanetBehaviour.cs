using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpacePlanetBehaviour : MonoBehaviour, IInteractable
{
    public string planetName;
    public bool hasBlockade;
    public int sceneId;

    // Start is called before the first frame update
    void Awake()
    {
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
        
    }

    public void Interact(GameObject instigator)
    {
        SceneManager.LoadScene(sceneId);
    }

}
