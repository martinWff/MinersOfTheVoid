using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageUpgrade : Upgrade
{
    [System.NonSerialized]private CharacterWeapon weapon;
    private StatModifier dmgUp;
    public DamageUpgrade(string upName, int level): base(upName, level) { }
    public override void OnPut(GameObject controller)
    {
        weapon = controller.GetComponent<CharacterWeapon>();
        weapon.dmg.RemoveAllFromSource(this);
        dmgUp = new StatModifier(5*level,this);
        weapon.dmg.AddModifier(dmgUp);
    }

    public override void OnRemove()
    {
        weapon.dmg.RemoveAllFromSource(this);
    }

    

    
}
