using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OreManager : MonoBehaviour
{

    public OreResourceObject[] ores;

    public static OreManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public OreResourceObject GetOreResourceByName(string oreName)
    {
        foreach (OreResourceObject oreResourceObject in ores)
        {
            if (oreResourceObject != null)
            {
                if (oreResourceObject.oreName == oreName)
                {
                    return oreResourceObject;
                }
            }
        }
        return null;
    }

    public OreResourceObject GetOreResourceByTile(Tile tile)
    {
        foreach (OreResourceObject oreResourceObject in ores)
        {
            if (oreResourceObject != null)
            {
                if (oreResourceObject.tile == tile)
                {
                    return oreResourceObject;
                }
            }
        }
        return null;
    }
}

[System.Serializable]
public class OreElementTile
{
    public string oreName;
    public Tile tile;
    public Sprite sprite;
}