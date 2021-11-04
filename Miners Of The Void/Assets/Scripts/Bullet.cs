using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime = 5;
    public bool friendlyFire = true;
    GameObject player;
    SpaceshipMovement sM;
    void Start()
    {

        Destroy(gameObject, bulletLifeTime);

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "BulletEnemie")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
