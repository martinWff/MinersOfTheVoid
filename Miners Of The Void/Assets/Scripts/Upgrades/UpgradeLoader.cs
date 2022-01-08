using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLoader : MonoBehaviour
{
    public UpgradeElement[] upgrades;
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
        sv.humanoidUpgrades = UpgradeTransporter.humanPlayer;
        sv.spaceshipUpgrades = UpgradeTransporter.spaceship;
    }

    void OnLoadUpgrades(SavedData sv) {
        UpgradeTransporter.humanPlayer = sv.humanoidUpgrades;
        UpgradeTransporter.spaceship = sv.spaceshipUpgrades;
        foreach (Upgrade up in UpgradeTransporter.spaceship)
        {
            UpgradeElement sample;
            if (ArrayUtils.FindAndGet<UpgradeElement>(upgrades, (UpgradeElement ue) => { return ue.upgradeName == up?.upgradeName; },out sample))
            {
                up.sprite = sample.upgradeSprite;
            }
            
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