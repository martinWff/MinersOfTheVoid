using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public float totalhp = 20;
    public float hp = 20;
    public Image lifeBar;
    public Image shieldBar;
    //public GameObject statusDisplay;
    //public Text statusDisplayText;

    public float speedLevel = 1;
    public float dmgLevel = 1;
    public float shieldLevel = 1;
    public float healthLevel = 1;

    public float deathTimer = 0;
    void Start()
    {
        LoadStats();
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        lifeBar = GameObject.Find("Life").GetComponent<Image>();
        shieldBar = GameObject.Find("Shield").GetComponent<Image>();
        
        

        

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
        Vector2 mouseDirection2 = Input.mousePosition -
            Camera.main.WorldToScreenPoint(transform.position);
        if (mouseDirection2.magnitude > minRotationDistance)
        {
            float angle = Mathf.Atan2(mouseDirection2.normalized.y,
                                  mouseDirection2.normalized.x) * Mathf.Rad2Deg;
            rb.SetRotation(angle);
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

        lifeBar.fillAmount = hp / totalhp;
        shieldBar.fillAmount = shield / totalShield;


        //if (deathTimer > 0) deathTimer -= Time.deltaTime;

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Passage" && deathTimer <= 0)
        {
            camera.Human = false;
            camera.ChangeCamera();
            SpaceshipMovement player2 = GameObject.Find("PlayerSpaceship").GetComponent<SpaceshipMovement>();
            player2.enabled = true;
            player2.Revive();
            rb.velocity = new Vector2(0, 0);
            if (enemy != null)
            {
                enemy.GetComponent<Enemy>().enabled = true;
                enemy.GetComponent<SpaceEnemyMove>().enabled = true;
            }
            SaveStats();
            GetComponent<PlayerMovement>().enabled = false;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = (verticalInput * Vector2.up * moveForce) + (horizontalInput * Vector2.right * moveForce);
    }

    public void SaveStats()
    {
        SavePlayerStats.moveForceH = moveForce;
        SavePlayerStats.playerDamageH = playerDamage;
        SavePlayerStats.shieldH = shield;
        SavePlayerStats.totalShieldH = totalShield;
        SavePlayerStats.hpH = hp;
        SavePlayerStats.healthLevelH = healthLevel;
        SavePlayerStats.speedLevelH = speedLevel;
        SavePlayerStats.dmgLevelH = dmgLevel;
        SavePlayerStats.shieldLevelH = shieldLevel;
        SavePlayerStats.bulletSpeedH = bulletSpeed;
    }
    public void LoadStats()
    {
        moveForce = SavePlayerStats.moveForceH;
        playerDamage = SavePlayerStats.playerDamageH;
        shield = SavePlayerStats.shieldH;
        totalShield = SavePlayerStats.totalShieldH;
        hp = SavePlayerStats.hpH;
        totalhp = SavePlayerStats.hpH;
        healthLevel = SavePlayerStats.healthLevelH;
        speedLevel = SavePlayerStats.speedLevelH;
        dmgLevel = SavePlayerStats.dmgLevelH;
        shieldLevel = SavePlayerStats.shieldLevelH;
        bulletSpeed = SavePlayerStats.bulletSpeedH;
    }


}
