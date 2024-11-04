using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime = 5;

    public float damage;

    public string ignoreTag;

    void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.CompareTag(ignoreTag))
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }



}
