using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime = 5;
    public bool friendlyFire = true;
    GameObject player;
    SpaceshipMovement sM;
    void Start()
    {

        Destroy(gameObject, bulletLifeTime);

    }





    // Update is called once per frame
}
