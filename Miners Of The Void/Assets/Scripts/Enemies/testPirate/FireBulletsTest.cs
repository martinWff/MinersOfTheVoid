using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletsTest : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 30;

    [SerializeField]
    private float startAngle = 0f, endAngle = 360f;

    public ObjectPool objectPool;

    //Enemy stats
    private Rigidbody2D enemy;
    public float enemieHealth = 20;
    public float totalShield = 10;
    public float shield = 10;
    public float playerdmg;
    private float bulletShootTime = 2;
    

    //Get Player
    private GameObject player;

    //shoot
    public float timer = 2;
    public float enemyRange = 20;
    private float distance;
    private float bulletNumbers;



    private Vector2 bulletMoveDirection;



    // Start is called before the first frame update
    void Start()
    {
        
        enemy = this.GetComponent<Rigidbody2D>();
       // playerdmg = GameObject.Find("PlayerSpaceship").GetComponent<SpaceshipMovement>().playerDamage;
        objectPool = FindObjectOfType<ObjectPool>();
        player = GameObject.FindGameObjectWithTag("Spaceship");
    }

    // Update is called once per frame
    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            //if (bulletNumbers == 30)
            //{
                GameObject bul = objectPool.GetBullet();



                if (bul != null)
                {
                    bul.transform.position = transform.position;
                    bul.transform.rotation = transform.rotation;

                    bul.GetComponent<BulletTest>().SetMoveDirection(bulDir);
                }
            //}
            angle += angleStep;
        }
    }

    private void Update()
    {
        if (player == null) return;
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.rotation = angle - 90;

        bulletNumbers = objectPool.CountBullets();
        Debug.Log(bulletNumbers);

        distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.y - transform.position.y, 2));
        if (distance < enemyRange)
        {



            if ((bulletShootTime <= 0))
            {

                InvokeRepeating("Fire", 0f, 4f);



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
