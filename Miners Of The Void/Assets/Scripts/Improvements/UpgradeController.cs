
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeController : MonoBehaviour
{
    public Array<Upgrade> upgradeHolder;
    public UnityEvent<Upgrade,int> onUpgradePut;
    public UnityEvent<Upgrade,int> onUpgradeRemoved;
    // Start is called before the first frame update
    void Start()
    {
        upgradeHolder = new Array<Upgrade>(4);
        if (gameObject.tag == "Player") 
        {
            foreach (Upgrade up in UpgradeTransporter.humanPlayer) {
                PlaceUpgrade(up);
                Debug.Log(up.upgradeName);
            }
        }
        if (gameObject.tag == "Spaceship")
        {
            foreach (Upgrade up in UpgradeTransporter.spaceship)
                PlaceUpgrade(up);
        }

       
        
    }

    

    public bool PlaceUpgrade(Upgrade upgrade)
    {
        bool wasPlaced = false;
        if (!HasUpgradeByName(upgrade.upgradeName))
        {
            int cIndex = upgradeHolder.Count;
            wasPlaced = upgradeHolder.InsertAtEnd(upgrade);
            if (wasPlaced)
            {
                OnUpgradeAdded(upgrade, cIndex);

            }
        } else
        {
            for (int i = 0;i<upgradeHolder.Count;i++)
            {
                Upgrade upg = upgradeHolder.Get(i);
                if (upg != null && upg.upgradeName.Equals(upgrade.upgradeName))
                {
                    if (upg.level + upgrade.level <= upgrade.maxLevel) {
                        upg.level += upgrade.level;
                        OnUpgradeAdded(upg, i);
                        wasPlaced = true;
                    }
                }
            }
        }

        return wasPlaced;
    }

    public bool HasUpgradeByName(string upgradeName)
    {
        foreach (Upgrade upg in upgradeHolder)
        {
            if (upg.upgradeName == upgradeName)
            {
                return true;
            }
        }

        return false;
    }

    public void TakeOfUpgrade(Upgrade upgrade)
    {
        for (int i = 0;i< upgradeHolder.Count;i++)
        {
            if (upgradeHolder.Get(i).Equals(upgrade))
            {
                upgradeHolder.RemoveAt(i);
                break;
            }
        }
        upgrade.OnRemove();
    }

    public void TakeOfUpgrade(string upgradeName)
    {
        Upgrade temp = null;
        for (int i = 0; i < upgradeHolder.Count; i++)
        {
            if (upgradeHolder.Get(i) != null)
            {
                if (upgradeHolder.Get(i).upgradeName.Equals(upgradeName))
                {
                    temp = upgradeHolder.Get(i);
                    upgradeHolder.RemoveAt(i);
                    break;
                }
            }
        }
        if (temp != null) temp.OnRemove();
    }

    public void TakeOfUpgrade(int slot)
    {
       Upgrade upgrade = upgradeHolder.Get(slot);
        upgrade.OnRemove();
        upgradeHolder.RemoveAt(slot);
        onUpgradeRemoved?.Invoke(upgrade,slot);

    }

    private void OnUpgradeAdded(Upgrade upgrade,int index)
    {
        upgrade.OnPut(gameObject);
        onUpgradePut.Invoke(upgrade,index);

        if(gameObject.tag == "Player") UpgradeTransporter.humanPlayer = upgradeHolder;
        if (gameObject.tag == "Spaceship") UpgradeTransporter.spaceship = upgradeHolder;
        
        int i = -1;
        foreach (Upgrade up in upgradeHolder)
        {
            i++;
            Debug.Log(upgradeHolder.Get(i));
        }
    }
}
