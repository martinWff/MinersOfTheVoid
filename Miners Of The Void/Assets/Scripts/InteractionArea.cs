using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Maths;

public class InteractionArea : MonoBehaviour
{
    public UnityEvent<GameObject> onInteractionAreaStay;

    public UnityEvent<GameObject> onInteractionAreaEnter;
    public UnityEvent<GameObject> onInteractionAreaExit;
    public UnityEvent<bool> onMouseOverEvent;
    public bool showKeyBind = true;

    public delegate void ShowKeybind(bool state,Vector2 position);
    public static event ShowKeybind onShowKeyBind;

    public delegate void UpdateKeybindPosition(Vector2 position);
    public static event UpdateKeybindPosition onUpdateKeybindPosition;


    private bool playerIsInside;

    public Vector3 uIKeyBindPosition;


    //CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
      
    }

  /*  private void LateUpdate()
    {
        if (showKeyBind && playerIsInside)
        {
            if (onUpdateKeybindPosition != null)
            {
               onUpdateKeybindPosition?.Invoke((transform.position + uIKeyBindPosition));
            }
        }
    }*/


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Spaceship"))
        {
            onInteractionAreaStay?.Invoke(other.gameObject);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (showKeyBind)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Spaceship"))
            {
                // onShowKeyBind?.Invoke(true, (transform.position + uIKeyBindPosition));
                onInteractionAreaEnter?.Invoke(other.gameObject);
                playerIsInside = true;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (showKeyBind)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Spaceship"))
            {
                //onShowKeyBind?.Invoke(false, (transform.position + uIKeyBindPosition));
                onInteractionAreaExit?.Invoke(other.gameObject);
                playerIsInside = false;
            }
          
        }
    }

    private void OnMouseEnter()
    {
        onMouseOverEvent?.Invoke(true);
    }
    private void OnMouseExit()
    {
        onMouseOverEvent?.Invoke(false);
    }
}
