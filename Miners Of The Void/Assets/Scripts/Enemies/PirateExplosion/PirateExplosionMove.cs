using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateExplosionMove : MonoBehaviour
{
    //movement
    [SerializeField] PirateExplosion pirate;

    //enemy
    [SerializeField]private Rigidbody2D rb;

    private void FixedUpdate()
    {
        if (pirate.isAttacking)
        {
            rb.velocity = (pirate.targetPosition - transform.position).normalized * pirate.speed;
        }
    }
}
