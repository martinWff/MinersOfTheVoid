using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Inventory
{
    protected Dictionary<string,OreStack> oresStacks = new Dictionary<string, OreStack>();


    public delegate void InventoryChanged(Inventory inv, string oreName,int amountChanged);
    public static event InventoryChanged onInventoryChanged;

    public void AddOre(OreStack ore)
    {
        if (ore == null) return;
        if (ore.amount == 0) return;

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


    public OreStack GetOreStack(string oreName)
    {
        return oresStacks[oreName];
    }


      public int RetrieveAmount(string oreName,int amount)
    {
        if (amount == 0) return 0;
        int oreAmount = GetOreAmount(oreName);
        if (oreAmount <= 0) return 0;

        int clampedAmount = Mathf.Clamp(amount, 0, oreAmount);
        OreStack oreFound = oresStacks[oreName];
 
        oreFound.amount -= clampedAmount;
        oresStacks[oreName] = oreFound;

        onInventoryChanged?.Invoke(this, oreName,-clampedAmount);
        

        return clampedAmount;
    }

    public Dictionary<string, OreStack> GetOres()
    {
        return oresStacks;
    }
}