using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefinerySlotResult : MonoBehaviour
{
    public OreStack oreStack;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        OreResourceObject oreResource = OreManager.instance.GetOreResourceByName("Gold");
        oreStack.sprite = oreResource.oreSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (image.sprite != oreStack.sprite)
        {
            image.sprite = oreStack.sprite;
        }
    }
}
