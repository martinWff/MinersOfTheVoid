using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;
public class InteractionBehaviour : MonoBehaviour
{
    public List<Tile> breakables = new List<Tile>();

    public List<Tile> interactables = new List<Tile>();
    public UnityAction<Tile> onInteracted;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
}
