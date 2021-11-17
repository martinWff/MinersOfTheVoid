using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public OreStack oreStack;

    private int quantity = -1;
    [SerializeField]private Image image;
    [SerializeField]private Text quantityText;


    public void SetContent(OreStack o)
    {
        oreStack = o;
        image.sprite = o.sprite;
        quantityText.text = o.amount.ToString();
    }

    private void Update()
    {
        if (oreStack != null)
        {
            if (oreStack.amount != quantity)
            {
                quantity = oreStack.amount;
                quantityText.text = oreStack.amount.ToString();
            }
        }
    }

    public void PrepareRefine()
    {
        transform.parent.GetComponent<RefineryInventory>().Refine(oreStack.oreName,1);
    }
}
