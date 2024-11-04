using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    public float shield = 10;
    public CharacterStat maxShield = new CharacterStat(10);
    public CharacterStat maxHP = new CharacterStat(20);
    public float hp = 20;
    public bool immortality = false;

    public UnityEvent<float> onDamage;
    public UnityEvent onDied;
    

    // Update is called once per frame
    void Start()
    {

    }

    private void Update()
    {

        if (shield < maxShield.value)
        {
            shield += (maxShield.value / 10) * Time.deltaTime;
        }
        if (shield > maxShield.value) shield = maxShield.value;
    }

    public void TakeDamage(float dmg)
    {
        if (!immortality)
        {
            if (shield >= dmg)
            {
                shield -= dmg;
            }
            if (shield < dmg)
            {
                shield = 0;
                hp -= (dmg - shield);
            }

            onDamage?.Invoke(dmg);

            if (hp <= 0)
            {
                onDied?.Invoke();
            }
        }
    }
}
