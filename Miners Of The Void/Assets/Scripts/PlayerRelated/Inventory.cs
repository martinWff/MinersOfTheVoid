using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Inventory
{
    private Dictionary<string,OreStack> oresStacks = new Dictionary<string, OreStack>();


    //   private Contract contract;

    public delegate void InventoryChanged(Inventory inv, OreStack amountChanged);
    public static event InventoryChanged onInventoryChanged;

//    public System.Action<OreStack, int> onItemChanged;


    public void AddOre(OreStack ore)
    {
        if (ore.amount == 0) return;
        if (!oresStacks.ContainsKey(ore.oreName))
        {
            oresStacks.Add(ore.oreName, ore);
        } else
        {
           OreStack oreStack = oresStacks[ore.oreName];
            oreStack.amount += ore.amount;
        }
        //onItemChanged?.Invoke(ore,ore.amount);
        onInventoryChanged.Invoke(this,ore);
       
    }

    public bool ContainsOre(string oreName) {
        return oresStacks.ContainsKey(oreName);
    }

    public int GetOreAmount(string oreName)
    {
        if (oresStacks.ContainsKey(oreName)) {
            return oresStacks[oreName].amount;
        } else
        {
            return 0;
        }
    }



    public OreStack RetrieveAmount(string oreName,int amount)
    {
        OreStack oreStack = null;

        if (amount == 0) return null ;
        if (oresStacks.ContainsKey(oreName))
        {
            oreStack = oresStacks[oreName];
            int clampValue = Mathf.Clamp((oreStack.amount - amount), 0, oreStack.amount);
            if (clampValue == 0)
            {
                oreStack.amount = clampValue;
                oresStacks.Remove(oreStack.oreName);

                //   onItemChanged.Invoke(oreStack, -clampValue);
                onInventoryChanged.Invoke(this, oreStack);
                return oreStack;
            }
            else
            {
                oreStack.amount -= clampValue;
                // onItemChanged.Invoke(oreStack, -clampValue);
                onInventoryChanged.Invoke(this, oreStack);
                oresStacks[oreStack.oreName]= oreStack;
                return oreStack;
            }


        }

        return oreStack;
    }


    public void GatherResources(ContractResource<OreStack>[] resources)
    {
      
       for (int i = 0; i < resources.Length; i++)
            {

            ContractResource<OreStack> r = resources[i];
            OreStack resourceOreStack = r.resource;
            OreStack gatheredOreStack = r.gathered;
                if (r != null)
                {
                    if (r.resource.amount < r.gathered.amount)
                    {
                        if (GetOreAmount(r.gathered.oreName) >= r.resource.amount)
                        {
                            // gatheredResources[i] += inventory.GetOreAmount(resources[i].oreName);
                            r.gathered = RetrieveAmount(r.resource.oreName, r.resource.amount);
                            //  gatheredResources[i].amount += inventory.RemoveOreAmount(resources[i].oreName,resources[i].amount);


                        }
                    }
                }
            }
       
    }
}
