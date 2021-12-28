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

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(phaseION == false)
        {
            shootTimer = shootTimer + Time.deltaTime;
            phaseITimer = 0;
            Debug.Log(shootTimer);
        }
        

        if (shootTimer >= 5)
        {
            phaseION = true;
            ShotShockWave();
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

    }
}
