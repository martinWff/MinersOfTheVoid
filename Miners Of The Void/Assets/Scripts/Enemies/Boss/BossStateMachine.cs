using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStateMachine : MonoBehaviour
{
    //boss stats
    public float perBossHealthTotal = 1;
    public float bossHealthTotal = 100;


    //phase controller
    public PhaseManager phaseController;

    //player
    [SerializeField] GameObject player;

    [SerializeField] Health health;

    public List<StateMilestone> milestones = new List<StateMilestone>();
    private int milestoneReached = 0;

    [SerializeField] int sceneId = 2;


    void Start()
    {
    }


    public void OnDamaged(float dmg)
    {
        State(dmg);
    }


    protected virtual void State(float dmg)
    {
        float hp = health.hp;

        int currentMilestone = -1;

        for (int i = 0;i<milestones.Count;i++)
        {
            if (milestones[i].phase > milestoneReached && (milestones[i].health * health.maxHP.value) >= hp)
            {
                currentMilestone = milestones[i].phase;
            }
        }

        if (currentMilestone > -1)
        {
            milestoneReached = currentMilestone;
            phaseController.GoToPhase(currentMilestone);
        }
    }

    public void OnDied()
    {
        SceneManager.LoadScene(sceneId);
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Bullet")
         {




             bossHealth -= playerdmg;
             perBossLife = bossHealth / bossHealthTotal;


             if (bossHealth <= 0)
             {
                 //Death
                 bossHealth = 0;
                 SavePlayerStats.bips += (int)Random.Range(3, 5);




                 Destroy(transform.gameObject);

                 CombatSystem.onDied?.Invoke("boss", false);

                 Debug.Log("Boss is Dead!!");
                 SceneManager.LoadScene(2);

             }



             Debug.Log(perBossLife);

             if(perBossLife < 0.666 && phaseChanger == 3)
             {

                 phaseController.ProgressPhase();
                 phaseChanger = 2;
             }

             if (perBossLife < 0.333 && phaseChanger == 2)
             {


                 phaseController.ProgressPhase();
                 phaseChanger = 1;
             }


             Destroy(collision.gameObject);
         }
     }*/

    [System.Serializable]
    public struct StateMilestone
    {
        public float health;
        public int phase;
    }

}

