using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Inventory
{
   // protected Dictionary<string,OreStack> oresStacks = new Dictionary<string, OreStack>();
    protected Hashtable oresStacks = new Hashtable(300);
    private HashSet<string> keys = new HashSet<string>();
  //  public int CountDifferent { get { return oresStacks.; } }

    public delegate void InventoryChanged(Inventory inv, string oreName,int amountChanged);
    public static event InventoryChanged onInventoryChanged;

    public int CountDistinct => keys.Count;

    public virtual bool AddOre(OreStack ore)
    {
        if (ore == null) return false;
        if (ore.amount == 0) return false;


        keys.Add(ore.oreName);

        if (!oresStacks.ContainsKey(ore.oreName))
        {
            oresStacks.Insert(ore.oreName, ore);
        }
        else
        {
            OreStack oreStack = (OreStack)oresStacks.GetValue(ore.oreName);
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
            return (oresStacks.GetValue(oreName) as OreStack).amount;
        } else
        {
            return 0;
        }
    }


    public OreStack GetOreStack(string oreName)
    {
        return (OreStack)oresStacks.GetValue(oreName);
    }

    public void Reset()
    {
        oresStacks = new Hashtable(300);
        keys.Clear();
    }


      public virtual int RetrieveAmount(string oreName,int amount)
    {
        if (amount == 0) return 0;
        int oreAmount = GetOreAmount(oreName);
        if (oreAmount <= 0) return 0;

        int clampedAmount = Mathf.Clamp(amount, 0, oreAmount);
        OreStack oreFound = (OreStack)oresStacks.GetValue(oreName);
 
        oreFound.amount -= clampedAmount;
        if (oreFound.amount > 0)
        {
            oresStacks.Insert(oreName,oreFound);
        } else
        {
            oresStacks.Remove(oreName);
            keys.Remove(oreName);
        }
        
        onInventoryChanged?.Invoke(this, oreName,-clampedAmount);
        

        return clampedAmount;
    }

    public Dictionary<string, OreStack> GetOres()
    {


        Dictionary<string, OreStack> ores = new Dictionary<string, OreStack>(keys.Count);
        foreach (string key in keys)
        {
            ores.Add(key,(OreStack)oresStacks.GetValue(key));
        }

        return ores;
    }
}