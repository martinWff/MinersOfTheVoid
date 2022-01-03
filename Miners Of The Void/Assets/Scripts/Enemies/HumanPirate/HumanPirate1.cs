using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPirate1 : MonoBehaviour
{
    private GameObject player;
    private float Distance;

    //Enemy shoot
    public GameObject bulletPrefab;
    public float bulletOffset = 4f;
    public float bulletSpeed = 14;
    public float bulletCooldownTime = 0.5f;
    private float bulletShootTime = 1.5f;
    public float enemyRange = 20;



    //Enemy rotation
    private Rigidbody2D enemy;



    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        enemy = this.GetComponent<Rigidbody2D>();



    }


    void Update()
    {
        if (player == null) return;
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.rotation = angle - 90;


        Distance = Mathf.Sqrt(Mathf.Pow(playerPosition.x - transform.position.x, 2) + Mathf.Pow(playerPosition.y - transform.position.y, 2));
        if (Distance < enemyRange)
        {

            Debug.Log("entra na area");

            if ((bulletShootTime <= 0))
            {


                //Debug.Log(bulletPrefab);
                Vector3 Shotdirection = Maths.TransformUp(gameObject);

                GameObject bullet = Instantiate(bulletPrefab, transform.position + (Shotdirection.normalized * bulletOffset), Quaternion.identity);

                bulletShootTime = bulletCooldownTime;
                bullet.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;
            }
            if (bulletShootTime >= 0)
            {
                bulletShootTime -= Time.deltaTime;
            }
        }
    }
}
