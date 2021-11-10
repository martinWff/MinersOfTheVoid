using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreDistributtor : MonoBehaviour
{
    public OreElement[] ores = new OreElement[3+2]; //3 commons and 2 rare;


    private OreElement[] oresDistributted = new OreElement[3 + 2];
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Distribute(int index)
    {
        OreElement element = ores[index];
        oresDistributted[index] = ores[index];

    }

    
}

[System.Serializable]
public class OreElement
{
    public string oreName;
    public OreRarity rarity;
}

public enum OreRarity
{
    Common,
    Rare
}