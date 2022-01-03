using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPirate : MonoBehaviour
{
    //stats
    public int moveSpeed = 10;
    public int pirateLife = 100;
    public int pirateDamage = 10;

    //Enemy shoot
    public GameObject bulletPrefab;
    public float bulletOffset = 4f;
    public float bulletSpeed = 14;
    public float bulletCooldownTime = 4f;
    private float bulletShootTime = 1.5f;

    //Gameobjects
    private GameObject player;

    //Distance
    private float Distance;
    public float enemyRange = 20;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        

        Distance = Mathf.Sqrt(Mathf.Pow(playerPosition.x - transform.position.x, 2) + Mathf.Pow(playerPosition.y - transform.position.y, 2));
        if (Distance < enemyRange)
        {

            //Debug.Log("entra na area do enemi");
            if ((bulletShootTime <= 0))
            {


                Debug.Log("player position: "+ player.transform.position);
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
