using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    // Get the pirate prefab and spawn
    public GameObject piratePrefab;
    public float respawnTime = 1;

    // Spawn area
    public int areaRadius = 20;
    private int _areaRadius;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(piratePrefab) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (areaRadius != _areaRadius)
        {
            transform.localScale = new Vector2(transform.localScale.x + areaRadius, transform.localScale.y + areaRadius);
            areaRadius = _areaRadius;
        }
    }
}
