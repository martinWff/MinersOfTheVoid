using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthUpgrade : Upgrade
{
    [System.NonSerialized]private Health hpShield;
    private StatModifier hpUp;
    public HealthUpgrade(string upName, int level) : base(upName, level) { }
    public override void OnPut(GameObject controller)
    {
        hpShield = controller.GetComponent<Health>();
        hpShield.maxHP.RemoveAllFromSource(this);
        hpUp = new StatModifier(20 * level, this);
        hpShield.maxHP.AddModifier(hpUp);
    }

    public override void OnRemove()
    {
        hpShield.maxHP.RemoveAllFromSource(this);
    }




}
