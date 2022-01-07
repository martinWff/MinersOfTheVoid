using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGoal : Goal
{
    string enemy;
    public DamageGoal(string enemy,string description,int requiredAmount,Sprite sprite)
    {
        this.requiredAmount = requiredAmount;
        this.sprite = sprite;
        this.enemy = enemy;
        this.description = description.Replace("{name}", enemy).Replace("{quantity}", requiredAmount.ToString());
    }

    public override void Init()
    {
        base.Init();
        CombatSystem.onDamageDealt += OnDamageDealt;
    }

    public override void Dispose()
    {
        CombatSystem.onDamageDealt -= OnDamageDealt;
    }


    private void OnDamageDealt(float dmg,string enemyName,bool isPlanetary)
    {
        if (this.currentAmount < this.requiredAmount && enemyName == enemy)
        {
            //this will ensure only the remaining damage points left will be scored
            this.currentAmount += Mathf.Clamp(Mathf.CeilToInt(dmg),0,(this.requiredAmount-this.currentAmount));
        }
        Evaluate();
    }
}
