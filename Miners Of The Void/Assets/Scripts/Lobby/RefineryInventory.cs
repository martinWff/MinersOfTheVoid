using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RefineryInventory : MonoBehaviour
{
    //Class related stuff
    public InventoryBehaviour inventory;
    public Contract oreContract;
   
    public UnityEvent<RefineryItem> onRefining;
    public UnityEvent<RefineryItem> onFinishedRefining;
    
    public UnityEvent<OreStack> onCollectRefinery;

    public Queue<RefineryItem> refiningQueue = new Queue<RefineryItem>();

    public Stack<OreStack> outputStackCollection = new Stack<OreStack>();

    public float duration = 5;


    void Start()
    {
     /*   inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Iron").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Copper").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Gold").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Osmium").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Iron Nugget").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Copper Nugget").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Gold Nugget").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Osmium Nugget").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Iron Ingot").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Copper Ingot").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Gold Ingot").GetOreStack(20));
        inventory.AddOre(OreManager.instance.GetOreMaterialByMaterialName("Osmium Ingot").GetOreStack(20));*/
    }
    private void Update()
    {
        if (!refiningQueue.IsEmpty())
        {
            RefineryItem ri = refiningQueue.Peek().Data;
            
            if (ri.duration <= 0)
            {
                inventory.AddOre(ri.output);

                outputStackCollection.Push(refiningQueue.Dequeue().Data.output);

                onFinishedRefining?.Invoke(ri);                
            }

            ri.duration -= Time.deltaTime;

        }
        
        
    }

    public void Refine(OreStack stack)
    {
        if (stack.amount >= 3)
        {
            int index;
            MaterialResourceObject mat = OreManager.instance.GetOreMaterialByMaterialName(stack.oreName, out index);

            OreResourceObject oreRes = OreManager.instance.GetOreResourceFromMaterial(mat);

            int nextIndex = index + 1;
            if (oreRes.materialResourceObjects.Length > nextIndex)
            {
                MaterialResourceObject nextMat = oreRes.materialResourceObjects[nextIndex];

                RefineryItem refiItem = new RefineryItem(stack, duration, new MaterialID(nextMat.resourceName, nextIndex));

                refiItem.output = nextMat.GetOreStack();

                inventory.inventory.RetrieveAmount(stack.oreName, 3);

                refiningQueue.Enqueue(refiItem);
                onRefining?.Invoke(refiItem);
            }

        }
        else
        {
            Debug.Log("You don't have enough " + name);
        }

    }

    public float GetRemainingDuration()
    {
        if (refiningQueue.IsEmpty())
        {
            return 0;
        } else
        {
            return refiningQueue.Peek().Data.duration;
        }

    }

    public bool HasFinished()
    {
        return refiningQueue.IsEmpty();
    }
    public OreStack CollectOutput()
    {
        if (outputStackCollection.Count == 0)
            return null;

        OreStack s = outputStackCollection.Pop();

        if (s == null)
            return null;

        inventory.AddOre(s);

        if (onCollectRefinery != null)
        {
            onCollectRefinery.Invoke(s);
        }

        return s;
    }


    public OreStack GetOutput()
    {
        if (outputStackCollection.Count == 0)
            return null;

        return outputStackCollection.Peek();
    }

    /*private void InventoryController_onInventoryControllerCreated(InventoryController inventoryController)
    {
        if (!inventoryController.hasInventory)
        {
            inventoryController.AttachInventory(inventory);
        }
    }+*/

    public class RefineryItem
    {
        public OreStack oreStack;
        public float duration;

        public MaterialID matId;

        public OreStack output;


        public RefineryItem(OreStack s,float d,MaterialID id)
        {
            this.oreStack = s;
            this.duration = d;
            this.matId = id;
        }
    }

}
public class MaterialID
{
    public string name;
    public int index;

    public MaterialID(string name,int index)
    {
        this.name = name;
        this.index = index;
    }
}
