using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateExploosion : MonoBehaviour
{

    private GameObject player;
    private GameObject spaceship;
    private float distance;
    private Rigidbody2D enemy;
    public float enemyRange = 20;
    public float speed = 15;
    bool died;
    public EnemyData enemyData;

    [SerializeField] private lifebar lifebar;
    [SerializeField] private shieldbar shieldbar;
    [SerializeField] private SpriteRenderer alarm;

    public Vector3 targetPosition;


    public System.Action<GameObject> boss;

    //stop the alarm 
    public bool attack = false;
    private int change = 0;

    //alpha switch
    private bool colorSwitch = false;
    private float timer = 0.5f;

    //another attack
    private float timerColdown = 3;

    SpriteRenderer pirate_spriterender;
    Color alarm_NewColor;

    //enemy stats
    public float perEnemieHealthTotal = 1;
    public float perEnemieShieldTotal = 1;
    public float enemieHealthTotal = 20 * SavePlayerStats.level;
    public float enemieHealth = 20 * SavePlayerStats.level;
    public float totalShield = 10 * SavePlayerStats.level;
    public float shield = 10 * SavePlayerStats.level;
    public float playerdmg;
    private float perEnemieShield;
    private float perEnemieHealth;


    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerdmg = spaceship.GetComponent<CharacterWeapon>().dmg.value;
        //Debug.Log(playerdmg);

        pirate_spriterender = GetComponent<SpriteRenderer>();

        lifebar.Setsize(perEnemieHealthTotal);
        shieldbar.Setsize2(perEnemieShieldTotal);

    }

    // Update is called once per frame
    void Update()
    {
        if (spaceship == null) return;


        distance = Mathf.Sqrt(Mathf.Pow(spaceship.transform.position.x - transform.position.x, 2) + Mathf.Pow(spaceship.transform.position.y - transform.position.y, 2));
        if (distance < enemyRange)
        {


            Warning();

        }
        else
        {
            alarm.color = new Color32(255, 255, 255, 0);
            colorSwitch = false;
        }



        /*if (attack == true)
        {
            //Debug.Log("attack true");
            //Debug.Log(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        }*/

        if (transform.position == targetPosition && attack == true)
        {


            attack = false;



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
                float enemyHealthSubtraction = (playerdmg - shield);
                if (shield != 0)
                {
                    enemieHealth -= enemyHealthSubtraction;
                    enemyData.OnDamageReceived(enemyHealthSubtraction);
                }
                
                shield = 0;
            }
            if (enemieHealth <= 0)
            {
                enemieHealth = 0;
                shield = 0;
                SavePlayerStats.bips += Random.Range(3, 5);
                if (!died) {
                    // CombatSystem.onDied?.Invoke("Drone");
                    //    Debug.Log("destroyed");
                    died = true;
                    enemyData.OnKilled();

                Destroy(transform.parent.gameObject);
                    }

                boss?.Invoke(gameObject);
            }


            perEnemieHealth = enemieHealth / enemieHealthTotal;
            perEnemieShield = shield / totalShield;
            lifebar.Setsize(perEnemieHealth);
            shieldbar.Setsize2(perEnemieShield);

            Destroy(collision.gameObject);
        }
    }

    public void Warning()
    {

        //Debug.Log("Warning works 1 time");

        if (attack == false)
        {
            Vector3 playerPosition = new Vector3(spaceship.transform.position.x, spaceship.transform.position.y, spaceship.transform.position.z);
            Vector3 direction = spaceship.transform.position - transform.position;
            targetPosition = playerPosition;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemy.rotation = angle - 90;
        }


        timer -= Time.deltaTime;
        if (timer <= 0 && attack == false)
        {
            if (colorSwitch == false)
            {
                alarm_NewColor = new Color32(255, 255, 255, 225);
                colorSwitch = true;
                timer = 0.5f;
                change = change + 1;
            }
            else
            {
                alarm_NewColor = new Color32(255, 255, 255, 0);
                colorSwitch = false;
                timer = 0.5f;
                change = change + 1;
            }

            if (change >= 5 && attack == false)
            {
                attack = true;
                change = 0;

            }


            alarm.color = alarm_NewColor;
        }
    }
}
