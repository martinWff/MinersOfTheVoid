using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefineryUIController : MonoBehaviour
{
    public RefineryInventory refineryInventory;

    public Image progress;
    public Image inputItem;
    public Image outputItem;

    public void Refine(OreStack stack)
    {
        refineryInventory.Refine(stack);
    }

    public void RemoveOutput()
    {
        refineryInventory.CollectOutput();
    }

    private void Update()
    {
        if (refineryInventory)
        {
            if (!refineryInventory.refiningQueue.IsEmpty())
            {
                RefineryInventory.RefineryItem _inputItem = refineryInventory.refiningQueue.Peek().Data;

                if (inputItem != null)
                {
                    inputItem.sprite = _inputItem.oreStack.sprite;
                    inputItem.color = Color.white;
                }
            } else
            {
                if (inputItem != null)
                {
                    inputItem.sprite = null;
                    inputItem.color = new Color(0,0,0,0);

                }
            }


            OreStack s = refineryInventory.GetOutput();
            if (s != null)
            {
                outputItem.sprite = s.sprite;
                outputItem.color = Color.white;
            } else
            {
                outputItem.color = new Color(0, 0, 0, 0);
            }

            progress.fillAmount = refineryInventory.GetRemainingDuration() / refineryInventory.duration;

        }
    }
}
