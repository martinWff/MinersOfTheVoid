using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    public string enemyId;
    public KillGoal(string enemyId, string description, int requiredAmount,Sprite sprite)
    {

        this.enemyId = enemyId;
        string fdescription = description.Replace("{name}", enemyId);
        this.description = fdescription.Replace("{quantity}", requiredAmount.ToString());
        this.requiredAmount = requiredAmount;
        this.sprite = sprite;


    }

    public override void Init()
    {
        base.Init();
        CombatSystem.onDied += OnKilled;
    }

    public override void Dispose()
    {
        base.Dispose();
        CombatSystem.onDied -= OnKilled;
    }


    void OnKilled(string killedEntity,bool isPlanetary)
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
