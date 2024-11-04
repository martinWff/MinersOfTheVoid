using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipUpgradeButton : MonoBehaviour
{
    public Upgrade upgrade;
    public UpgradeController controller;

    public void OnPressed()
    {
        controller.PlaceUpgrade(upgrade);
    }
}
