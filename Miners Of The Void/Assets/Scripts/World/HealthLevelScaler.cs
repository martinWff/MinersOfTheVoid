using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthLevelScaler : MonoBehaviour
{
    [SerializeField] Health health;

    public float healthMultiplier;
    public float shieldMultiplier;

    [SerializeField] PersistentData persistentData;

    // Start is called before the first frame update
    void Start()
    {
        health.maxHP.baseValue = persistentData.level * healthMultiplier;
        health.maxShield.baseValue = persistentData.level * shieldMultiplier;
    }

}
