using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseeIII : MonoBehaviour
{

    [SerializeField] public GameObject pirate;
    [SerializeField] public GameObject pirateexplosion;
    [SerializeField] public GameObject boss;

    //level complete
    public bool levelComplete = false;

    //spawn enemies
    private bool spawnEnemies = false;


    void Start()
    {
        SpawnEnemies();
    }


    private void SpawnEnemies()
    {
        if (spawnEnemies == false)
        {


            Instantiate(pirate, new Vector3(Random.Range(-19, 19), boss.transform.position.y - 4, 0), Quaternion.identity);

            Instantiate(pirate, new Vector3(Random.Range(-19, 19), boss.transform.position.y - 4, 0), Quaternion.identity);

            Instantiate(pirateexplosion, new Vector3(Random.Range(-19, 19), boss.transform.position.y - 4, 0), Quaternion.identity);


            spawnEnemies = true;
            
        }
    }

    
}
