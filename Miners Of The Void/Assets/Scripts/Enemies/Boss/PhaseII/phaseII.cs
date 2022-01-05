using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseII : MonoBehaviour
{

    [SerializeField] public GameObject enemyHelp;

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
    private float timerLazer = 0;

    //Enemy Movement1
    private bool arrived = false;
    private Vector3 targetPosition1;

    //Limite enemy help1
    private float rect1moreX;
    private float rect1lessX;

    // Limite enemy help2
    private float rect2moreX;
    private float rect2lessX;


    private bool spawnEnemyHelpBool = false;



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

        enemyHelpSize = enemyHelp.transform.localScale.x;
        enemyHelpRadius = enemyHelpSize / 2;

        bossPosY = transform.position.y;
        //Debug.Log(bossPosY);

        rect1moreX = camPosXCurent + camdiv3 - enemyHelpRadius;
        //Debug.Log("rect1moreX" + rect1moreX);
        rect1lessX = camPosXCurent + enemyHelpRadius;
        //Debug.Log("rect1lessX" + rect1lessX);
    }


    void Update()
    {
        SpawnEnemyHelp();
        //LazerAlarm();
    }


    private void SpawnEnemyHelp()
    {
        if (spawnEnemyHelpBool == false)
        {
           
            //rect1
            rect1moreX = camPosXCurent + camdiv3 - enemyHelpRadius;
            rect1lessX = camPosXCurent + enemyHelpRadius;

            //rect2
            rect2moreX = camPosXCurent + camdiv3 * 3 - enemyHelpRadius;
            rect2lessX = camPosXCurent + camdiv3 * 2 + enemyHelpRadius;

            
            Instantiate(enemyHelp, new Vector3(Random.Range(rect1moreX, rect1lessX), bossPosY, 0), Quaternion.identity);
            Debug.Log(bossPosY);

            Instantiate(enemyHelp, new Vector3(Random.Range(rect2moreX, rect2lessX), bossPosY, 0), Quaternion.identity);
            spawnEnemyHelpBool = true;
            
            
        }


    }

    

    

    
}
