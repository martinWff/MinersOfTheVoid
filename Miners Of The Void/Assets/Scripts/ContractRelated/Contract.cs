using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract { 
    public enum ContractType
    {
        mining,
        position,
        combat
    }

    public ContractType contractType;

// public OreStack[] resources;

// public Dictionary<OreStack,OreStack> gatheredResources;
   public Array<Goal> goals;
    

    //rewards //
    public int famePoints;

    public int bips;

    public bool isCompleted { get; private set; }


    public void CheckGoals()
    {
        if (goals != null)
        {

            for (int i = 0; i < goals.Count; i++)
            {
                isCompleted = goals.TrueForAll((Goal g) => g.completed);
            }
          
        }
    }

    public void GiveRewards()
    {
        if (!isCompleted)
        {
            CheckGoals();
        }

    }

    public Contract(ContractType type,Array<Goal> goals)
    {
        contractType = type;
        this.goals = goals;
    }


}


public class Goal
{
    public bool completed;

    public int currentAmount;
    public int requiredAmount;
    public string description;

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
}


public class GatheringGoal : Goal
{
    public string oreName;
    public GatheringGoal(string oreName,string description,int requiredAmount)
    {

        this.oreName = oreName;
        this.description = description;
        this.requiredAmount = requiredAmount;

               
    }

    public override void Init()
    {
        base.Init();
        Inventory.onInventoryChanged += OnGathered;
    }

    void OnGathered(Inventory inv,OreStack ore)
    {
        if (ore.oreName == oreName)
        {
            this.currentAmount++;
            Evaluate();
        }
    }
}