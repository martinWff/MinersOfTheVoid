using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float Distance;
    

    [SerializeField] public lifebar lifebar;
    [SerializeField] public shieldbar shieldbar;

    public System.Action<GameObject> boss;
    private bool died;
    public EnemyData enemyData;

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
    public float enemieHealthTotal = 20 * SavePlayerStats.level;
    public float enemieHealth = 20 * SavePlayerStats.level;
    public float totalShield = 10 * SavePlayerStats.level;
    public float shield = 10 * SavePlayerStats.level;
    public float playerdmg;
    private float perEnemyLife;
    private float perEnemyShield;
    public AudioSource audioSource;



    //Enemy rotation
    private Rigidbody2D enemy;

    //bool enemy Planet
    public bool enemyPlanet = false;




    void Start()
    {
        if (enemyPlanet == true)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerdmg = player.GetComponent<CharacterWeapon>().dmg.value;
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Spaceship");
            playerdmg = player.GetComponent<CharacterWeapon>().dmg.value;
        }
        

        //Debug.Log(player);
        enemy = this.GetComponent<Rigidbody2D>();
        
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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.rotation = angle - 90;


        Distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.y - transform.position.y, 2));
        if (Distance < enemyRange)
        {



            if ((bulletShootTime <= 0))
            {


                //Debug.Log(bulletPrefab);
                Vector3 Shotdirection = Maths.TransformUp(gameObject);

                //GameObject bullet = EnemyPool.bulletInstanse.GetEnemyBullet();
                //bullet.SetActive(true);
                //bullet.transform.position = transform.position + (Shotdirection.normalized * bulletOffset);
                //Debug.Log("posição da bala "+bullet.transform.position);
                GameObject bullet = Instantiate(bulletPrefab, transform.position + (Shotdirection.normalized * bulletOffset), Quaternion.identity);
                bulletShootTime = bulletCooldownTime;
                bullet.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;
                if (audioSource != null && audioSource.clip != null)
                {
                    Debug.Log("plau clip");
                    audioSource?.Play();
                }
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
                float dmgReduction = (playerdmg - shield);
                if (shield != 0) { 
                    enemieHealth -= dmgReduction;
                    enemyData.OnDamageReceived(dmgReduction);
                }

                shield = 0;
            }
            if (enemieHealth <= 0)
            {
                //Death
                enemieHealth = 0;
                shield = 0;
                SavePlayerStats.bips += (int)Random.Range(3,5);

                if (!died)
                {
                 //   CombatSystem.onDied?.Invoke("Shooter");
                    died = true;
                    enemyData.OnKilled();
                }
                Destroy(transform.parent.gameObject);

                boss?.Invoke(transform.parent.gameObject);

            }

            perEnemyLife = enemieHealth / enemieHealthTotal;
            perEnemyShield = shield / totalShield;
            lifebar.Setsize(perEnemyLife);
            shieldbar.Setsize2(perEnemyShield);

            Destroy(collision.gameObject);
        }
    }



}