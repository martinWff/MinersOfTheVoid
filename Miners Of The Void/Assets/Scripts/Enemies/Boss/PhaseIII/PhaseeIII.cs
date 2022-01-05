using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseeIII : MonoBehaviour
{

    [SerializeField] public GameObject pirate;
    [SerializeField] public GameObject pirateexplosion;
    [SerializeField] public GameObject boss;

    //level complete
    public bool levelComplete = false;

    //spawn enemies
    private bool spawnEnemies = false;

    //Arrays
    Array<GameObject> enemies;
    void Start()
    {
        levelComplete = false;
        enemies = new Array<GameObject>(3);
        SpawnEnemies();
 
    }


    private void SpawnEnemies()
    {
        if (spawnEnemies == false)
        {

           
            enemies.InsertAtEnd(Instantiate(pirate, new Vector3(Random.Range(-19, 19), boss.transform.position.y - 4, 0), Quaternion.identity));

            enemies.InsertAtEnd(Instantiate(pirate, new Vector3(Random.Range(-19, 19), boss.transform.position.y - 4, 0), Quaternion.identity));

            enemies.InsertAtEnd(Instantiate(pirateexplosion, new Vector3(Random.Range(-19, 19), boss.transform.position.y - 4, 0), Quaternion.identity));
            //Debug.Log(enemies.Get(0));
            enemies.Get(0).GetComponentInChildren<Enemy>().boss = EnemyDied;
            enemies.Get(1).GetComponentInChildren<Enemy>().boss = EnemyDied;
            enemies.Get(2).GetComponentInChildren<PirateExplosion>().boss = EnemyDied;

            spawnEnemies = true;
            
        }
    }

    private void EnemyDied(GameObject enemy)
    {
        //Debug.Log("aaaaaaaaaaaaaaaaaa  " + enemies.Contains(enemy) +"   "+ enemy);
        if (enemies.Contains(enemy))
        {
         
            enemies.RemoveAt(enemies.Find(enemy));
        }

        //Debug.Log(enemies.Count);
        if (enemies.Count == 0 && SceneManager.GetActiveScene().name == "HugoScene")
        {
            Debug.Log("Every enemy DIED !!!!");
            levelComplete = true;
        }

    }


}
