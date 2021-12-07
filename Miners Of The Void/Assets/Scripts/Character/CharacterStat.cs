using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStat
{
    public float baseValue;

    private bool isDirty;
    private float _value;
    public float value { get {
            if (isDirty)
            {
                CalculateFinalValue();
                return _value;
            } else
            {
                return _value;
            }

        } }
    


    private List<StatModifier> modifiers;

    public void AddModifier(StatModifier mod)
    {
        modifiers.Add(mod);
        isDirty = true;
    
    }

    public void RemoveModifier(StatModifier mod)
    {
        modifiers.Remove(mod);
        isDirty = true;
    }

    private void CalculateFinalValue()
    {
        _value = baseValue;
        foreach (StatModifier mod in modifiers)
        {
         _value += mod.value; 
        }
        isDirty = false;
    }

    public void RemoveAllFromSource(object source)
    {
        this.modifiers.RemoveAll((StatModifier mod) => mod.source == source );
        isDirty = true;
    }


    public CharacterStat(float baseValue)
    {
        this.baseValue = baseValue;
        modifiers = new List<StatModifier>();
        CalculateFinalValue();
    }

}

public struct StatModifier
{
    public readonly float value;
    public readonly object source;

    public StatModifier(float value,object source)
    {
        this.value = value;
        this.source = source;
    }
}
