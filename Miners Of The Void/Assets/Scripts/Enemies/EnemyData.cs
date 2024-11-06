using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public bool isPlanetary;
    public string enemyName;

    public bool isDead { get; private set; }

    public Transform target;

    public int minimumPrize;
    public int maximumPrize;


    private void Start()
    {
        isDead = false;
    }
    public void OnKilled()
    {
        if (!isDead)
        {
            CombatSystem.onDied?.Invoke(enemyName,isPlanetary);
            isDead = true;
            Destroy(gameObject);

            FindObjectOfType<PersistentDataController>().persistentData.bips += Random.Range(minimumPrize, maximumPrize);

        }
    }

    public void OnDamageReceived(float amount)
    {
        if (!isDead)
        {
            CombatSystem.onDamageDealt?.Invoke(amount, enemyName, isPlanetary);
        }
    
    }
}
