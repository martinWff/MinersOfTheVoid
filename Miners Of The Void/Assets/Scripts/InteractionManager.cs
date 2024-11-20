using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionManager : MonoBehaviour
{
    private IInteractable interactable;
    private IInteractableInfoHandler infoHandler;

    [SerializeField] float radius = 1.5f;

    public UnityEvent<GameObject,IInteractableInfoHandler> onInteractionTargeting;
    public UnityEvent onInteractionTargetLost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable != null && Input.GetButtonDown("Interaction"))
        {
            interactable.Interact(gameObject);
        }

        
    }

    private void FixedUpdate()
    {
        IInteractable inter = null;
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius);
        for (int i = 0;i<hit.Length;i++)
        {
            if (hit[i].TryGetComponent<IInteractable>(out inter))
            {
                infoHandler = hit[i].GetComponent<IInteractableInfoHandler>();

                onInteractionTargeting?.Invoke(hit[i].gameObject,infoHandler);

                break;
            }
        }

        if (interactable != null && inter == null)
        {
            onInteractionTargetLost.Invoke();
        }

        interactable = inter;
        
    }
}
