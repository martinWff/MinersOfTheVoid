using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public bool isHumanoid;
    public UpgradeUIController upgradeControllerUI;
    public GameObject player;
    public virtual Upgrade GetUpgrade(int level)
    {
        return null;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!SavePlayerStats.humanLevels.ContainsKey("speed"))
        {
            SavePlayerStats.humanLevels.Insert("speed", 0);
            SavePlayerStats.humanLevels.Insert("dmg", 0);
            SavePlayerStats.humanLevels.Insert("shield", 0);
            SavePlayerStats.humanLevels.Insert("health", 0);
        }
    }
}
