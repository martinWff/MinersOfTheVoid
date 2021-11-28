using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float Distance;
    

    [SerializeField] public lifebar lifebar;
    [SerializeField] public shieldbar shieldbar;


    //Enemy shoot
    public GameObject bulletPrefab;
    public float bulletOffset = 4f;
    public float bulletSpeed = 14;
    public float bulletCooldownTime = 0.5f;
    private float bulletShootTime = 0.5f;
    public float enemyRange = 20;
    private Bullet bullet;

    //Enemy stats
    public float perEnemieHealthTotal = 1;
    public float perEnemieShieldTotal = 1;
    public float enemieHealthTotal = 20;
    public float enemieHealth = 20;
    public float totalShield = 10;
    public float shield = 10;
    public float playerdmg;
    private float perEnemyLife;
    private float perEnemyShield;



    //Enemy rotation
    private Rigidbody2D enemy;



    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Spaceship");
        //Debug.Log(player);
        enemy = this.GetComponent<Rigidbody2D>();
        playerdmg = player.GetComponent<SpaceshipMovement>().playerDamage;
        //Debug.Log(playerdmg);
        bullet = bulletPrefab.GetComponent<Bullet>();
        lifebar.Setsize(perEnemieHealthTotal);
        shieldbar.Setsize2(perEnemieShieldTotal);
        //Debug.Log(shieldbar);

    }


    void Update()
    {
        

        if (player == null) return;
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 direction = player.transform.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //enemy.rotation = angle - 90;

        Distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.y - transform.position.y, 2));
        if (Distance < enemyRange)
        {



            if ((bulletShootTime <= 0))
            {


                //Debug.Log(bulletPrefab);
                Vector3 Shotdirection = transform.up;

                //GameObject bullet = EnemyPool.bulletInstanse.GetEnemyBullet();
                //bullet.SetActive(true);
                //bullet.transform.position = transform.position + (Shotdirection.normalized * bulletOffset);
                //Debug.Log("posição da bala "+bullet.transform.position);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log(gameObject);

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
                SavePlayerStats.bips += (int)Random.Range(3,5);

                //Destroy(transform.parent);
                Destroy(gameObject);
            }

            Debug.Log("health: " + enemieHealth + "\nshield: " + shield);
            perEnemyLife = enemieHealth / enemieHealthTotal;
            perEnemyShield = shield / totalShield;
            lifebar.Setsize(perEnemyLife);
            shieldbar.Setsize2(perEnemyShield);


            Destroy(collision.gameObject);
        }
    }



}