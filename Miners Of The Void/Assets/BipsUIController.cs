using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BipsUIController : MonoBehaviour
{
    public Text bipsText;
    private int currentBips = -1;

    private void Update()
    {
        if (currentBips != SavePlayerStats.bips)
        {
            currentBips = SavePlayerStats.bips;
            bipsText.text = "Bips: " + currentBips;
        }
    }
}
