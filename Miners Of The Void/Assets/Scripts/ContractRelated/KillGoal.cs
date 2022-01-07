using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        CombatSystem.onDied += OnKilled;
        //  Inventory.onInventoryChanged += OnGathered;
    }

    public override void Dispose()
    {
        base.Dispose();
        CombatSystem.onDied -= OnKilled;
    }


    void OnKilled(string killedEntity)
    {
        if (enemyId == killedEntity)
            {

                if (this.currentAmount < this.requiredAmount)
                {
                    this.currentAmount++;
                }
                Evaluate();

            }
       


    
    }    
}
