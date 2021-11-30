using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceshipMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float minRotationDistance = 40;

    //objectPool
    public ObjectPool objectPool;

    //Shot
    public GameObject bulletPrefab;
    public float bulletOffset = 1.5f;
    public float bulletSpeed = 18;
    public float bulletCooldownTime = 0.5f;
    private float bulletShootTime = 0.5f;
    
    //movement
    float verticalInput;
    float horizontalInput;
    public float moveForce = 8;
    private Vector3 test;
    //status
    public float totalShield = 20;
    public float shield = 20;
    public float hp = 20;
    public float totalhp = 20;
    public GameObject statusDisplay;
    public Text statusDisplayText;


    public float playerDamage = 10;
    public float speedLevel = 0;
    public float dmgLevel = 0;
    public float shieldLevel = 0;
    public float healthLevel = 0;
    public bool backweaponMode = false;

    public GameObject upgradePrefab;
    public GameObject canvas;
    private StaticCameraController camera2;
    public bool dead = false;
    public bool immortality = false;
    public GameObject enemy;
    private Animator animator;
    
    private float deathTimer = 0;
    public Transform reference;
    //UI
    public Image lifeBar;
    public Image shieldBar;

   



    void Start()
    {
        LoadStats();
        rb = GetComponent<Rigidbody2D>();
        // statusDisplay = GameObject.FindGameObjectWithTag("PlayerStats");
        //statusDisplayText=statusDisplay.GetComponent<Text>();
        lifeBar = GameObject.Find("Life").GetComponent<Image>();
        shieldBar = GameObject.Find("Shield").GetComponent<Image>();
        canvas = GameObject.Find("Canvas");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        camera2 = Camera.main.GetComponent<StaticCameraController>();
        objectPool = FindObjectOfType<ObjectPool>();
        animator = GetComponent<Animator>();



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
        if (Vector3.Distance(transform.position, reference.position) > 100)
        {
            SaveStats();
            SceneManager.LoadScene("TestBattleScene");
        }
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
        

         
         lifeBar.fillAmount = hp / totalhp;
        shieldBar.fillAmount = shield / totalShield;

         
        



        //rb.velocity = ((verticalInput * transform.right) +
        //              (horizontalInput * transform.up)) * moveForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "BulletEnemie" || collision.gameObject.tag == "PirateExplosion" || collision.gameObject.tag == "BulletEnemiePool") && !dead && !immortality)
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
                SceneManager.LoadScene("Lobby");
            }
            if(collision.gameObject.tag != "PirateExplosion")
            Destroy(collision.gameObject);
            else if(collision.gameObject.tag == "BulletEnemiePool")
            {
                collision.gameObject.GetComponent<BulletTest>().touchedPlayer = true;
                objectPool.RetrieveBullet(collision.gameObject);
            }
        }

       

        if (collision.gameObject.tag == "Passage" || collision.gameObject.tag == "Structure")
        {
            TransferPlayer();
        }

    }
   
        
    
    private void TransferPlayer()
    {
           
            
            camera2.Human = true;
            camera2.ChangeCamera();
            GameObject player2 = GameObject.Find("HumanPlayer");
            player2.GetComponent<PlayerMovement>().transform.position = new Vector3(8, 0, 0);
            player2.GetComponent<PlayerMovement>().enabled = true;
            player2.GetComponent<SpriteRenderer>().enabled = true;
        
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector3(-16.84f, 0.11f, 0);
            rb.rotation = 0;
            animator.SetFloat("isMoving", -1);
            if (enemy != null)
            {
                enemy.GetComponent<Enemy>().enabled = false;
                enemy.GetComponent<SpaceEnemyMove>().enabled = false;
            }
            GetComponent<SpaceshipMovement>().enabled = false;
           



    }
    public void Revive()
    {
        shield = totalShield;
        hp = totalhp;
        dead = false;
    }

    public void SaveStats()
    {
        SavePlayerStats.moveForce = moveForce;
        SavePlayerStats.playerDamage = playerDamage;
        SavePlayerStats.shield = shield;
        SavePlayerStats.totalShield = totalShield;
        SavePlayerStats.hp = hp;
        SavePlayerStats.backWeapon = backweaponMode;
        SavePlayerStats.healthLevel = healthLevel;
        SavePlayerStats.speedLevel = speedLevel;
        SavePlayerStats.dmgLevel = dmgLevel;
        SavePlayerStats.shieldLevel = shieldLevel;
        SavePlayerStats.bulletSpeed = bulletSpeed;
    }
    public void LoadStats()
    {
        moveForce= SavePlayerStats.moveForce;
        playerDamage =SavePlayerStats.playerDamage ;
        shield = SavePlayerStats.shield;
        totalShield = SavePlayerStats.totalShield;
        hp = SavePlayerStats.hp;
        backweaponMode = SavePlayerStats.backWeapon;
        healthLevel = SavePlayerStats.healthLevel;
        speedLevel = SavePlayerStats.speedLevel;
        dmgLevel = SavePlayerStats.dmgLevel;
        shieldLevel = SavePlayerStats.shieldLevel;
        bulletSpeed = SavePlayerStats.bulletSpeed;
    }




}
