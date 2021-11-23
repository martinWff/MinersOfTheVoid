using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class OreResourceObject : ScriptableObject
{
    public string oreName;
    public Sprite oreSprite;
    public MaterialResourceObject[] materialResourceObjects;
    public Tile tile;
    public OreRarity oreBaseRarity;
  
}
