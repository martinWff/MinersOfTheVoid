using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Contract : System.IDisposable { 
    public enum ContractType
    {
        mining,
        position,
        combat
    }

    public ContractType contractType;

   public Array<Goal> goals;

    //public System.Action<Contract> onContractCompleted;


    //rewards //
    public int famePoints;

    public int bips;

    public bool isCompleted { get; private set; }


    public void CheckGoals()
    {
        if (goals != null)
        {

             isCompleted = goals.TrueForAll((Goal g) => g.completed);     
          
        }
    }

  /* public void GiveRewards()
    {
        if (!isCompleted)
        {
            CheckGoals();
        }

    }*/

    public void Start()
    {
        foreach (Goal g in goals)
        {
            g.Init();
        }
    }

   public void Dispose()
    {
        foreach (Goal g in goals)
        {
            g.Dispose();
        }
    }


    public Contract(ContractType type,Array<Goal> goals)
    {
        contractType = type;
        this.goals = goals;
    }


}

[System.Serializable]
public class Goal : System.IDisposable
{
    public bool completed;

    public int currentAmount;
    public int requiredAmount;
    public string description;
    [System.NonSerialized]public Sprite sprite;

    public virtual void Init()
    {

    }

    public void Evaluate()
    {
        if (currentAmount >= requiredAmount)
        {
            Complete();
        }
    }

    protected void Complete()
    {
        completed = true;
    }

    public virtual void Dispose()
    {
        
    }
    public virtual void OnLoaded()
    {

    }
}

[System.Serializable]
public class GatheringGoal : Goal
{
    public string oreName;
    public Inventory checkInInventory;
    public GatheringGoal(string oreName,string description,int requiredAmount,Sprite sprite,Inventory inventory)
    {
        this.checkInInventory = inventory;
        this.oreName = oreName;
        this.description = description;
        this.requiredAmount = requiredAmount;
        this.sprite = sprite;

               
    }

    public GatheringGoal(OreStack oreStack, Inventory inventory)
    {
        this.checkInInventory = inventory;
        this.oreName = oreStack.oreName;
        this.sprite = oreStack.sprite;
        this.requiredAmount = oreStack.amount;
        this.description = $"mine {oreStack.amount} {oreStack.oreName}";

    }

    public override void Init()
    {
        base.Init();

        if (checkInInventory != null)
        {
            this.currentAmount = Mathf.Clamp(checkInInventory.GetOreAmount(this.oreName), 0, requiredAmount);
            Evaluate();
        }
        if (!completed)
        {

            Inventory.onInventoryChanged += OnGathered;
        }

    }

    public override void Dispose()
    {
        Inventory.onInventoryChanged -= OnGathered;

        if (completed)
        {
            checkInInventory.RetrieveAmount(this.oreName, this.requiredAmount);
        }


    }

    public override void OnLoaded()
    {
        this.sprite = OreManager.instance.GetOreMaterialByMaterialName(oreName).sprite;
    }

    void OnGathered(Inventory inv,string updatedOreName,int amount)
    {        
            if (oreName == updatedOreName)
            {

                         
               this.currentAmount = Mathf.Clamp(inv.GetOreAmount(updatedOreName),0,requiredAmount);
                Evaluate();
                
            }
       


    }
}