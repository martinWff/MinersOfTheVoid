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
        //bulletLifeTime = 5;
        //EnemyPool.bulletInstanse.ReturnBullet(gameObject);
        Destroy(gameObject, bulletLifeTime);
    }

    private void Update()
    {
        /*bulletLifeTime -= Time.deltaTime;
        if(bulletLifeTime <= 0)
        {
            EnemyPool.bulletInstanse.ReturnBullet(gameObject);
        }*/
    }



    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
{
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "BulletEnemie")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
