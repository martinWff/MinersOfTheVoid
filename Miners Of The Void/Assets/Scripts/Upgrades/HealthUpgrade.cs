using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthUpgrade : Upgrade
{
    [System.NonSerialized]private HealthBar hpShield;
    private StatModifier hpUp;
    public HealthUpgrade(string upName, int level) : base(upName, level) { }
    public override void OnPut(GameObject controller)
    {
        hpShield = controller.GetComponent<HealthBar>();
        hpShield.totalhp.RemoveAllFromSource(this);
        hpUp = new StatModifier(20 * level, this);
        hpShield.totalhp.AddModifier(hpUp);
    }

    public override void OnRemove()
    {
        hpShield.totalhp.RemoveAllFromSource(this);
    }




}
