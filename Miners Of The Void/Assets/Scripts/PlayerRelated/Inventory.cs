using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Inventory
{
    protected Dictionary<string,OreStack> oresStacks = new Dictionary<string, OreStack>();
    public int CountDifferent { get { return oresStacks.Count; } }

    public delegate void InventoryChanged(Inventory inv, string oreName,int amountChanged);
    public static event InventoryChanged onInventoryChanged;

    public virtual bool AddOre(OreStack ore)
    {
        if (ore == null) return false;
        if (ore.amount == 0) return false;

        if (!oresStacks.ContainsKey(ore.oreName))
        {
            oresStacks.Add(ore.oreName, ore);
        }
        else
        {
            OreStack oreStack = oresStacks[ore.oreName];
            oreStack.amount += ore.amount;
        }
        
        onInventoryChanged?.Invoke(this, ore.oreName, ore.amount);
        return true;


    }

    public bool ContainsOre(string oreName) {
        return oresStacks.ContainsKey(oreName);
    }

    public virtual int GetOreAmount(string oreName)
    {
        if (oresStacks.ContainsKey(oreName)) {
            return oresStacks[oreName].amount;
        } else
        {
            return 0;
        }
    }


    public OreStack GetOreStack(string oreName)
    {
        return oresStacks[oreName];
    }

    public void Reset()
    {
        oresStacks.Clear();
    }


      public virtual int RetrieveAmount(string oreName,int amount)
    {
        if (amount == 0) return 0;
        int oreAmount = GetOreAmount(oreName);
        if (oreAmount <= 0) return 0;

        int clampedAmount = Mathf.Clamp(amount, 0, oreAmount);
        OreStack oreFound = oresStacks[oreName];
 
        oreFound.amount -= clampedAmount;
        if (oreFound.amount > 0)
        {
            oresStacks[oreName] = oreFound;
        } else
        {
            oresStacks.Remove(oreName);
        }
        
        onInventoryChanged?.Invoke(this, oreName,-clampedAmount);
        

        return clampedAmount;
    }

    public Dictionary<string, OreStack> GetOres()
    {
        return oresStacks;
    }
}