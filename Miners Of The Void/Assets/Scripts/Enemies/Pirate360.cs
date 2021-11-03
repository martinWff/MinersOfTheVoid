using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate360 : MonoBehaviour
{
    private GameObject player;
    private float Distance;

    //Enemy shoot
    public GameObject bulletPrefab;
    public float bulletOffset = 4f;
    public float bulletSpeed = 14;
    public float bulletCooldownTime = 4f;
    private float bulletShootTime = 1.5f;
    public float enemyRange = 20;


    public int bulletsAmount = 10;

    //angle
    public float startAngle;
    public float endAngle;
    public float firstAngle = 0;
    public float secondAngle = 360;

    public float middleAngle;
    private Rigidbody2D rb;
    float currentAngle;


    //Enemy rotation
    private Rigidbody2D enemy;



    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        enemy = this.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();



    }


    void Update()
    {
        if (player == null) return;
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.rotation = angle - 90;
        middleAngle = rb.rotation + 90;
        Debug.Log("Angle: " + middleAngle);

        startAngle = middleAngle - firstAngle;
        endAngle = middleAngle + secondAngle;

        


        

        Distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.y - transform.position.y, 2));
        if (Distance < enemyRange)
        {



            if ((bulletShootTime <= 0))
            {


                Debug.Log(bulletPrefab);

                float angleStep = (firstAngle - secondAngle) / bulletsAmount;
                currentAngle = middleAngle - firstAngle;


                while (currentAngle < endAngle)
                {
                    currentAngle += angleStep;

                    Vector3 Shotdirection = new Vector3(Mathf.Cos(currentAngle  * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad), transform.position.z);

                    GameObject bullet = Instantiate(bulletPrefab, transform.position + (Shotdirection.normalized * bulletOffset), Quaternion.identity);

                    bulletShootTime = bulletCooldownTime;
                    bullet.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;
                }
                




            }
            if (bulletShootTime >= 0)
            {
                
                bulletShootTime -= Time.deltaTime;
            }
        }
    }


}