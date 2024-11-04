using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipController : MonoBehaviour, IInteractable
{
    public Animator animator;
    public int nextSceneId;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Interact(GameObject instigator)
    {
        instigator.SetActive(false);
        animator.SetTrigger("Leaving");
    }


    public void GoalReached()
    {
        SceneManager.LoadScene(nextSceneId);

    }
}
