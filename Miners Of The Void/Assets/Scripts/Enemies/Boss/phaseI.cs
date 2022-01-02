using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseI : MonoBehaviour
{
    [SerializeField] public GameObject shockWave;
    [SerializeField] public GameObject safeArea;

    private Rigidbody2D boss;

    //shoot
    public float shootTimer = 0;
    private bool phaseION = false;
    public float phaseITimer = 0;

    public float bulletOffset = 2;
    public float bulletShootTime = 1.5f;
    public float bulletCooldownTime = 1.5f;
    public float bulletSpeed = 14;

    //shockWave

    //Safe Area
    private float safeAreaSize;
    private float safeAreaRadius;
    private int ramdomNumberX;
    private int ramdomNumberY;

    // rect1 spawn safe area
    private float rect1moreX;
    private float rect1lessX;
    private float rect1moreY;
    private float rect1lessY;


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
        cam = Camera.main;
        camPosX = cam.transform.position.x;
        camPosY = cam.transform.position.y;
        camHeigth = 2f * cam.orthographicSize;
        camWidth = camHeigth * cam.aspect;
        camdiv3 = camWidth / 3;
        //Debug.Log(camHeigth);
        //Debug.Log(camWidth);
        //Debug.Log(camdiv3);

        safeAreaSize = safeArea.transform.localScale.x;
        safeAreaRadius = safeAreaSize / 2;
        //Debug.Log(safeAreaSize);
        //Debug.Log(safeAreaRadius);
        SafeAreaSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(phaseION == false)
        {
            shootTimer = shootTimer + Time.deltaTime;
            phaseITimer = 0;
            //Debug.Log(shootTimer);
        }
        

        if (shootTimer >= 5)
        {
            phaseION = true;
            //ShotShockWave();
        }
        
    }

    private void ShotShockWave()
    {
        phaseITimer = phaseITimer + Time.deltaTime;
        Debug.Log(phaseITimer);
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
        rect1moreX = camdiv3 - safeAreaRadius;
        Debug.Log(rect1moreX);
        Instantiate(safeArea, new Vector3(rect1moreX, 0, 0), Quaternion.identity);
    }

    private void RandomNumberGenerator()
    {

    }

    
}
