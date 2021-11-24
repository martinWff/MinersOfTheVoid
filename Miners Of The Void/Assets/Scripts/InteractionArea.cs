using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Maths;

public class InteractionArea : MonoBehaviour
{
    public UnityEvent onAction;
    public UnityEvent<bool> onMouseOverEvent;
    public bool showKeyBind = true;

    public delegate void ShowKeybind(bool state,Vector2 position);
    public static event ShowKeybind onShowKeyBind;




    public Vector3 uIKeyBindPosition;


    //CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
      
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        onAction?.Invoke();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (showKeyBind)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Spaceship"))
            {
                onShowKeyBind?.Invoke(true, (transform.position + uIKeyBindPosition));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (showKeyBind)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Spaceship"))
            {
                onShowKeyBind?.Invoke(false, (transform.position + uIKeyBindPosition));
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
