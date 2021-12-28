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

    public MaterialResourceObject GetOreMaterialByMaterialName(string materialName, out int index)
    {
        
        index = -1;
        foreach (OreResourceObject oreResourceObject in ores)
        {
            if (oreResourceObject != null)
            {

                for (int i = 0; i < oreResourceObject.materialResourceObjects.Length; i++)
                {
                   

                    if (oreResourceObject.materialResourceObjects[i].resourceName == materialName)
                    {
                        index = i;
                        return oreResourceObject.materialResourceObjects[i];

                    }
                }
            }
        }
        return null;
    }


    public MaterialResourceObject GetOreMaterialByMaterialName(string materialName)
    {
        foreach (OreResourceObject oreResourceObject in ores)
        {
            if (oreResourceObject != null)
            {

                for (int i = 0; i < oreResourceObject.materialResourceObjects.Length; i++)
                {
                    if (oreResourceObject.materialResourceObjects[i].resourceName == materialName)
                    {

                        return oreResourceObject.materialResourceObjects[i];
                    }
                }
            }
        }
        return null;
    }

    public OreResourceObject GetOreResourceFromMaterial(MaterialResourceObject mat)
    {
        if (mat != null)
        {
            return GetOreResourceByName(mat.resourceName);
        }
        else return null;
    }

    public OreResourceObject GetOreResourceFromMaterialName(string materialName)
    {
        foreach (OreResourceObject oreResourceObject in ores)
        {
            foreach (MaterialResourceObject material in oreResourceObject.materialResourceObjects)
            {
                if (material.resourceName == materialName)
                {
                    return oreResourceObject;
                }
            }
        }
        return null;
    }

    public OreResourceObject[] GetOreResourcesObjets()
    {
        return ores;
    }

}

[System.Serializable]
public class OreElementTile
{
    public string oreName;
    public Tile tile;
    public Sprite sprite;
}