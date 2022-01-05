using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseI : MonoBehaviour
{
    [SerializeField] public GameObject shockWave;
    [SerializeField] public GameObject safeArea;

    //Boss
    private Rigidbody2D boss;
    private GameObject bossG;
    private float bossSize;
    

    //shoot
    public float shootTimer = 0;
    private bool phaseION = false;
    public float phaseITimer = 0;

    public float bulletOffset = 2;
    public float bulletShootTime = 1.5f;
    public float bulletCooldownTime = 1.5f;
    public float bulletSpeed = 14;

    //Safe Area
    private float safeAreaSize;
    private float safeAreaRadius;
    private bool spawnAreaBool = false;
    private int safeAreaCount = 0;
    

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




    // Start is called before the first frame update
    void Start()
    {
        bossG = this.GetComponent<GameObject>();
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
    }

    // Update is called once per frame
    void Update()
    {
        if(phaseION == false)
        {
            shootTimer = shootTimer + Time.deltaTime;
            phaseITimer = 0;
            safeAreaCount = 0;
            //Debug.Log(shootTimer);
        }
        

        if (shootTimer >= 5)
        {
            if(safeAreaCount == 0)
            {
                spawnAreaBool = false;
            }
            phaseION = true;
            ShotShockWave();
        }
        
    }

    private void ShotShockWave()
    {
        phaseITimer = phaseITimer + Time.deltaTime;
        Debug.Log(phaseITimer);
        SafeAreaSpawn();
        Vector3 Shotdirection = new Vector3(0, -1, 0);
        if ((bulletShootTime <= 0))
        {
            GameObject shockwave = Instantiate(shockWave, transform.position + (Shotdirection.normalized * bulletOffset), Quaternion.identity);
            bulletShootTime = bulletCooldownTime;
            shockwave.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;
        }
        if (bulletShootTime >= 0)
        {
            bulletShootTime -= Time.deltaTime;
        }

        if(phaseITimer >= 8)
        {
            shootTimer = 0;
            phaseION = false;
        }
    }

    private void SafeAreaSpawn()
    {
        
        if (spawnAreaBool == false)
        {
            
            //rect1
            rect1lessX = camPosXCurent + safeAreaRadius;
            rect1lessY = camPosYCurent - bossSize - 2 - safeAreaRadius;
       
            //rect3
            rect3moreX = camPosXCurent + camdiv3 * 3 - safeAreaRadius;
            rect3moreY = camPosYCurent - camHeigth + safeAreaRadius;
            Instantiate(safeArea, new Vector3(Random.Range(rect3moreX, rect1lessX), Random.Range(rect3moreY, rect1lessY), 0), Quaternion.identity);
            spawnAreaBool = true;
            safeAreaCount = safeAreaCount + 1;
        }
        

    }

    

    
}
