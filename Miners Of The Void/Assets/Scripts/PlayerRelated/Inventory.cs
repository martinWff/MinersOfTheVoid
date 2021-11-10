using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Inventory
{
    protected Dictionary<string,OreStack> oresStacks = new Dictionary<string, OreStack>();

    private Dictionary<string, OreStack> contractOresStacks = new Dictionary<string, OreStack>();

    public Dictionary<string, int> contractFilter = new Dictionary<string, int>();
    public bool hasContract = true;

    //   private Contract contract;

    public delegate void InventoryChanged(Inventory inv, string oreName,int amountChanged,bool addedOnContract);
    public static event InventoryChanged onInventoryChanged;

//    public System.Action<OreStack, int> onItemChanged;


    public void AddOre(OreStack ore)
    {
        if (ore.amount == 0) return;      

           if (contractFilter.ContainsKey(ore.oreName)) 
        {
            
            int vContractFilter = Mathf.Clamp(ore.amount, 0, contractFilter[ore.oreName]); //contractFilter[ore.oreName] - ore.amount;

            OreStack remainder;
           
           
            if (!contractOresStacks.ContainsKey(ore.oreName))
            {

               OreStack os = new OreStack(ore.oreName, vContractFilter, ore.sprite);
                contractOresStacks.Add(ore.oreName, os);
                remainder = new OreStack(ore.oreName, Mathf.Clamp((ore.amount - vContractFilter), 0,ore.amount),ore.sprite);
              
                onInventoryChanged?.Invoke(this, os.oreName, os.amount, true);
                AddOreOnInventory(remainder);


            } else //if (contractOresStacks[ore.oreName].amount < contractFilter[ore.oreName])
            {
                
                OreStack v = contractOresStacks[ore.oreName];
                OreStack os = new OreStack(ore.oreName, Mathf.Clamp((ore.amount + v.amount),v.amount,contractFilter[ore.oreName]));
                //v.amount += os.amount;
                contractOresStacks[ore.oreName] = os;
                int pureValue = ore.amount + v.amount;
                onInventoryChanged?.Invoke(this, os.oreName, os.amount, true);

                remainder = new OreStack(ore.oreName, Mathf.Clamp((pureValue - contractFilter[ore.oreName]), 0, os.amount+ore.amount), ore.sprite);


                onInventoryChanged?.Invoke(this, os.oreName, os.amount-remainder.amount, true);
                AddOreOnInventory(remainder);

            }
        }
        else
        {
            AddOreOnInventory(ore);
        }
       
       
    }

    private void AddOreOnInventory(OreStack ore)
    {
        if (ore == null) return;
        if (!oresStacks.ContainsKey(ore.oreName))
        {
            oresStacks.Add(ore.oreName, ore);
        }
        else
        {
            OreStack oreStack = oresStacks[ore.oreName];
            oreStack.amount += ore.amount;
        }
       onInventoryChanged?.Invoke(this, ore.oreName, ore.amount, false);

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

    public int GetContractOreAmount(string oreName)
    {
        if (contractOresStacks.ContainsKey(oreName))
        {
            return contractOresStacks[oreName].amount;
        }
        else
        {
            return 0;
        }
    }

    public void ClearContractInventory()
    {
        //contractOresStacks.Clear();
        Dictionary<string, OreStack> contractOresStacksCopy = new Dictionary<string, OreStack>(contractOresStacks);
        foreach (KeyValuePair<string,OreStack> co in contractOresStacksCopy)
        {
            contractOresStacks[co.Key] = new OreStack(co.Value.oreName,0,co.Value.sprite);
            onInventoryChanged?.Invoke(this,co.Value.oreName,-co.Value.amount,true);
        }
        contractOresStacks.Clear();
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

        onInventoryChanged?.Invoke(this, oreName,-clampedAmount, false);
        

        return clampedAmount;
    }

    public Dictionary<string, OreStack> GetOres()
    {
        return oresStacks;
    }

    public void AddContractInventoryFilter(string oreName,int amount)
    {
        if (!contractFilter.ContainsKey(oreName)) {
            contractFilter.Add(oreName, amount);
       }
    }
}