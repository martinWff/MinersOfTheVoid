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

    private void Update()
    {
        if (currentBips != SavePlayerStats.bips)
        {
            currentBips = SavePlayerStats.bips;
            bipsText.text = "Bips: " + currentBips;
        }
        if (experienceText != null)
        {
            if (currentXP != SavePlayerStats.rp)
            {
                experienceText.text = "XP: "+SavePlayerStats.rp+"/"+SavePlayerStats.GetRequiredRP();
            }
        }
    }
}
