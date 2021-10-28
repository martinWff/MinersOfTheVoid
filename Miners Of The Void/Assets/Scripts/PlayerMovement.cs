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
    private float angle = 90;
    float verticalInput;
    float horizontalInput;
    private Vector3 test;
    public bool firepermission = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        float fireInput = Input.GetAxis("Fire1");
        if (fireInput > 0 && (bulletShootTime <= 0) && firepermission == true)
        {
            Vector3 Shotdirection = transform.right;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + (Shotdirection.normalized * bulletOffset), Quaternion.identity);
            bulletShootTime = bulletCooldownTime;
            bullet.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;
        }
        if (bulletShootTime >= 0)
        {
            bulletShootTime -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = (verticalInput * Vector2.up * moveForce) + (horizontalInput * Vector2.right * moveForce);
    }

   
}
