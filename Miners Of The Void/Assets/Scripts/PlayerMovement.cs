using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float minRotationDistance = 40;
    public float moveForce = 4;
    public GameObject bulletPrefab;
    public float bulletOffset = 1.5f;
    public float bulletSpeed = 14;
    public float bulletCooldownTime = 0.5f;
    private float bulletShootTime = 0.5f;
    float verticalInput;
    float horizontalInput;
    private Vector3 test;
    public bool firepermission = true;
    public StaticCameraController camera;
    public GameObject enemy;

    // Life
    public float playerDamage = 10;
    public float totalShield = 20;
    public float shield = 20;
    public float hp = 20;

    public float speedLevel = 1;
    public float dmgLevel = 1;
    public float shieldLevel = 1;
    public float healthLevel = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        camera = GameObject.Find("MainCamera").GetComponent<StaticCameraController>();
        float fireInput = Input.GetAxis("Fire1");
        if (fireInput > 0 && (bulletShootTime <= 0) && firepermission == true)
        {
            Vector3 mouseDirection = Input.mousePosition -
               Camera.main.WorldToScreenPoint(transform.position);
            Vector3 Shotdirection = mouseDirection;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + (Shotdirection.normalized * bulletOffset), Quaternion.identity);
            bulletShootTime = bulletCooldownTime;
            bullet.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;
        }
        if (bulletShootTime >= 0)
        {
            bulletShootTime -= Time.deltaTime;
            
        }
        

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Passage")
        {
            camera.Human = false;
            camera.ChangeCamera();
            SpaceshipMovement player2 = GameObject.Find("PlayerSpaceship").GetComponent<SpaceshipMovement>();
            player2.enabled = true;
            player2.Revive();
            rb.velocity = new Vector2(0, 0);
            enemy.GetComponent<Enemy>().enabled = true;
            enemy.GetComponent<SpaceEnemyMove>().enabled = true;
            GetComponent<PlayerMovement>().enabled = false;
            
            
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = (verticalInput * Vector2.up * moveForce) + (horizontalInput * Vector2.right * moveForce);
    }

   
}
