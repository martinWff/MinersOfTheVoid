using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

    public EntityController tpPlayer;


    //boss stats
    public float perBossHealthTotal = 1;
    public float bossHealthTotal = 100;
    private float bossHealth;
    private float perBossLife;
    private int phaseChanger = 3;

    //phases
    public PhaseI phaseI;
    public PhaseII phaseII;
    public PhaseIII phaseIII;


    //phase controller
    public PhaseManager phaseController;

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
            perBossLife = bossHealth / bossHealthTotal;
            lifebar.Setsize(perBossLife);


            if (bossHealth <= 0)
            {
                //Death
                bossHealth = 0;
                SavePlayerStats.bips += (int)Random.Range(3, 5);

                


                Destroy(transform.gameObject);
                Destroy(lifebar.gameObject);

                Debug.Log("Boss is Dead!!");
                SceneManager.LoadScene(2);

            }



            Debug.Log(perBossLife);

            if(perBossLife < 0.666 && phaseChanger == 3)
            {

                phaseController.RandomNumber();
                phaseChanger = 2;
            }

            if (perBossLife < 0.333 && phaseChanger == 2)
            {


                phaseController.RandomNumber();
                phaseChanger = 1;
            }


            Destroy(collision.gameObject);
        }
    }



}

