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
    public Camera mainCamera;
    private Vector2 cachedPosition;
    // Start is called before the first frame update
    void Start()
    {
        // instance = this;
        imageRenderer = GetComponent<Image>();
        defaultColor = imageRenderer.color;
        InteractionArea.onShowKeyBind += Show;
        InteractionArea.onUpdateKeybindPosition += SetPosition;
        gameObject.SetActive(false);
        mainCamera = Camera.main;
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
        transform.position = mainCamera.WorldToScreenPoint(position);
        if (gameObject.activeSelf != state)
        {
            gameObject.SetActive(state);
        }
    }

    private void SetPosition(Vector2 position)
    {
    //    if (Vector2.Distance(position, cachedPosition) > 0.05f)
     //   {
            transform.position = mainCamera.WorldToScreenPoint(position);
            cachedPosition = position;
      //  }
    }

}
