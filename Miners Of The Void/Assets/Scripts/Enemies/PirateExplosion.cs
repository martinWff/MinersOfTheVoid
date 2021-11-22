using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateExplosion : MonoBehaviour
{
    private GameObject player;
    private GameObject spaceship;
    private float distance;
    private Rigidbody2D enemy;
    public float enemyRange = 20;
    public float speed = 15;

    [SerializeField] private lifebar lifebar;
    [SerializeField] private shieldbar shieldbar;

    private Vector3 targetPosition;

    //game object alarm
    private SpriteRenderer alarm;

    //stop the alarm 
    private bool attack = false;
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
    public float enemieHealthTotal= 20;
    public float enemieHealth = 20;
    public float totalShield = 10;
    public float shield = 10;
    public float playerdmg;
    private float perEnemieShield;
    private float perEnemieHealth;


    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        alarm = GameObject.FindGameObjectWithTag("Alarm").GetComponent<SpriteRenderer>();
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Spaceship");
        playerdmg = player.GetComponent<SpaceshipMovement>().playerDamage;

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



        if (attack == true)
        {
            //Debug.Log("attack true");
            //Debug.Log(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        }

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
