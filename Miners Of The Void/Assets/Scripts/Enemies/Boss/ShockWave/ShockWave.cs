using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{

    public float bulletLifeTime = 3;

    
    void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }

}
