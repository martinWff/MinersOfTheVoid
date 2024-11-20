using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OreDistributtor : MonoBehaviour
{
    public OreElement[] ores = new OreElement[3 + 2]; //3 commons and 2 rare;

    public float[] table = new float[5];
    [SerializeField]private float amountOfRocksToGenerate = 1;

    public List<OreElement> distribution = new List<OreElement>(3+5);

    public Dictionary<string, int> distributionTable = new Dictionary<string, int>(5);

    private List<OreDistributionElement> distributions = new List<OreDistributionElement>();

    private int numberOfRocks;


//    private List<OreGenerator> oreSpawners = new List<OreGenerator>();
    // Start is called before the first frame update

    public void SetNumberOfRocks(int n)
    {
        numberOfRocks = n;

        GenerateDistributionPool();
        for (int i = 0; i < table.Length; i++)
        {
            amountOfRocksToGenerate -= table[i];

        }
        distributions.Add(new OreDistributionElement("Rock", (int)(amountOfRocksToGenerate * numberOfRocks)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string Calculate()
    {
        if (distributions.Count > 0)
        {

            // int v = Random.Range(0, ores.Length - 1);

            int v = Random.Range(0, distributions.Count);

            int index = distributions.FindIndex((OreDistributionElement e) => { return e.oreName == distributions[v].oreName; });
         //   Debug.Log("found index ? " + index);
            if (index >= 0)
            {
                OreDistributionElement element = distributions[index];
                element.amount--;
                if (element.amount <= 0)
                {
                    distributions.RemoveAt(index);
                }
                else
                {
                    distributions[index] = element;
                }

                return element.oreName;
            }
            else
            {
                return null;
            }
        } else
        {
            return null;
        }

    }


    //if rarity is 40% than its 4 in 10
   public void GenerateDistributionPool()
    {

        for (int i = 0; i < table.Length; i++)
        {
            
            float percentage = table[i];

            int amount = Mathf.FloorToInt((numberOfRocks * percentage));//(int)(percentage / numberOfRocks);
            distributions.Add(new OreDistributionElement(ores[i].oreName, amount));

        }
        
    }


}

[System.Serializable]
public class OreElement
{
    public string oreName;
    public OreRarity rarity;
}

[System.Serializable]
public struct OreDistributionElement
{
    public string oreName;
    public int amount;

    public OreDistributionElement(string oreName,int amount)
    {
        this.oreName = oreName;
        this.amount = amount;
    }
}

public enum OreRarity
{
    Common,
    Rare
}