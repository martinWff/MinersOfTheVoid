using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLoader : MonoBehaviour
{
    public UpgradeBuilder[] upgrades;
    public EnemyElement[] enemies;
    public static UpgradeLoader instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            SaveManager.saveStarted += OnSaveUpgrades;
            SaveManager.saveLoaded += OnLoadUpgrades;
        
            instance = this;
        }
    }

    void OnSaveUpgrades(SavedData sv)
    {
    //    sv.humanoidUpgrades = UpgradePersistentData.humanPlayer;
     //   sv.spaceshipUpgrades = UpgradePersistentData.spaceship;
    }

    void OnLoadUpgrades(SavedData sv) {
      //  UpgradePersistentData.humanPlayer = sv.humanoidUpgrades;
      //  UpgradePersistentData.spaceship = sv.spaceshipUpgrades;
        foreach (Upgrade up in UpgradePersistentData.upgrades["spaceship"])
        {
            
        }
    }

}

[System.Serializable]
public struct UpgradeElement
{
    public string upgradeName;
    public Sprite upgradeSprite;
}
[System.Serializable]
public struct EnemyElement
{
    public string enemyName;
    public Sprite sprite;
}