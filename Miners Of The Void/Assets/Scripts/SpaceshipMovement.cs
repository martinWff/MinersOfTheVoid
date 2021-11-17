using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float minRotationDistance = 40;
    

    //Shot
    public GameObject bulletPrefab;
    public float bulletOffset = 1.5f;
    public float bulletSpeed = 14;
    public float bulletCooldownTime = 0.5f;
    private float bulletShootTime = 0.5f;
    
    //movement
    float verticalInput;
    float horizontalInput;
    public float moveForce = 4;
    private Vector3 test;
    //status
    public float totalShield = 20;
    public float shield = 20;
    public float hp = 20;
    public GameObject statusDisplay;
    public Text statusDisplayText;
    public float playerDamage = 10;
  
    public float speedLevel = 1;
    public float dmgLevel = 1;
    public float shieldLevel = 1;
    public float healthLevel = 1;
    public bool backweaponMode = false;

    public GameObject upgradePrefab;
    public GameObject canvas;
    private StaticCameraController camera2;
    public bool dead = false;
    public bool immortality = false;
    public GameObject enemy;
    private Animator animator;
    
    //DisablingUI


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        statusDisplay = GameObject.Find("UiHpShield");
        statusDisplayText=statusDisplay.GetComponent<Text>();
        canvas = GameObject.Find("Canvas");
        animator = GetComponent<Animator>();
        camera2 = GameObject.Find("Main Camera").GetComponent<StaticCameraController>();
        


    }
    private void Update()
    {

        
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        float fireInput = Input.GetAxis("Fire1");
        if (fireInput > 0 && (bulletShootTime <= 0))
        {
            Vector3 Shotdirection = transform.right;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + (Shotdirection.normalized * bulletOffset),Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;

            if (backweaponMode)
            {
                Vector3 Shotdirection2 = -transform.right;
                GameObject bullet2 = Instantiate(bulletPrefab, transform.position + (Shotdirection2.normalized * bulletOffset), Quaternion.identity);
                bullet2.GetComponent<Rigidbody2D>().velocity = Shotdirection2.normalized * bulletSpeed;
            }
            bulletShootTime = bulletCooldownTime;
        }
        if (bulletShootTime >= 0)
        {
            bulletShootTime -= Time.deltaTime;
        }
        if (shield < totalShield)
        {
            shield += (totalShield / 10) * Time.deltaTime;
        }
        if (shield > totalShield) shield = totalShield;

        if (Input.GetKeyDown(KeyCode.Space)) Instantiate(upgradePrefab, canvas.transform);
        if (verticalInput != 0) animator.SetFloat("isMoving", 1);
        else animator.SetFloat("isMoving", -1);

    }

    private void FixedUpdate()
    {

        
        verticalInput = Input.GetAxis("Vertical");
        Vector2 mouseDirection = Input.mousePosition -
            Camera.main.WorldToScreenPoint(transform.position);
        if (mouseDirection.magnitude > minRotationDistance)
        {
            float angle = Mathf.Atan2(mouseDirection.normalized.y,
                                  mouseDirection.normalized.x) * Mathf.Rad2Deg;
            rb.SetRotation(angle);
        }
        rb.velocity = (verticalInput * transform.right) * moveForce;
        

        statusDisplayText.text = "Hp: " + Mathf.Floor(hp) + " / Shield: " + Mathf.Floor(shield);
        



        //rb.velocity = ((verticalInput * transform.right) +
        //              (horizontalInput * transform.up)) * moveForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemie" && !dead && !immortality)
        { 
            if (shield >= 10) shield -= 10;
            if (shield < 10)
            {   
                if (shield!=0) hp -= (10 - shield);

                shield = 0;
            }
            if (hp <= 0)
            {
                hp = 0;
                shield = 0;
                dead = true;
                TransferPlayer();
            }

            Destroy(collision.gameObject);
            //EnemyPool.bulletInstanse.ReturnBullet(collision.gameObject);

        }
        if (collision.gameObject.tag == "Passage")
        {
            TransferPlayer();
        }

    }
   
        
    
    private void TransferPlayer()
    {
        camera2.Human = true;
        camera2.ChangeCamera();
        PlayerMovement player2 = GameObject.Find("HumanPlayer").GetComponent<PlayerMovement>();
        player2.transform.position = new Vector3(8,0,0);
        player2.enabled = true;
        enemy.GetComponent<Enemy>().enabled = false;
        enemy.GetComponent<SpaceEnemyMove>().enabled = false;
        rb.velocity = new Vector2(0, 0);
        animator.SetFloat("isMoving", -1);
        GetComponent<SpaceshipMovement>().enabled = false;
    }
    public void Revive()
    {
        shield = totalShield;
        hp = 20 * healthLevel;
        dead = false;
    }




}
