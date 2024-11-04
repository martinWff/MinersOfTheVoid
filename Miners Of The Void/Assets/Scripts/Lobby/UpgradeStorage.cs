using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStorage : MonoBehaviour
{
    public PersistentData persistentData;
    public List<Upgrade> unlockedUpgrades = new List<Upgrade>();
    // Start is called before the first frame update
    void Start()
    {
        if (persistentData.upgrades.TryGetValue(gameObject.name,out List<Upgrade> ups))
        {
            unlockedUpgrades.AddRange(ups);
        }
    }

    public Upgrade AddUpgrade(Upgrade upgrade)
    {
        Upgrade up = unlockedUpgrades.Find((Upgrade o) => o.upgradeName == upgrade.upgradeName);

        if (up == null)
        {
            unlockedUpgrades.Add(upgrade);

            up = upgrade;
        } else
        {
            up.level = Mathf.Min(up.level + upgrade.level,up.maxLevel);
        }

        return up;
    }

    private void OnDestroy()
    {
        persistentData.upgrades[gameObject.name] = new List<Upgrade>(unlockedUpgrades);
    }
}
