using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade System/Upgrade Builder")]
public class UpgradeBuilder : ScriptableObject
{
    public string upgradeName;
    public Sprite sprite;
    public int maxLevel;
    public string typeName;

    public UpgradeCostObject[] costs;


    public Upgrade Build(int level)
    {
        Upgrade upg = (Upgrade)System.Activator.CreateInstance(System.Type.GetType(typeName), name, level);

        if (upg != null)
        {
            upg.sprite = sprite;
            upg.maxLevel = maxLevel;
        }
        return upg;
    }

    public UpgradeCost[] GetUpgradeCosts(int level)
    {
        return costs[level - 1].upgradeCosts;
    }
}
