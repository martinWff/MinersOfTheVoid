using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelp : MonoBehaviour
{
    [SerializeField] public GameObject boss;
    [SerializeField] public Laser laser;
    

    //player

    //Camera Componets
    private Camera cam;
    private float camHeigth;
    private float camWidth;
    private float camPosX;
    private float camPosY;
    private float camdiv3;
    private float camPosXCurent;
    private float camPosYCurent;

    //Enemy Help
    private float enemyHelpSize;
    private float enemyHelpRadius;
    public float enemyHelpSpeed = 3;


    //Enemy Laser
    private float timerLaser = 0.5f;

    private bool runningLaserAnim = false;

    [SerializeField]private float laserDelay = 0.5f;
    [SerializeField]private int laserAlarmRepetitions = 3;


  //  private bool colorSwitch = false;

    private float timerAttack = 0;
    [SerializeField] private float attackDuration = 3;

    //stop the alarm 
    private int change = 0;


    //Enemy Movement1
    private bool move = false;
    private bool move2 = false;

    private Vector3 targetPosition;
    private Vector3 targetPosition1;
    private Vector3 targetPosition2;

    //Limite enemy help1
    private float rect1moreX;
    private float rect1lessX;

    // Limite enemy help2
    private float rect2moreX;
    private float rect2lessX;


    void Start()
    {
        cam = Camera.main;
        camPosX = cam.transform.position.x;
        camPosY = cam.transform.position.y;
        camHeigth = 2f * cam.orthographicSize;
        camWidth = camHeigth * cam.aspect;
        camdiv3 = camWidth / 3;
        camPosXCurent = camPosX - camWidth / 2;
        camPosYCurent = camPosY + camHeigth / 2;
        //Debug.Log(camPosXCurent);
        //Debug.Log(camPosYCurent);

        enemyHelpSize = transform.localScale.x;
        enemyHelpRadius = enemyHelpSize / 2;


        rect1moreX = camPosXCurent + camdiv3 - enemyHelpRadius;
        //Debug.Log("rect1moreX" + rect1moreX);
        rect1lessX = camPosXCurent + enemyHelpRadius;
        //Debug.Log("rect1lessX" + rect1lessX);

        targetPosition1 = new Vector3(rect1moreX, boss.transform.position.y, 0);
        targetPosition2 = new Vector3(rect1lessX, boss.transform.position.y, 0);
        targetPosition = targetPosition1;

        
    }


    void Update()
    {
        MoveEnemyHelp();
        LaserAlarm();
    }

    private void MoveEnemyHelp()
    {

        if (!laser.IsRunning())
        {
            //rect1
            rect1moreX = camPosXCurent + camdiv3 - enemyHelpRadius;
            rect1lessX = camPosXCurent + enemyHelpRadius;

            //rect2
            rect2moreX = camPosXCurent + camdiv3 * 3 - enemyHelpRadius;
            rect2lessX = camPosXCurent + camdiv3 * 2 + enemyHelpRadius;

            if (transform.position.x < 0)
            {
                LimitMovement1();
            }
            else
            {
                LimitMovement2();
            }
        }
        

    }


    private void LimitMovement1()
    {
        if(move)
        {
            targetPosition = new Vector3(rect1moreX, boss.transform.position.y, 0);
        }
        else
        {

            targetPosition = new Vector3(rect1lessX, boss.transform.position.y, 0);
            
        }


        transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyHelpSpeed * Time.deltaTime);

        if (transform.position.x == rect1moreX)
        {
            //Debug.Log("position 1 more");
            move = false;
        }
        if (transform.position.x == rect1lessX)
        {
            //Debug.Log("position 2 less");

            move = true;
        }


    }
    private void LimitMovement2()
    {
        if (move2)
        {

            targetPosition = new Vector3(rect2moreX, boss.transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyHelpSpeed * Time.deltaTime);
        }
        else
        {

            targetPosition = new Vector3(rect2lessX, boss.transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyHelpSpeed * Time.deltaTime);
        }

        if (transform.position.x == rect2moreX)
        {
            //Debug.Log("position 1 more");
            move2 = false;
        }
        if (transform.position.x == rect2lessX)
        {
            //Debug.Log("position 2 less");

            move2 = true;
        }


    }

    private void LaserAlarm()
    {
        if(!laser.IsRunning() && !runningLaserAnim)
        {
           // timerLaser -= Time.deltaTime;

            runningLaserAnim = true;

            StartCoroutine(LaserAlarmAnim());

        }

        if (laser.IsRunning())
        {
            if (timerAttack >= attackDuration)
            {
                timerAttack = 0;

                laser.Deactivate();
                Color c = laser.spriteRenderer.color;
                c.a = 0;
                laser.spriteRenderer.color = c;
            }

            timerAttack += Time.deltaTime;

        }


    }

    private IEnumerator LaserAlarmAnim()
    {
        for (int i = 0; i < laserAlarmRepetitions; i++)
        {
            laser.spriteRenderer.color = new Color32(226, 52, 10, 0);

            yield return new WaitForSeconds(laserDelay);

            laser.spriteRenderer.color = new Color32(226, 52, 10, 255);

            yield return new WaitForSeconds(laserDelay);
        }

        laser.Activate();

        runningLaserAnim = false;
    }




}
