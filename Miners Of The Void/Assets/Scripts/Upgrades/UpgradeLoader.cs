using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLoader : MonoBehaviour
{
    public UpgradeElement[] upgrades;
    // Start is called before the first frame update
    void Awake()
    {
        SaveManager.saveStarted += OnSaveUpgrades;
        SaveManager.saveLoaded += OnLoadUpgrades;
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