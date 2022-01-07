using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGoal : Goal
{
    public override void Init()
    {
        base.Init();
        CombatSystem.onDamageDealt += OnDamageDealt;
    }

    public override void Dispose()
    {
        CombatSystem.onDamageDealt -= OnDamageDealt;
    }


    private void OnDamageDealt(int dmg)
    {
        if (this.currentAmount < this.requiredAmount)
        {
            //this will ensure only the remaining damage points left will be scored
            this.currentAmount += Mathf.Clamp(dmg,0,(this.requiredAmount-this.currentAmount));
        }
    }
}
