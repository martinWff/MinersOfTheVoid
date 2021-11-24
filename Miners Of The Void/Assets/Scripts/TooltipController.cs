using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{
    RectTransform rectTransform;
    Text textObject;
    private static TooltipController instance;

    public static Vector3 currentMousePosition;

    public static bool isShown { get {
            return instance.gameObject.activeSelf;
        } }
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        textObject = GetComponentInChildren<Text>();
        instance = this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position = Input.mousePosition;
    }

    public void _SetText(string txt)
    {
        textObject.text = txt;
    }



    public static void SetText(string txt)
    {
        instance._SetText(txt);
    }

    public static void Show(bool state)
    {
        instance.gameObject.SetActive(state);
    }

   
}

