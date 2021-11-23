using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OreChunk : MonoBehaviour
{
    public string[] oreTiles;
    private Dictionary<string, Tile> tileDictionary = new Dictionary<string, Tile>();
    public OreDistributtor distributor;
    public Tile rockTile;
    public Tilemap tilemap;
    private List<Vector3Int> positions = new List<Vector3Int>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (OreElement element in distributor.ores) {
            OreResourceObject oreResource = OreManager.instance.GetOreResourceByName(element.oreName);
            if (oreResource != null)
            {
                tileDictionary.Add(oreResource.oreName, oreResource.tile);
            }
           }


        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(position) && tilemap.GetTile<Tile>(position) == rockTile)
            {
                positions.Add(position);
            }

            // Tile is not empty; do stuff
        }
        Debug.Log(positions.Count);
        oreTiles = new string[positions.Count];
        distributor.numberOfRocks = positions.Count;

        //  while (distributor.distributions.Count > 0)
        //  {
       
            for (int i = 0; i < oreTiles.Length; i++)
            {
                oreTiles[i] = distributor.Calculate();
            //  Debug.Log(oreTiles[i]);

                if (oreTiles[i] != null && oreTiles[i] != "Rock")
                {
                    if (tileDictionary.ContainsKey(oreTiles[i]))
                    {
                        tilemap.SetTile(positions[i], tileDictionary[oreTiles[i]]);
                    }
                }
            }
        // }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
