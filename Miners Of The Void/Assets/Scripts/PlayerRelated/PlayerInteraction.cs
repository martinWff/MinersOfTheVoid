using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInteraction : MonoBehaviour
{

    private Vector3 currentPosition;
    private Quaternion currentDirection;
    public KeybindController controller;
    public int range;
    public Vector3 offset;
    public Tilemap colliderMap;
    private float xOffset;
    private float holdTime = 0;
    public float defaultHoldTime;
    private string interactableTargeted;
    private Vector3Int targetedVector;
    private Vector3Int previousVector;
    private RaycastHit2D previousHit;
    private bool reload = true;

    public int dropAmount = 2;

    public CharacterStat precision;
    public CharacterStat miningSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        xOffset = transform.localScale.x;
        holdTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //   Debug.DrawLine((transform.position + transform.up), (transform.position + transform.up)+offset);
        Debug.DrawLine(transform.position, transform.position + (transform.right*2));
        if (currentPosition != transform.position || currentDirection != transform.rotation || reload)
        {
            currentPosition = transform.position;
            currentDirection = transform.rotation;
            reload = false;

            //    RaycastHit2D raycastHit = Physics2D.Raycast(transform.position + (transform.right * xOffset), transform.right,range,LayerMask.GetMask("Interactable"));
            //RaycastHit2D raycastHit = Physics2D.Raycast(transform.position + (transform.up), transform.right, range, LayerMask.GetMask("Interactable"));
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position + (transform.right * 2), transform.right, range, LayerMask.GetMask("Interactable"));


            if (raycastHit)
            {

                //   targetedVector = colliderMap.WorldToCell(transform.position+(transform.right* (raycastHit.distance+0.5f)));
                //    targetedVector = colliderMap.WorldToCell(transform.position + (transform.right * (raycastHit.distance)));
                targetedVector = colliderMap.WorldToCell(transform.position + (transform.right * (raycastHit.distance+1f)));


                Vector3 vec = colliderMap.CellToWorld(targetedVector);
                    Tile targetTile = colliderMap.GetTile<Tile>(targetedVector);
                if (targetTile != null)
                {
                    OreResourceObject oreResourceObject = OreManager.instance.GetOreResourceByTile(targetTile);

                    if (oreResourceObject != null)
                    {
                        
                        interactableTargeted = oreResourceObject.oreName;
                        controller.SetDetail($"Mine {oreResourceObject.oreName}");

                        //    colliderMap.SetTile(intVec, null);
                        //    oreTilemap.SetTile(vec, null);
                    }
                    previousHit = raycastHit;
                    controller.Show(true, vec+offset);
                    
                    if (targetedVector != previousVector)
                    {
                        previousVector = targetedVector;
                        holdTime = 0;
                    }
                } else
                {
                    interactableTargeted = null;
                    controller.Show(false, Vector2.zero);
                }
                



               } else
                 {
                interactableTargeted = null;
                controller.Show(false, Vector2.zero);
                  }
        }

        if (Input.GetButton("Interaction"))
        {
            if (holdTime >= defaultHoldTime)
            {
                if (interactableTargeted != null)
                {
                  //  TooltipController.SetText($"Ore: {interactableTargeted}");
                    colliderMap.SetTile(targetedVector, null);
                    reload = true;
                    MaterialResourceObject mat = OreManager.instance.GetOreMaterialByMaterialName(interactableTargeted);
                    if (mat != null)
                    {
                        PlayerInventory.staticInventory.AddOre(mat.GetOreStack(2));
                    }
                    
                    //    oreTilemap.SetTile(vec, null);
                }
            }
            else
            {
                float v = Time.deltaTime;
                holdTime += v;
                controller.SetProgress(holdTime,defaultHoldTime);
                

            }
        }


        if (Input.GetButtonUp("Interaction"))
        {
            holdTime = 0;
            controller.ResetProgress();
        }
    }
}
