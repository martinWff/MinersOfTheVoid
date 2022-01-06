using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SavePlayerStats.exp >= SavePlayerStats.expNeeded)
        {
            int temp = SavePlayerStats.exp - SavePlayerStats.expNeeded;
            SavePlayerStats.WorldLevel++;
            SavePlayerStats.expNeeded = (int)Mathf.Floor(SavePlayerStats.expNeeded * 1.3f);
            SavePlayerStats.exp = temp;
        }
    }
}
