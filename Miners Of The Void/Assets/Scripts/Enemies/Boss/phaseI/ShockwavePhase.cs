using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwavePhase : PhaseBase
{
    [SerializeField] GameObject shockWave;
    [SerializeField] GameObject safeArea;
    [SerializeField] private float phaseDuration;

    //Boss
    private float bossSize;

    public float bulletOffset = 2;
    public float bulletShootTime = 1.5f;
    public float bulletCooldownTime = 1.5f;
    public float bulletSpeed = 14;

    //Safe Area
    private float safeAreaSize;
    private float safeAreaRadius;


    // rect1 spawn safe area
    private float rect1lessX;
    private float rect1lessY;

    // rect3 spawn safe area
    private float rect3moreX;
    private float rect3lessX;
    private float rect3moreY;
    private float rect3lessY;


    //Camera Componets
    private Camera cam;
    private float camHeigth;
    private float camWidth;
    private float camdiv3;
    private float camPosX;
    private float camPosY;
    private float camPosXCurent;
    private float camPosYCurent;

    private GameObject currentSafeArea;
    private GameObject currentShockwave;

    public int waveCount = 3;
    private int currentWave;

    private float safeAreaTimer = 0;
    public float safeAreaDelay = 2;

    private enum Phase
    {
        None,
        Safe,
        Wave,
        RemoveSafe
    }


    private Phase currentPhase;


    public override void OnPhaseBegan()
    {
        currentPhase = Phase.None;
        cam = Camera.main;
        camPosX = cam.transform.position.x;
        camPosY = cam.transform.position.y;
        camHeigth = 2f * cam.orthographicSize;
        camWidth = camHeigth * cam.aspect;
        camdiv3 = camWidth / 3;
        camPosXCurent = camPosX - camWidth / 2;
        camPosYCurent = camPosY + camHeigth / 2;
        //Debug.Log(camPosYCurent);
        //Debug.Log(camWidth);
        //Debug.Log(camPosXCurent);
        bossSize = 5;
        //Debug.Log(bossSize);
        safeAreaSize = safeArea.transform.localScale.x;
        safeAreaRadius = safeAreaSize / 2;
        //Debug.Log(safeAreaSize);
        //Debug.Log(safeAreaRadius);
        //SafeAreaSpawn();


        StartCoroutine(Startup());
    }

    private IEnumerator Startup()
    {
        yield return new WaitForSeconds(safeAreaDelay);
        currentPhase = Phase.Safe;
    }

    public override void OnTick()
    {

       // timer += Time.deltaTime;

        if (currentPhase == Phase.Safe)
        {
            SpawnSafeArea();
            
        } else if (currentPhase == Phase.Wave)
        {
            ShootShockWave();
        } else if (currentPhase == Phase.RemoveSafe)
        {
            if (currentShockwave == null) {
                Destroy(currentSafeArea);
                currentPhase = Phase.Safe;
            }

        }



    }


    private void ShootShockWave()
    {

        Vector3 _shotDirection = Vector3.down;
        if (bulletShootTime >= bulletCooldownTime)
        {
            currentShockwave = Instantiate(shockWave, transform.position + (_shotDirection * bulletOffset), Quaternion.identity);
            bulletShootTime = 0;
            currentShockwave.GetComponent<Rigidbody2D>().velocity = _shotDirection * bulletSpeed;

            currentWave++;
        } else
        {
            bulletShootTime += Time.deltaTime;
        }


        if (currentWave >= waveCount)
        {
            currentPhase = Phase.RemoveSafe;
            currentWave = 0;
        }


    }

    private void SpawnSafeArea()
    {
        if (currentSafeArea == null)
        {
            //rect1
            rect1lessX = camPosXCurent + safeAreaRadius;
            rect1lessY = camPosYCurent - bossSize - 2 - safeAreaRadius;

            //rect3
            rect3moreX = camPosXCurent + camdiv3 * 3 - safeAreaRadius;
            rect3moreY = camPosYCurent - camHeigth + safeAreaRadius;
            currentSafeArea = Instantiate(safeArea, new Vector3(Random.Range(rect3moreX, rect1lessX), Random.Range(rect3moreY, rect1lessY), 0), Quaternion.identity);

            
        } else
        {
            if (safeAreaTimer >= safeAreaDelay)
            {
                currentPhase = Phase.Wave;
                safeAreaTimer = 0;
            }
            safeAreaTimer += Time.deltaTime;
        }

    }


    public override void OnPhaseFinished()
    {
        Destroy(currentShockwave);
        Destroy(currentSafeArea);
    }
}
