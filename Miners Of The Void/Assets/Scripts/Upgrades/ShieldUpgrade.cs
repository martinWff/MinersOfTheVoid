using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShieldUpgrade : Upgrade
{
    [System.NonSerialized]private Health hpShield;
    private StatModifier shieldUp;
    public ShieldUpgrade(string upName, int level) : base(upName, level) { }
    public override void OnPut(GameObject controller)
    {
        hpShield = controller.GetComponent<Health>();
        hpShield.maxShield.RemoveAllFromSource(this);
        shieldUp = new StatModifier(10 * level, this);
        hpShield.maxShield.AddModifier(shieldUp);
    }

    public override void OnRemove()
    {
        hpShield.maxShield.RemoveAllFromSource(this);
    }




}