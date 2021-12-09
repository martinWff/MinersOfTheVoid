using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeController : MonoBehaviour
{
    public Array<Upgrade> upgradeHolder = new Array<Upgrade>(4);
    public UnityEvent<Upgrade> onUpgradePut;
    public UnityEvent<Upgrade> onUpgradeRemoved;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Upgrade upgrade in upgradeHolder)
        {
            if (upgrade != null)
            {
                upgrade.OnUpdate();
            }
        }
    }

    public bool PlaceUpgrade(Upgrade upgrade)
    {
        bool wasPlaces = upgradeHolder.InsertAtEnd(upgrade);
        if (wasPlaces)
        {
            OnUpgradeAdded(upgrade);
            
        }

        return wasPlaces;
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

    public void TakeOfUpgrade(int slot)
    {
       Upgrade upgrade = upgradeHolder.Get(slot);
        upgrade.OnRemove();
        upgradeHolder.RemoveAt(slot);
        onUpgradeRemoved?.Invoke(upgrade);

    }

    private void OnUpgradeAdded(Upgrade upgrade)
    {
        upgrade.OnPut(gameObject);
        onUpgradePut.Invoke(upgrade);
    }
}
