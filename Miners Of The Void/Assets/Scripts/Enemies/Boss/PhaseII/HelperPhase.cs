using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperPhase : PhaseBase
{

    [SerializeField] public GameObject enemyHelp;

    private GameObject minion1;
    private GameObject minion2;


    //boss
    [SerializeField] Rigidbody2D rb;
    private float bossPosY;
    public GameObject bulletPrefab;
    public float bulletOffset = 4f;
    public float bulletSpeed = 14;
    public float bulletCooldownTime = 1.5f;
    public float bulletShootTime = 0.5f;

    //player
    [SerializeField] GameObject player;

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


    private bool hasSpawnedMinions = false;

    public override void OnPhaseBegan()
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

    void OnEnable()
    {
        
    }

    public override void OnTick()
    {
        SpawnEnemyHelp();
        BossShoot();
    }

    void Update()
    {
        
    }


    private void SpawnEnemyHelp()
    {
        if (!hasSpawnedMinions)
        {
           
            //rect1
            rect1moreX = camPosXCurent + camdiv3 - enemyHelpRadius;
            rect1lessX = camPosXCurent + enemyHelpRadius;

            //rect2
            rect2moreX = camPosXCurent + camdiv3 * 3 - enemyHelpRadius;
            rect2lessX = camPosXCurent + camdiv3 * 2 + enemyHelpRadius;

            
            minion1 = Instantiate(enemyHelp, new Vector3(Random.Range(rect1moreX, rect1lessX), bossPosY, 0), Quaternion.identity);
            //Debug.Log(bossPosY);

            minion2 = Instantiate(enemyHelp, new Vector3(Random.Range(rect2moreX, rect2lessX), bossPosY, 0), Quaternion.identity);
            hasSpawnedMinions = true;
        }


    }

    private void BossShoot()
    {
        //Debug.Log("Chega aqui");
        if (player == null) return;

        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;

        //Debug.Log("Chega aqui");
        if ((bulletShootTime <= 0))
        {

            Vector3 Shotdirection = Maths.TransformUp(gameObject);

            
            GameObject bullet = Instantiate(bulletPrefab, transform.position + (Shotdirection.normalized * bulletOffset), Quaternion.identity);
            bulletShootTime = bulletCooldownTime;
            bullet.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;
        }
        if (bulletShootTime >= 0)
        {
            bulletShootTime -= Time.deltaTime;
        }
    }

    public void PhaseEnd()
    {

        Destroy(minion1);
        Destroy(minion2);
        hasSpawnedMinions = false;
        enabled = false;

    }

    public override void OnPhaseFinished()
    {
        Destroy(minion1);
        Destroy(minion2);
    }

}
