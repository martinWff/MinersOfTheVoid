using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{


    //boss stats
    public float perBossHealthTotal = 1;
    public float bossHealthTotal = 100;
    private float bossHealth;
    private float perBossLife;

    [SerializeField] public lifebar lifebar;

    //player
    private GameObject player;
    private float playerdmg;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Spaceship");
        playerdmg = player.GetComponent<CharacterWeapon>().dmg.value;
        bossHealth = bossHealthTotal;
        lifebar.Setsize(perBossHealthTotal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {




            bossHealth -= playerdmg;

                
            
            if (bossHealth <= 0)
            {
                //Death
                bossHealth = 0;
                SavePlayerStats.bips += (int)Random.Range(3, 5);

                


                Destroy(transform.gameObject);
                Destroy(lifebar.gameObject);

                Debug.Log("Boss is Dead!!");
                

            }

            //Debug.Log(bossHealth);
            perBossLife = bossHealth / bossHealthTotal;
            lifebar.Setsize(perBossLife);


            //Debug.Log(bossHealth);
            //Debug.Log(shield);

            Destroy(collision.gameObject);
        }
    }


    private void WinBoss()
    {

    }



}

