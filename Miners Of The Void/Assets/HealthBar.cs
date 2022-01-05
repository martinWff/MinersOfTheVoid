using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float playerDamage = 10;
    public float shield = 10;
    public CharacterStat totalShield = new CharacterStat(10);
    public CharacterStat totalhp = new CharacterStat(20);
    public float hp = new CharacterStat(20).value;
    public bool immortality = false;
    private EntityController entity;
    public bool lazerCharge = false;
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
        lifeBar.fillAmount = hp / totalhp.value;
        shieldBar.fillAmount = shield / totalShield.value;
        if (shield < totalShield.value)
        {
            shield += (totalShield.value / 10) * Time.deltaTime;
        }
        if (shield > totalShield.value) shield = totalShield.value;
        if (Input.GetKeyDown(KeyCode.L)) Debug.Log(totalShield.value + "\n" + totalhp.value);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((collision.gameObject.tag == "BulletEnemie" || collision.gameObject.tag == "PirateExplosion" || collision.gameObject.tag == "BulletEnemiePool" || (collision.gameObject.tag == "Lazer" && lazerCharge == false))))
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
                if (collision.gameObject.tag != "PirateExplosion" && collision.gameObject.tag != "Lazer")
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
