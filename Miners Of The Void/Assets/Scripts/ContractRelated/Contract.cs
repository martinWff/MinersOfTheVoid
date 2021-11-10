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

    public void Start()
    {
        foreach (Goal g in goals)
        {
            g.Init();
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
    public Sprite sprite;

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

    void OnGathered(Inventory inv,string updatedOreName,int amount,bool addedOnContract)
    {
        if (addedOnContract)
        {
            if (oreName == updatedOreName)
            {

                         
               this.currentAmount = inv.GetContractOreAmount(updatedOreName);
                Evaluate();
                
            }
        }


    }
}

public class KillGoal : Goal
{
    public string enemyId;
    public KillGoal(string enemyId, string description, int requiredAmount)
    {

        this.enemyId = enemyId;
        this.description = description;
        this.requiredAmount = requiredAmount;


    }

    public override void Init()
    {
        base.Init();
      //  Inventory.onInventoryChanged += OnGathered;
    }

    void OnGathered(Inventory inv, string killedEntity, int amount, bool addedOnContract)
    {
        if (addedOnContract)
        {
            if (enemyId == killedEntity)
            {


                this.currentAmount = inv.GetContractOreAmount(killedEntity);
                Evaluate();

            }
        }


    }
}