using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PersistentData : ScriptableObject
{
    public Inventory inventory;

    public Dictionary<string,List<Upgrade>> upgrades = new Dictionary<string, List<Upgrade>>();

    [System.NonSerialized] public bool immortality;

    [System.NonSerialized]public int bips;
    [System.NonSerialized] public int xp;
    [System.NonSerialized] public int requiredXP = 200;
    [System.NonSerialized] public int level;
}
