using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreChunk : MonoBehaviour
{
    public string[] ores = new string[30];
    public OreDistributtor distributor;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ores.Length; i++) {
            ores[i] = distributor.Calculate();
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
