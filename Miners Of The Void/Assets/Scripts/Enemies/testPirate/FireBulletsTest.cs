using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletsTest : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 30;

    [SerializeField]
    private float startAngle = 0f, endAngle = 360f;

    //Enemy stats

    public float enemieHealth = 20;
    public float totalShield = 10;
    public float shield = 10;
    public float playerdmg;



    private Vector2 bulletMoveDirection;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 4f);
        playerdmg = GameObject.Find("PlayerSpaceship").GetComponent<SpaceshipMovement>().playerDamage;
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

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BulletTest>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }

    private void Update()
    {
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
