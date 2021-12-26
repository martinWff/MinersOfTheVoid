using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseI : MonoBehaviour
{
    [SerializeField] public GameObject shockWave;

    private Rigidbody2D boss;

    //shoot
    public float bulletOffset = 2;
    public float bulletShootTime = 1.5f;
    public float bulletCooldownTime = 1.5f;
    public float bulletSpeed = 14;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShotShockWave()
    {

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
    }
}
