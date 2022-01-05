using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhelp : MonoBehaviour
{
    [SerializeField] public GameObject boss;
    [SerializeField] public SpriteRenderer lazer;
    

    //boss
    private float bossPosY;

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

    //Enemy Lazer
    private bool lazerOn = false;
    private float timerLazer = 0.5f;
    private float lazerHigth;
    private float lazerHigthdiv2;
    private bool lazerColorOn = false;
    private bool colorSwitch = false;
    Color lazer_NewColor;
    private float timerAttack = 3;

    //stop the alarm 
    private bool attack = false;
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

        bossPosY = transform.position.y;

        rect1moreX = camPosXCurent + camdiv3 - enemyHelpRadius;
        //Debug.Log("rect1moreX" + rect1moreX);
        rect1lessX = camPosXCurent + enemyHelpRadius;
        //Debug.Log("rect1lessX" + rect1lessX);
        bossPosY = boss.transform.position.y;
        targetPosition1 = new Vector3(rect1moreX, bossPosY, 0);
        targetPosition2 = new Vector3(rect1lessX, bossPosY, 0);
        targetPosition = targetPosition1;


        lazer = transform.Find("Lazer").GetComponent<SpriteRenderer>();
        
    }


    void Update()
    {
        MoveEnemyHelp();
        LazerAlarm();
    }

    private void MoveEnemyHelp()
    {

        if (lazerOn == false)
        {
            //rect1
            rect1moreX = camPosXCurent + camdiv3 - enemyHelpRadius;
            rect1lessX = camPosXCurent + enemyHelpRadius;

            //rect2
            rect2moreX = camPosXCurent + camdiv3 * 3 - enemyHelpRadius;
            rect2lessX = camPosXCurent + camdiv3 * 2 + enemyHelpRadius;

            if (transform.position.x < 0)
            {
                LimitMovemt1();
            }
            else
            {
                LimitMovemt2();
            }
        }
        

    }


    private void LimitMovemt1()
    {
        if(move == true)
        {

            targetPosition = new Vector3(rect1moreX, bossPosY, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyHelpSpeed * Time.deltaTime);
        }
        else
        {

            targetPosition = new Vector3(rect1lessX, bossPosY, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyHelpSpeed * Time.deltaTime);
        }

        if(transform.position.x == rect1moreX)
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
    private void LimitMovemt2()
    {
        if (move2 == true)
        {

            targetPosition = new Vector3(rect2moreX, bossPosY, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyHelpSpeed * Time.deltaTime);
        }
        else
        {

            targetPosition = new Vector3(rect2lessX, bossPosY, 0);
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

    private void LazerAlarm()
    {
        if(lazerOn == false)
        {
            timerLazer -= Time.deltaTime;
            if (timerLazer <= 0 && attack == false)
            {
                if (colorSwitch == false)
                {
                    lazer_NewColor = new Color32(226, 52, 10, 225);
                    colorSwitch = true;
                    timerLazer = 0.5f;
                    change = change + 1;
                }
                else
                {
                    lazer_NewColor = new Color32(226, 52, 10, 0);
                    colorSwitch = false;
                    timerLazer = 0.5f;
                    change = change + 1;
                }

                if (change >= 9 && attack == false)
                {
                    attack = true;
                    change = 0;
                    lazerOn = true;

                }


                lazer.color = lazer_NewColor;
            }
        }

        if(lazerOn == true)
        {
            timerAttack -= Time.deltaTime;
            lazer_NewColor = new Color32(226, 52, 10, 225);
            lazer.color = lazer_NewColor;
        }

        if(timerAttack <= 0)
        {
            attack = false;
            lazerOn = false;
            timerAttack = 3;
        }
    }

  


}
