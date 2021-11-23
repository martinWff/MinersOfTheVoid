using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    [SerializeField] private lifebar lifebar;

    public float playerDamage = 10;
    public float enemyLife = 100;
    private float perEnemyLife;

    // Start is called before the first frame update
    void Start()
    {
        DealDamage();
        lifebar.Setsize(perEnemyLife);
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        float currentEnemyLife = enemyLife - playerDamage;
        perEnemyLife = currentEnemyLife / enemyLife;
        

    }
}
