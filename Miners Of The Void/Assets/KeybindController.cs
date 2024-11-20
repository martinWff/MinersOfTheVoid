using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindController : MonoBehaviour
{
    //public static KeybindController instance;
    public Image imageRenderer;
    public Image backgroundImage;
    public Text descriptionText;
    public Color defaultColor;
    public Color pressedColor = new Color(0,0,1);
    public Color progressColor;
    public Camera mainCamera;
    private Vector2 cachedPosition;

    public string defDescription;

    // Start is called before the first frame update
    void Start()
    {
        // instance = this;
     //   InteractionArea.onShowKeyBind += Show;
      //  InteractionArea.onUpdateKeybindPosition += SetPosition;
        gameObject.SetActive(false);
        mainCamera = Camera.main;
        imageRenderer.color = defaultColor;
        backgroundImage.color = progressColor;
    }
    private void OnEnable()
    {
        if (imageRenderer != null)
        {
            imageRenderer.color = defaultColor;
        }
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

    public void Show(bool state,Vector2 position)
    {
        transform.position = mainCamera.WorldToScreenPoint(position);
        if (gameObject.activeSelf != state)
        {
            gameObject.SetActive(state);
        }
    }

    public void Show(bool state)
    {
        if (gameObject.activeSelf != state)
        {
            gameObject.SetActive(state);
        }
    }

    public void SetPosition(Vector2 position)
    {
    //    if (Vector2.Distance(position, cachedPosition) > 0.05f)
     //   {
            transform.position = mainCamera.WorldToScreenPoint(position);
            cachedPosition = position;
      //  }
    }

    public void SetProgress(float v,float max)
    {
        backgroundImage.fillAmount = (v / max);
    }

    public void ResetProgress()
    {
        backgroundImage.fillAmount = 0;
    }
    public void SetDetail(string txt)
    {
        descriptionText.text = txt;
    }

    public void OnTargetObject(GameObject target,IInteractableInfoHandler infoHandler)
    {
        SetPosition(target.transform.position);
        Show(true);
        descriptionText.text = infoHandler == null ? defDescription : infoHandler.GetTitle();
    }
    public void OnTargetObjectLost()
    {
        Show(false);
    }
}
