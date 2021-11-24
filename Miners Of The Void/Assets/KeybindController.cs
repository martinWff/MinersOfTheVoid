using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindController : MonoBehaviour
{
    //public static KeybindController instance;
    public Image imageRenderer;
    private Color defaultColor;
    public Color pressedColor = new Color(0,0,1);
    // Start is called before the first frame update
    void Start()
    {
        // instance = this;
        imageRenderer = GetComponent<Image>();
        defaultColor = imageRenderer.color;
        InteractionArea.onShowKeyBind += Show;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interaction"))
        {
            imageRenderer.color = pressedColor;
        }
        if (Input.GetButtonUp("Interaction"))
        {
            imageRenderer.color = defaultColor;
        }
    }

    private void Show(bool state,Vector2 position)
    {
        
        transform.position = Camera.main.WorldToScreenPoint(position);
        if (gameObject.activeSelf != state)
        {
            gameObject.SetActive(state);
        }
    }

/*    public static void Show(Vector2 position)
    {
        instance._Show(position);
    }*/
}
