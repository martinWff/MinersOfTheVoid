using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float Distance;

    //Enemy shoot
    public GameObject bulletPrefab;
    public float bulletOffset = 1.5f;
    public float bulletSpeed = 14;
    public float bulletCooldownTime = 0.5f;
    private float bulletShootTime = 0.5f;
    public float enemyRange = 20;
    private Bullet bullet;

    //Enemy stats
    public float enemieHealth = 20;
    public float totalShield = 10;
    public float shield = 10;
    public float playerdmg;
    


    //Enemy rotation
    private Rigidbody2D enemy;



    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Spaceship");
        Debug.Log(player);
        enemy = this.GetComponent<Rigidbody2D>();
        playerdmg = player.GetComponent<SpaceshipMovement>().playerDamage;
        Debug.Log(playerdmg);
        bullet = bulletPrefab.GetComponent<Bullet>();
        
        



    }


    void Update()
    {
        if (player == null) return;
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.rotation = angle - 90;

        Distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.y - transform.position.y, 2));
        if (Distance < enemyRange)
        {



            if ((bulletShootTime <= 0))
            {


                Debug.Log(bulletPrefab);
                Vector3 Shotdirection = transform.up;
                GameObject bullet = Instantiate(bulletPrefab, transform.position + (Shotdirection.normalized * bulletOffset), Quaternion.identity);
                bulletShootTime = bulletCooldownTime;
                bullet.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;
            }
            if (bulletShootTime >= 0)
            {
                bulletShootTime -= Time.deltaTime;
            }
        }

        //status/UI
        if (shield < totalShield)
        {
            shield += (totalShield / 10) * Time.deltaTime;
        }
        if (shield > totalShield) shield = totalShield;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            if (shield >= playerdmg) shield -= playerdmg;
            if (shield < playerdmg)
            {
                if (shield != 0) enemieHealth -= (10 - shield);

                shield = 0;
            }
            if (enemieHealth <= 0)
            {
                enemieHealth = 0;
                shield = 0;
                Destroy(gameObject);
            }

            Debug.Log("health: " + enemieHealth + "\nshield: " + shield);

            Destroy(collision.gameObject);
        }
    }



}