using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float playerDamage = 10;
    public float totalShield = 20;
    public float shield = 20;
    public float totalhp = 20;
    public float hp = 20;
    public bool immortality = false;
    private EntityController entity;
    Image lifeBar;
    Image shieldBar;
    

    // Update is called once per frame
    void Start()
    {
        entity = gameObject.GetComponent<EntityController>();
        lifeBar = GameObject.Find("Life").GetComponent<Image>();
        shieldBar = GameObject.Find("Shield").GetComponent<Image>();
    }
    private void Update()
    {
        lifeBar.fillAmount = hp / totalhp;
        shieldBar.fillAmount = shield / totalShield;
        if (shield < totalShield)
        {
            shield += (totalShield / 10) * Time.deltaTime;
        }
        if (shield > totalShield) shield = totalShield;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((collision.gameObject.tag == "BulletEnemie" || collision.gameObject.tag == "PirateExplosion" || collision.gameObject.tag == "BulletEnemiePool")))
        {
            Debug.Log(immortality);
            
            if (!immortality)
            {
                if (shield >= 10) shield -= 10;
                if (shield < 10)
                {
                    if (shield != 0) hp -= (10 - shield);

                    shield = 0;
                }
                if (hp <= 0)
                {
                    if (gameObject.tag == "Player" || gameObject.tag == "Spaceship") entity.SceneChanger(0);
                    
                }
                if (collision.gameObject.tag != "PirateExplosion")
                    Destroy(collision.gameObject);
                else if (collision.gameObject.tag == "BulletEnemiePool")
                {
                    collision.gameObject.GetComponent<BulletTest>().touchedPlayer = true;
                    //objectPool.RetrieveBullet(collision.gameObject);
                }
            }

        }
        
    }
    
    
}
