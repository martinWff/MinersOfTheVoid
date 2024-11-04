using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BipsUIController : MonoBehaviour
{
    public Text bipsText;
    public Text experienceText;
    private int currentBips = -1;
    private int currentXP = -1;

    public PersistentData persistentData;

    private void Update()
    {
        if (currentBips != persistentData.bips)
        {
            currentBips = persistentData.bips;
            bipsText.text = "Bips: " + currentBips;
        }
        if (experienceText != null)
        {
            if (currentXP != persistentData.xp)
            {
                experienceText.text = "XP: "+persistentData.xp+"/"+persistentData.requiredXP;
            }
        }
    }
}
