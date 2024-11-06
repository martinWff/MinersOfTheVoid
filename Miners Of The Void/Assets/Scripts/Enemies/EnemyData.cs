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

    public int experienceReward;


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

            PersistentData persistentData = FindObjectOfType<PersistentDataController>().persistentData;
            persistentData.bips += Random.Range(minimumPrize, maximumPrize);
            persistentData.xp += experienceReward;
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
