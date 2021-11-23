using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MaterialResourceObject : ScriptableObject
{
    public int resourceId;
    public string resourceName;
    public ResourceType resourceType;
    public Sprite sprite;

    public void Init()
    {
        int asciiCode = 0;
        foreach (char stringCharacter in name)
        {
            asciiCode += (int)stringCharacter;
        }
        resourceId = asciiCode;
    }

    public OreStack GetOreStack(int amount = 1)
    {
        return new OreStack(resourceName, amount, sprite);
    }
}

public enum ResourceType
{
    ore,
    nugget,
    ingot,
    plate
}
