using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public UpgradeUIController upgradeControllerUI;
    public virtual Upgrade GetUpgrade(int level)
    {
        return null;
    }
}
