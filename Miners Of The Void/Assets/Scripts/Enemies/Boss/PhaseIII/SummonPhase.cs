using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummonPhase : PhaseBase
{

    [SerializeField] public GameObject pirate;
    [SerializeField] public GameObject pirateexplosion;

    //level complete
    public bool levelComplete = false;

    //spawn enemies
    private bool hasSpawnedEnemies = false;

    //Arrays
    Array<GameObject> enemies = new Array<GameObject>(3);

    public Transform target;


    void OnEnable()
    {
 
    }


    private void SpawnEnemies()
    {
        if (!hasSpawnedEnemies)
        {

           
            enemies.InsertAtEnd(SpawnEnemy(pirate));

            enemies.InsertAtEnd(SpawnEnemy(pirate));

            enemies.InsertAtEnd(SpawnEnemy(pirateexplosion));

            
            //Debug.Log(enemies.Get(0));
         //   enemies.Get(2).GetComponentInChildren<PirateExploosion>().boss = EnemyDied;

            hasSpawnedEnemies = true;
            
        }
    }

    private GameObject SpawnEnemy(GameObject o)
    {  
        GameObject e = Instantiate(o, new Vector3(Random.Range(-19, 19), transform.position.y - 4, 0), Quaternion.identity);
        EnemyData data = e.GetComponent<EnemyData>();

        data.target = target;

        return e;
    }

    public override void OnPhaseBegan()
    {
        SpawnEnemies();

    }

    public override void OnTick()
    {
        for (int i = enemies.Length-1;i>=0;i--)
        {
            GameObject o = enemies.Get(i);
            if (o == null)
            {
                enemies.RemoveAt(i);
            }
        }
    }

    public override void OnPhaseFinished()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        hasSpawnedEnemies = false;
    }

}
