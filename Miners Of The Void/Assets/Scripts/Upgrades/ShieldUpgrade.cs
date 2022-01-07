using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShieldUpgrade : Upgrade
{
    [System.NonSerialized]private HealthBar hpShield;
    private StatModifier shieldUp;
    public ShieldUpgrade(string upName, int level) : base(upName, level) { }
    public override void OnPut(GameObject controller)
    {
        hpShield = controller.GetComponent<HealthBar>();
        hpShield.totalShield.RemoveAllFromSource(this);
        shieldUp = new StatModifier(10 * level, this);
        hpShield.totalShield.AddModifier(shieldUp);
    }

    public override void OnRemove()
    {
        hpShield.totalShield.RemoveAllFromSource(this);
    }




}