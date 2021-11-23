using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileInteractionManager : MonoBehaviour
{
    public OreResourceObject[] oreResourceObject;
    public Tilemap oreTilemap;
    public float holdTime = 3;
    private float defaultHoldTime = 3;

    public delegate void InteractionDone(Tile targetTile);
    public static event InteractionDone onInteractionDone;


    public delegate void InteractionUpdate(Tile targetTile);
    public static event InteractionUpdate onInteractionUpdate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            //    onInteractionUpdate.Invoke();
         
            Vector3Int vec = oreTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            Tile targetTile = oreTilemap.GetTile<Tile>(vec);

            OreResourceObject oreResourceObject = OreManager.instance.GetOreResourceByTile(targetTile);
            if (oreResourceObject != null)
            {
                TooltipController.SetText($"Ore: {oreResourceObject.oreName}");
                oreTilemap.SetTile(vec, null);
                //    oreTilemap.SetTile(vec, null);
            }
            
            
            

          // holdTime = defaultHoldTime;

        }
        if (Input.GetMouseButtonUp(0))
        {
            holdTime = defaultHoldTime;
        }
        if (Vector2.Distance(Input.mousePosition, TooltipController.currentMousePosition) >= 1f)
        {
            Vector3Int vec = oreTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Tile targetTile = oreTilemap.GetTile<Tile>(vec);
            OreResourceObject oreResourceObject = OreManager.instance.GetOreResourceByTile(targetTile);
            if (oreResourceObject != null)
            {
                TooltipController.Show(true);
                TooltipController.SetText($"Ore: {oreResourceObject.oreName}");
                //    oreTilemap.SetTile(vec, null);
            } else
            {
                TooltipController.Show(false);
            }
            TooltipController.currentMousePosition = Input.mousePosition;
            //
        }
    }
}
