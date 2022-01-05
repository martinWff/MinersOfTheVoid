
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeController : MonoBehaviour
{
    public Upgrade[] upgradeHolder;
    public static System.Action<UpgradeController,Upgrade,int> onUpgradePut;
    public static System.Action<UpgradeController,Upgrade, int> onUpgradeRemoved;
    // Start is called before the first frame update
    void Start()
    {
        upgradeHolder = new Upgrade[4];
        if (gameObject.tag == "Player") 
        {
            foreach (Upgrade up in UpgradeTransporter.humanPlayer) {
                PlaceUpgrade(up);
             //   Debug.Log(up.upgradeName);
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
        
        //    if (upgrade == null) return  false;
        int index = FindUpgradeByName(upgrade?.upgradeName);
        if (index < 0)
        {
         //   int cIndex = upgradeHolder.Length;
            /* for (int i = 0;i<upgradeHolder.Length;i++)
             {
                 Debug.Log(upgradeHolder.Get(i)+" "+i );
                 if (upgradeHolder.Get(i) == null)
                 {
                     Debug.Log("Empty "+i);
                     wasPlaced = upgradeHolder.InsertAt(upgrade, i);
                     cIndex = i;
                     break;
                 }
             }*/
            int last = ArrayUtils.Find<Upgrade>(upgradeHolder, (Upgrade upg) => { return upg == null; });
            int cIndex = last;
            upgradeHolder[last] = upgrade;
            
            wasPlaced = true;
          //  wasPlaced = upgradeHolder.InsertAtEnd(upgrade);
            if (wasPlaced)
            {
                Debug.Log("Shenhe is life" + upgrade);
                OnUpgradeAdded(upgrade, cIndex);
            }
        } else
        {
            Upgrade upg = upgradeHolder[index];

            if (upg != null)
            {
               if (upg.level + upgrade.level < upgrade.maxLevel)
                {
                    upg.level += upgrade.level;
                    OnUpgradeAdded(upg, index);
                    wasPlaced = true;
                } else
                {
                    upg.level = upgrade.maxLevel;
                    OnUpgradeAdded(upg, index);
                    wasPlaced = true;
                }
            }
        }

        return wasPlaced;
    }



    public bool HasUpgradeByName(string upgradeName)
    {
        return ArrayUtils.Exist<Upgrade>(upgradeHolder, (Upgrade upg) => { return upg?.upgradeName == upgradeName; });
    }

    public int FindUpgradeByName(string upgradeName)
    {
        return ArrayUtils.Find<Upgrade>(upgradeHolder, (Upgrade upg) => { return upg?.upgradeName == upgradeName; }); 
    }

    public void TakeOfUpgrade(Upgrade upgrade)
    {
        int index = FindUpgradeByName(upgrade.upgradeName);
        upgrade.OnRemove();
        upgradeHolder[index] = null;
    }

    public void TakeOfUpgrade(string upgradeName)
    {
        int index = FindUpgradeByName(upgradeName);
        if (index >= 0)
        {
            Upgrade value = upgradeHolder[index];
            value.OnRemove();
            upgradeHolder[index] = null;
        }
    }

    public void TakeOfUpgrade(int slot)
    {
       Upgrade upgrade = upgradeHolder[slot];
        if (upgrade != null)
        {
            UpgradeTransporter.upgradeSaver(upgrade.upgradeName, upgrade.level);
            upgrade.OnRemove();
            upgradeHolder[slot] = null;
            onUpgradeRemoved?.Invoke(this,upgrade, slot);
        }

    }

    private void OnUpgradeAdded(Upgrade upgrade,int index)
    {
        
        upgrade.OnPut(gameObject);
        onUpgradePut?.Invoke(this, upgrade,index);

        if(gameObject.tag == "Player") UpgradeTransporter.humanPlayer = upgradeHolder;
        if (gameObject.tag == "Spaceship") UpgradeTransporter.spaceship = upgradeHolder;
   
    }
}
