
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeController : MonoBehaviour
{
    //used for cross scene saving and loading
    public string upgradeControllerId;
    //6 for player - 4 for spaceship
    public int upgradeCount = 0;
    public Upgrade[] upgradeHolder;
    public static System.Action<UpgradeController,Upgrade,int> onUpgradePut;
    public static System.Action<UpgradeController,Upgrade, int> onUpgradeRemovedAction;

    public UnityEvent<int,Upgrade> onUpgradePlaced;
    public UnityEvent<int,Upgrade> onUpgradeRemoved;
    
    [SerializeField] private bool preventUse; 

    private void Awake()
    {
        SaveManager.onAfterLoaded += OnUpgradesLoaded;
    }


    // Start is called before the first frame update
    void Start()
    {
        upgradeHolder = new Upgrade[upgradeCount];

        LoadUpgrades();


    }

    void OnUpgradesLoaded(SavedData sv)
    {

        upgradeHolder = new Upgrade[upgradeCount];
        LoadUpgrades();
    }

    void LoadUpgrades()
    {
        upgradeHolder = new Upgrade[upgradeCount];

        Upgrade[] upgrades = UpgradePersistentData.GetUpgrades(upgradeControllerId);
        if (upgrades != null)
        {
            foreach (Upgrade up in upgrades)
            {
                if (up != null)
                {
                    PlaceUpgrade(up);
                }
            }
        }
    }

    private void OnDestroy()
    {
        SaveManager.onAfterLoaded -= OnUpgradesLoaded;
        UpgradePersistentData.upgrades[upgradeControllerId] = upgradeHolder;
    }


    public bool PlaceUpgrade(Upgrade upgrade)
    {
        bool wasPlaced = false;
        
        if (!HasUpgradeByName(upgrade.upgradeName))
        {
            for (int i = 0;i<upgradeHolder.Length;i++)
            {
                if (upgradeHolder[i] == null)
                {
                    wasPlaced = true;
                    upgradeHolder[i] = upgrade;

                    onUpgradePlaced?.Invoke(i, upgrade);

                    if (!preventUse)
                    {
                        upgrade.OnPut(gameObject);
                    }

                    break;
                }
            }
        }

        return wasPlaced;
    }

    public void RemoveUpgradeAt(int slot)
    {
        if (slot >= 0 && slot < upgradeHolder.Length)
        {
            Upgrade upgrade = upgradeHolder[slot];
            if (upgrade != null)
            {
                if (!preventUse)
                {
                    upgrade.OnRemove();
                }
                upgradeHolder[slot] = null;
                onUpgradeRemoved?.Invoke(slot, upgrade);
            }
        }
    }

    public bool RemoveUpgradeAt(Upgrade upgrade)
    {
        bool wasRemoved = false;
        for (int i = 0; i < upgradeHolder.Length; i++)
        {
            if (upgradeHolder[i] == upgrade)
            {
                wasRemoved = true;
                RemoveUpgradeAt(i);
                break;
            }
        }

        return wasRemoved;
    }

    public bool HasUpgradeByName(string upgradeName)
    {
        return ArrayUtils.Exist<Upgrade>(upgradeHolder, (Upgrade upg) => { return upg?.upgradeName == upgradeName; });
    }

    public int FindUpgradeByName(string upgradeName)
    {
        return ArrayUtils.Find<Upgrade>(upgradeHolder, (Upgrade upg) => { return upg?.upgradeName == upgradeName; }); 
    }

    
}
