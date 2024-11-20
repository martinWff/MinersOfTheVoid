using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class MiningManager : MonoBehaviour
{
    public Transform character;

    public Grid grid;
    public Tilemap tilemap;

    public CharacterStat miningSpeed = new CharacterStat(2);

    public int dropRate;

    private Tile targetedTile;
    [SerializeField] float miningDuration;
    private float currentMiningDuration;

    public float miningRange;

    private Vector3Int miningPosition;

    public UnityEvent<Tile> onStartedMining;
    public UnityEvent<Tile> onCompletedMining;
    public UnityEvent onStoppedMining;

    private bool hasStoppedMining = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 characterForward = character.position + character.right;

            RaycastHit2D hit = Physics2D.Raycast(characterForward, mousePos - characterForward, miningRange);

            miningPosition = grid.WorldToCell(hit.point);
            targetedTile = tilemap.GetTile<Tile>(miningPosition);
            currentMiningDuration = 0;
            
            onStartedMining?.Invoke(targetedTile);

            hasStoppedMining = false;

        }

        if (targetedTile != null)
        {
            if (Vector3.Distance((Vector3)miningPosition,character.position) > miningRange)
            {
                targetedTile = null;
                currentMiningDuration = 0;
            }

            if (currentMiningDuration >= miningDuration)
            {
                OreResourceObject resourceObj = OreManager.instance.GetOreResourceByTile(targetedTile);

                Tile mined = targetedTile;

                targetedTile = null;

                if (resourceObj.materialResourceObjects.Length > 0)
                {
                    MaterialResourceObject matResourceObj = resourceObj.materialResourceObjects[0];

                    OreStack stack = matResourceObj.GetOreStack(dropRate);

                    InventoryBehaviour inv = character.GetComponent<InventoryBehaviour>();

                    inv.AddOre(stack);

                }

                tilemap.SetTile(miningPosition, null);

                onCompletedMining?.Invoke(mined);

            }
            else
            {
                currentMiningDuration += miningSpeed.value * Time.deltaTime;
            }
        } else
        {
            if (!hasStoppedMining)
            {
                onStoppedMining?.Invoke();
                hasStoppedMining = true;
            }
        }
    }

    public float GetProgress()
    {
        return currentMiningDuration / miningDuration;
    }

    public bool IsMining()
    {
        return !hasStoppedMining;
    }
}
